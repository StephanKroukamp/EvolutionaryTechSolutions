using Core.Entity.TutorBusiness;
using FluentValidation;

namespace Core.Api.Validators.TutorBusiness
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'FirstName' is required & must not be less than 50 characters");

            RuleFor(student => student.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'LastName' is required & must not be less than 50 characters");
        }
    }
}