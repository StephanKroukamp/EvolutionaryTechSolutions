using Core.Entity.TutorBusiness;
using FluentValidation;

namespace Core.Api.Validators.TutorBusiness
{
    public class ParentValidator : AbstractValidator<Parent>
    {
        public ParentValidator()
        {
            RuleFor(parent => parent.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'FirstName' is required & must not be less than 50 characters");

            RuleFor(parent => parent.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'LastName' is required & must not be less than 50 characters");
        }
    }
}