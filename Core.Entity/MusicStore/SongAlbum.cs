namespace Core.Entity.MusicStore
{
    public class SongAlbum : IEntity
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int AlbumId { get; set; }
    }
}