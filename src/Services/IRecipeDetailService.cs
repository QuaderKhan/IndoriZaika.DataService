using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface IRecipeDetailService
    {
        Task<int> Save(RecipeDetailModel recipeDetail);
        Task<RecipeDetailModel> GetRecipeDetail(int Id);
        Task<IEnumerable<RecipeDetailModel>> GetRecipeDetails();
        Task<int> Update(RecipeDetailModel recipeDetail);
        Task<int> Delete(int id);
        bool RecipeDetailExists(int id);
    }
}
