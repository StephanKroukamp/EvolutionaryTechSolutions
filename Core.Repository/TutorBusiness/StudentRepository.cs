using Core.Database.TutorBusiness;
using Core.Entity.TutorBusiness;

namespace Core.Repository.TutorBusiness
{
    public class StudentRepository : EfCoreRepository<Student, TutorBusinessDbContext>
    {
        public StudentRepository(TutorBusinessDbContext context) : base(context)
        {

        }
    }
}