using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indorizaika.Dataservice.Services;
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IndoriZaika.DataService.Controllers
{
    [Route("izdbapi/[controller]")]
    [ApiController]
    public class RecipeTypeController : ControllerBase
    {
        private readonly IRecipeTypeService _recipeTypeService;

        public RecipeTypeController(IRecipeTypeService recipeTypeService)
        {
            _recipeTypeService = recipeTypeService;
        }

        // GET: api/<RecipeTypeController>
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<RecipeTypeModel>> Get()
        {
            return await _recipeTypeService.GetRecipeTypes();
        }

        // GET api/<RecipeTypeController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<RecipeTypeModel>> Get(int id)
        {
            var recipeType = await _recipeTypeService.GetRecipeType(id);

            if (recipeType == null)
            {
                return NotFound();
            }

            return recipeType;
        }

        // POST api/<RecipeTypeController>
        [HttpPost]
        public async Task<ActionResult<RecipeTypeModel>> Post(RecipeTypeModel recipeTypeModel)
        {
            await _recipeTypeService.Save(recipeTypeModel);

            return CreatedAtAction("Get", new { id = recipeTypeModel.Id }, recipeTypeModel);
        }

        // PUT api/<RecipeTypeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] RecipeTypeModel recipeTypeModel)
        {
            if (id != recipeTypeModel.Id)
            {
                return BadRequest();
            }

            return await _recipeTypeService.Update(recipeTypeModel);
        }

        // DELETE api/<RecipeTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _recipeTypeService.Delete(id);
        }
    }
}
