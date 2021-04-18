using Core.Entity.MusicStore;
using FluentValidation;

namespace Core.Api.Validators.MusicStore
{
    public class ArtistValidator : AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(artist => artist.Title)
                .NotEmpty()
                .WithMessage("'Title' is required");

            RuleFor(artist => artist.Description)
                .NotEmpty()
                .WithMessage("'Description' is required");
        }
    }
}