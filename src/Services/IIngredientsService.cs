using indorizaikaDataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
   public interface IIngredientsService
    {
        Task<int> Save(IngredientsModel ingredients);
        Task<IngredientsModel> GetIngredientsForRecipe(int id);
        Task<IEnumerable<IngredientsModel>> GetAllIngredients();
        Task<int> Update(IngredientsModel ingredients);
        Task<int> Delete(int id);
        bool IngredientsExists(int id);
    }
}
