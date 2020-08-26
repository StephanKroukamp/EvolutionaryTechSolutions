namespace Core.Entity.TutorBusiness
{
    public class Student : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }
    }
}