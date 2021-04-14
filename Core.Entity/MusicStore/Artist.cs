namespace Core.Entity.MusicStore
{
    public class Artist : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CoverArt { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
    }
}