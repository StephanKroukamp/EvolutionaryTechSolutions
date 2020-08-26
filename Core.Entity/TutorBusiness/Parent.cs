using System.Collections.Generic;

namespace Core.Entity.TutorBusiness
{
    public class Parent : IEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}