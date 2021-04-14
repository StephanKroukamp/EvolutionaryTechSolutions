using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;
using Core.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EfCoreController<TEntity, TRepository, TValidator> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : class, IRepository<TEntity>
        where TValidator : AbstractValidator<TEntity>
    {
        private readonly TRepository repository;

        private readonly TValidator validator;

        public EfCoreController(TRepository repository, TValidator validator)
        {
            this.repository = repository;

            this.validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            var validationResult = await validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors); // this needs refining
            }

            await repository.Add(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.Get(true);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await repository.Get(id, true);

            if (entity is null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            var validationResult = await validator.ValidateAsync(entity);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors); // this needs refining
            }

            entity.Id = id;

            await repository.Update(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await repository.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}