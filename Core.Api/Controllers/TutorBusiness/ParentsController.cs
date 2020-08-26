using Core.Api.Validators.TutorBusiness;
using Core.Entity.TutorBusiness;
using Core.Repository.TutorBusiness;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.TutorBusiness
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : EfCoreController<Parent, ParentRepository, ParentValidator>
    {
        public ParentsController(ParentRepository repository, ParentValidator validator) : base(repository, validator)
        {

        }
    }
}