using IndoriZaika.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface IRecipeDetail
    {
        Task<int> Save(RecipeDetail recipeDetail);
        Task<RecipeDetail> GetRecipeDetail(int Id);
        Task<IEnumerable<RecipeDetail>> GetRecipeDetails();
        Task<int> Update(RecipeDetail recipeDetail);
        Task<int> Delete(int id);
        bool RecipeDetailExists(int id);
    }
}
