using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface IRecipeService
    {
        Task<int> Save(RecipeModel recipe);
        Task<RecipeModel> GetRecipe(int Id);
        Task<IEnumerable<RecipeModel>> GetRecipes();
        Task<int> Update(RecipeModel recipe);
        Task<ActionResult<int>> Delete(int id);
        bool RecipeExists(int id);
    }
}
