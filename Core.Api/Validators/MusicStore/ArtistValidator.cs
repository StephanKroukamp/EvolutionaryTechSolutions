using Core.Entity.MusicStore;
using FluentValidation;

namespace Core.Api.Validators.MusicStore
{
    public class ArtistValidator : AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(artist => artist.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("'Name' is required & must not be less than 50 characters");

            RuleFor(artist => artist.CoverArt)
                .NotEmpty()
                .WithMessage("'CoverArt' is required");
        }
    }
}