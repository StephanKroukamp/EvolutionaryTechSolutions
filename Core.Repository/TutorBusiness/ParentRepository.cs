using Core.Database.TutorBusiness;
using Core.Entity.TutorBusiness;

namespace Core.Repository.TutorBusiness
{
    public class ParentRepository : EfCoreRepository<Parent, TutorBusinessDbContext>
    {
        public ParentRepository(TutorBusinessDbContext context) : base(context)
        {

        }
    }
}