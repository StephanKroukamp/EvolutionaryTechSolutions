using Core.Database.MusicStore;
using Core.Entity.MusicStore;

namespace Core.Repository.MusicStore
{
    public class ArtistRepository : EfCoreRepository<Artist, MusicStoreDbContext>
    {
        public ArtistRepository(MusicStoreDbContext context) : base(context)
        {

        }
    }
}