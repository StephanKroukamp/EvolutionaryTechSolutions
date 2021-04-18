namespace Core.Entity.MusicStore
{
    public class CategoryArtist : IEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int ArtistId { get; set; }
    }
}