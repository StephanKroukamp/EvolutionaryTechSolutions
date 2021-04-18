namespace Core.Entity.MusicStore
{
    public class CategoryAlbum : IEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int AlbumId { get; set; }
    }
}