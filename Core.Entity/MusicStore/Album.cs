namespace Core.Entity.MusicStore
{
    public class Album : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }
    }
}