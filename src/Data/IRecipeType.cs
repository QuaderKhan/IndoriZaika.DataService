using IndoriZaika.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface IRecipeType
    {
        Task<int> Save(RecipeType recipeType);
        Task<RecipeType> GetRecipeType(int Id);
        Task<IEnumerable<RecipeType>> GetRecipeTypes();
        Task<int> Update(RecipeType recipeType);
        Task<int> Delete(int id);
        bool RecipeTypeExists(int id);
    }
}
