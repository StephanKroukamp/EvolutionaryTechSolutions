namespace Core.Entity.MusicStore
{
    public class SongArtist : IEntity
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int ArtistId { get; set; }
    }
}