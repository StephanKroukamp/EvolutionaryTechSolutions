namespace Core.Entity.MusicStore
{
    public class Song : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}