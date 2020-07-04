
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface IRecipeTypeService
    {
        Task<int> Save(RecipeTypeModel recipeType);
        Task<RecipeTypeModel> GetRecipeType(int Id);
        Task<IEnumerable<RecipeTypeModel>> GetRecipeTypes();
        Task<int> Update(RecipeTypeModel recipeType);
        Task<ActionResult<int>> Delete(int id);
        bool RecipeTypeExists(int id);
    }
}
