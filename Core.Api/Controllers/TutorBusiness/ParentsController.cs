using Core.Entity.TutorBusiness;
using Core.Repository.TutorBusiness;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.TutorBusiness
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : EfCoreController<Parent, ParentRepository>
    {
        public ParentsController(ParentRepository repository) : base(repository)
        {

        }
    }
}