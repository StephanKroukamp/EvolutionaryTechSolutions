namespace Core.Entity.MusicStore
{
    public class CategorySong : IEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int SongId { get; set; }
    }
}