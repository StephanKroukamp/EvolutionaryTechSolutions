using System;
using System.Collections.Generic;
using System.Text;
using Core.Api.Settings;
using Core.Api.Validators.MusicStore;
using Core.Api.Validators.TutorBusiness;
using Core.Database.MusicStore;
using Core.Database.TutorBusiness;
using Core.Repository.MusicStore;
using Core.Repository.TutorBusiness;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Core.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.tutorbusiness.json", optional: true)
                .AddJsonFile($"appsettings.musicstore.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));


            JwtSettings jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            string aspNetCoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (aspNetCoreEnvironment.Equals(Settings.Environments.TutorBusiness.ToString()))
            {
                services.AddDbContext<TutorBusinessDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<ParentRepository>();
                services.AddScoped<StudentRepository>();

                services.AddScoped<ParentValidator>();
                services.AddScoped<StudentValidator>();

            }
            else if (aspNetCoreEnvironment.Equals(Settings.Environments.MusicStore.ToString()))
            {
                services.AddDbContext<MusicStoreDbContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<ArtistRepository>();

                services.AddScoped<ArtistValidator>();
            }

            //TODO: implement auth properly
            // Auth
            //services
            //    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            //    {
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireNonAlphanumeric = true;
            //        options.Password.RequireUppercase = true;
            //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
            //        options.Lockout.MaxFailedAccessAttempts = 5;
            //    })
            //    .AddEntityFrameworkStores<MusicStoreDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("TutorBusiness", new OpenApiInfo { Title = "Tutor Business", Version = "v1" });
                options.SwaggerDoc("MusicStore", new OpenApiInfo { Title = "Music Store", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                            UnresolvedReference = true
                        },
                        new List<string>()
                    }
                };

                options.AddSecurityRequirement(security);
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

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/TutorBusiness/swagger.json", "Tutor Business");
                options.SwaggerEndpoint("../swagger/MusicStore/swagger.json", "Music Store");
            });
        }
    }
}