namespace Core.Entity.MusicStore
{
    public class CategoryPlaylist : IEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int PlaylistId { get; set; }
    }
}