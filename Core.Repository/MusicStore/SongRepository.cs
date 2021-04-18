using Core.Database.MusicStore;
using Core.Entity.MusicStore;

namespace Core.Repository.MusicStore
{
    public class SongRepository : EfCoreRepository<Song, MusicStoreDbContext>
    {
        public SongRepository(MusicStoreDbContext context) : base(context)
        {

        }
    }
}