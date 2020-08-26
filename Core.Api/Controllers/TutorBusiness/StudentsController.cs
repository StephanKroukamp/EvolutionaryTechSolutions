using Core.Api.Validators.TutorBusiness;
using Core.Entity.TutorBusiness;
using Core.Repository.TutorBusiness;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.TutorBusiness
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : EfCoreController<Student, StudentRepository, StudentValidator>
    {
        public StudentsController(StudentRepository repository, StudentValidator validator) : base(repository, validator)
        {

        }
    }
}