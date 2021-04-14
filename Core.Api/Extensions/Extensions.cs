using System.Collections.Generic;
using System.Linq;
using Core.Api.Settings;
using Core.Database.MusicStore;
using Core.Database.TutorBusiness;
using Core.Entity.MusicStore;
using Core.Entity.TutorBusiness;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Extensions
{
    public static class Extensions
    {
        public static void Seed(this IApplicationBuilder app, string aspNetCoreEnvironment)
        {
            IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            if (aspNetCoreEnvironment.Equals(Environments.TutorBusiness))
            {
                TutorBusinessDbContext tutorBusinessDbContext = serviceScope.ServiceProvider.GetService<TutorBusinessDbContext>();

                if (!tutorBusinessDbContext.Parents.Any())
                {
                    List<Parent> parents = new List<Parent>
                    {
                        new Parent { Id = 1, FirstName = "Stephanus", LastName = "Kroukamp", Students = null }
                    };

                    tutorBusinessDbContext.Parents.AddRange(parents);

                    tutorBusinessDbContext.SaveChanges();
                }
            }
            else if (aspNetCoreEnvironment.Equals(Environments.MusicStore))
            {
                MusicStoreDbContext musicStoreDbContext = serviceScope.ServiceProvider.GetService<MusicStoreDbContext>();

                if (!musicStoreDbContext.Artists.Any())
                {
                    List<Artist> artists = new List<Artist>
                    {
                        new Artist { Id = 1, Name = "Camel Power Club", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 2, Name = "Mind Against", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 3, Name = "Tale Of Us", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 4, Name = "Lamb Of God", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 5, Name = "Bring Me The Horizon", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 6, Name = "Architects", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 7, Name = "Parkway Drive", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 8, Name = "Pink Floyd", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 9, Name = "Kygo", CoverArt = "https://picsum.photos/seed/picsum/300/300" },
                        new Artist { Id = 10, Name = "Ry X", CoverArt = "https://picsum.photos/seed/picsum/300/300" }
                    };

                    musicStoreDbContext.Artists.AddRange(artists);

                    musicStoreDbContext.SaveChanges();
                }
            }
        }
    }
}