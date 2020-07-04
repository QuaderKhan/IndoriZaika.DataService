using IndoriZaika.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface IIngredients
    {
        Task<int> Save(Ingredients ingredients);
        Task<Ingredients> GetIngredientsForRecipe(int id);
        Task<IEnumerable<Ingredients>> GetAllIngredients();
        Task<int> Update(Ingredients ingredients);
        Task<int> Delete(int id);
        bool IngredientsExists(int id);
    }
}
