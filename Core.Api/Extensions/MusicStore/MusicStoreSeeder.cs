using System.Collections.Generic;
using System.IO;
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

            if (!musicStoreDbContext.Artists.Any())
            {
                List<Artist> artists = new List<Artist>
                {
                    new Artist
                    {
                        Id = 1,
                        Title = "Kygo",
                        Description = "Whether behind the piano in his studio or headlining a sold-out festival, Kygo quietly reaffirms his status as a prodigious talent, forward-thinking producer, dynamic DJ, and influential global superstar. The Norwegian musician born Kyrre Gørvell-Dahll first introduced himself in 2013 and quietly became one of the most ubiquitous hitmakers in the world while emerging as Spotify’s “Breakout Artist of 2015.” “Firestone” ft. Conrad Sewell and “Stole the Show” ft. Parson James help cement Kygo as “the fastest artist to reach 1 billion streams on Spotify.” In the wake of his chart-topping 2016 full- length debut Cloud Nine, he delivered memorable performances on The Late Late Show with James Corden, Good Morning America, The Tonight Show Starring Jimmy Fallon, and The Ellen DeGeneres Show. Plus, he notably performed “Carry Me” during the Closing Ceremony of the Rio Olympics."
                    },
                    new Artist
                    {
                        Id = 2,
                        Title = "The Police",
                        Description = "Nominally, the Police were punk rock, but that's only in the loosest sense of the term. The trio's nervous, reggae-injected pop/rock was punky, but it wasn't necessarily punk. All three members were considerably more technically proficient than the average punk or new wave band.  had a precise guitar attack that created dense, interlocking waves of sounds and effects.  could play polyrhythms effortlessly. And , with his high, keening voice, was capable of constructing infectiously catchy pop songs. While they weren't punk, the Police certainly demonstrated that the punk spirit could have a future in pop music. As their career progressed, the Police grew considerably more adventurous, experimenting with jazz and various world musics. All the while, the band's tight delivery and mastery of the pop single kept their audience increasing, and by 1983, they were the most popular rock & roll band in the world. Though they were at the height of their fame, internal tensions caused the band to splinter apart in 1984, with  picking up the majority of the band's audience to become an international superstar."
                    },
                    new Artist
                    {
                        Id = 3,
                        Title = "Biffy Clyro",
                        Description = "Known for their anthemic alt-rock, Scotland's Biffy Clyro are a dynamic power trio marked by the throaty lead-vocal brogue of singer/guitarist Simon Neil. Emerging in the early 2000s, Biffy Clyro drew loyal fans with their grunge, hardcore, and prog-rock-influenced sound that found them combining hooky choruses with unusual song forms and galloping rhythmic meters. While their early albums helped build their fan base in Great Britain, they broke through to an international audience with 2009's Only Revolutions, which peaked at number three on the U.K. album charts and earned a Mercury Prize nomination. The band continued to experiment, issuing the double-disc Opposites in 2013 and the soundtrack album Balance, Not Symmetry in 2019."
                    }
                };

                musicStoreDbContext.Artists.AddRange(artists);
            }

            musicStoreDbContext.SaveChanges();
        }
    }
}