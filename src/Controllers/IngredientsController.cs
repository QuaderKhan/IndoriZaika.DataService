using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indorizaika.Dataservice.Services;
using IndoriZaika.DataService.Models;
using indorizaikaDataService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndoriZaika.DataService.Controllers
{
    [Route("izdbapi/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService _ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        // GET: api/<IngredientsController>
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<IngredientsModel>> Get()
        {
            return await _ingredientsService.GetAllIngredients();
        }

        // GET api/<IngredientsController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<IngredientsModel>> Get(int id)
        {
            var ingredientsForRecipe = await _ingredientsService.GetIngredientsForRecipe(id);

            if (ingredientsForRecipe == null)
            {
                return NotFound();
            }

            return ingredientsForRecipe;
        }

        // POST api/<IngredientsController>
        [HttpPost]
        public async Task<ActionResult<IngredientsModel>> Post(IngredientsModel ingredientsModel)
        {
            await _ingredientsService.Save(ingredientsModel);

            return CreatedAtAction("Get", new { id = ingredientsModel.Id }, ingredientsModel);
        }

        // PUT api/<IngredientsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] IngredientsModel ingredientsModel)
        {
            if (id != ingredientsModel.Id)
            {
                return BadRequest();
            }

            return await _ingredientsService.Update(ingredientsModel);
        }

        // DELETE api/<CuisineTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _ingredientsService.Delete(id);
        }
    }
}
