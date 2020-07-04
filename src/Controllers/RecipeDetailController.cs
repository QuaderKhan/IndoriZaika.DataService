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
    public class RecipeDetialController : ControllerBase
    {
        private readonly IRecipeDetailService _recipeDetailService;

        public RecipeDetialController(IRecipeDetailService recipeDetailService)
        {
            _recipeDetailService = recipeDetailService;
        }

        // GET: api/<RecipeDetailController>
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<RecipeDetailModel>> Get()
        {
            return await _recipeDetailService.GetRecipeDetails();
        }

        // GET api/<RecipeDetailController>/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<RecipeDetailModel>> Get(int id)
        {
            var recipeDetail = await _recipeDetailService.GetRecipeDetail(id);

            if (recipeDetail == null)
            {
                return NotFound();
            }

            return recipeDetail;
        }

        // POST api/<RecipeDetailController>
        [HttpPost]
        public async Task<ActionResult<RecipeDetailModel>> Post(RecipeDetailModel recipeDetailModel)
        {
            await _recipeDetailService.Save(recipeDetailModel);

            return CreatedAtAction("Get", new { id = recipeDetailModel.Id }, recipeDetailModel);
        }

        // PUT api/<RecipeDetailController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, [FromBody] RecipeDetailModel recipeDetailModel)
        {
            if (id != recipeDetailModel.Id)
            {
                return BadRequest();
            }

            return await _recipeDetailService.Update(recipeDetailModel);
        }

        // DELETE api/<RecipeDetailController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _recipeDetailService.Delete(id);
        }
    }
}
