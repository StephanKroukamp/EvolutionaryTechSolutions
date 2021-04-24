using System;
using System.Collections.Generic;
using System.Text;
using Core.Api.Settings;
using Core.Database.MusicStore;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Core.Api
{
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CorsSettings>(configuration.GetSection("Cors"));
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            CorsSettings corsSettings = configuration.GetSection("Cors").Get<CorsSettings>();
            JwtSettings jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins(corsSettings.FrontEndBaseUrl);
            }));


            FirestoreDb firestoreDb = FirestoreDb.Create("musicstore-e007c");

            services.AddSingleton<FirestoreDb>(provider => firestoreDb);

            services.AddScoped<ArtistRepository>();

            string aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (aspNetCoreEnvironment.Equals(Environments.MusicStore))
            {

            }

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("MusicStore", new OpenApiInfo { Title = "Music Store", Version = "v1" });
            });

            services
                .AddAuthorization()
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            string aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (aspNetCoreEnvironment.Equals(Environments.MusicStore))
            {

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.RoutePrefix = "";

                options.SwaggerEndpoint("../swagger/MusicStore/swagger.json", "Music Store");
            });
        }
    }
}