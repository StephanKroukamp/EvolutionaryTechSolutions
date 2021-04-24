using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Database.MusicStore;
using Core.Database.MusicStore.Entities;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.Api.MusicStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistRepository artistRepository;

        public ArtistsController(ArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> Post([FromBody] Artist artist)
        {
            WriteResult writeResult = await artistRepository.AddAsync(artist);

            return new JsonResult(JsonConvert.SerializeObject(writeResult));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> Get()
        {
            return await artistRepository.Get();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<TEntity>> Get(int id)
        //{
        //    var entity = await artistRepository.Get(id, true);

        //    if (entity is null)
        //    {
        //        return NotFound();
        //    }

        //    return entity;
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, TEntity entity)
        //{
        //    var validationResult = await validator.ValidateAsync(entity);

        //    if (!validationResult.IsValid)
        //    {
        //        return BadRequest(validationResult.Errors); // this needs refining
        //    }

        //    entity.Id = id;

        //    await artistRepository.Update(entity);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TEntity>> Delete(int id)
        //{
        //    var entity = await artistRepository.Delete(id);

        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }

        //    return entity;
        //}
    }
}