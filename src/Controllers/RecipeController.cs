using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IndoriZaika.DataService.Entities;
using IndoriZaika.DataService.Models;
using Swashbuckle.Swagger.Annotations;
using Indorizaika.Dataservice.Services;

namespace IndoriZaika.DataService.Controllers
{
    [Route("izdbapi/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/Recipes
        [HttpGet]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            //return await _context.Recipe.ToListAsync();
            return await _recipeService.GetRecipes();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        [SwaggerResponse(200, "Object representing model for your income view.")]
        [SwaggerResponse(400, Description = "Invalid id.")]
        [SwaggerResponse(404, Description = "Application not found.")]
        [SwaggerResponse(500, Description = "An unexpected fault happened. Try again later.")]
        public async Task<ActionResult<RecipeModel>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> PutRecipe(int id, RecipeModel recipeModel)
        {
            if (id != recipeModel.Id)
            {
                return BadRequest();
            }

            return await _recipeService.Update(recipeModel);
        }

        // POST: api/Recipes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RecipeModel>> PostRecipe(RecipeModel recipeModel)
        {
            await _recipeService.Save(recipeModel);

            return CreatedAtAction("GetRecipe", new { id = recipeModel.Id }, recipeModel);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRecipe(int id)
        {
            return await _recipeService.Delete(id);
        }

        private bool RecipeExists(int id)
        {
            return _recipeService.RecipeExists(id);
        }
    }
}
