namespace Core.Entity.MusicStore
{
    public class SongPlaylist : IEntity
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int PlaylistId { get; set; }
    }
}