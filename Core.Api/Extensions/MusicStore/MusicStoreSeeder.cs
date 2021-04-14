using System.Collections.Generic;
using System.Linq;
using Core.Database.MusicStore;
using Core.Entity.MusicStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Api.Extensions.MusicStore
{
    public static class MusicStoreSeeder
    {
        public static void SeedMusicStore(this IApplicationBuilder app)
        {
            IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            MusicStoreDbContext musicStoreDbContext = serviceScope.ServiceProvider.GetService<MusicStoreDbContext>();

            if (musicStoreDbContext.Artists.Any())
            {
                return;
            }

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