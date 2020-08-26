using Core.Entity.TutorBusiness;
using Core.Repository.TutorBusiness;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.TutorBusiness
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : EfCoreController<Student, StudentRepository>
    {
        public StudentsController(StudentRepository repository) : base(repository)
        {

        }
    }
}