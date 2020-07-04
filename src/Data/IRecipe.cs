using IndoriZaika.DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Data
{
    public interface IRecipe
    {
        Task<int> Save(Recipe recipe);
        Task<Recipe> GetRecipe(int Id);
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<int> Update(Recipe recipe);
        Task<ActionResult<int>> Delete(int id);
        bool RecipeExists(int id);
    }
}
