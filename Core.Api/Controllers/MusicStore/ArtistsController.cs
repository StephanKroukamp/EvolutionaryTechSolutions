using Core.Api.Validators.MusicStore;
using Core.Entity.MusicStore;
using Core.Repository.MusicStore;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.MusicStore
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : EfCoreController<Artist, ArtistRepository, ArtistValidator>
    {
        public ArtistsController(ArtistRepository repository, ArtistValidator validator) : base(repository, validator)
        {

        }
    }
}