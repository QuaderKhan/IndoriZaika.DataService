
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface ICuisineTypeService
    {
        Task<int> Save(CuisineTypeModel cuisineType);
        Task<CuisineTypeModel> GetCuisineType(int Id);
        Task<IEnumerable<CuisineTypeModel>> GetCuisineTypes();
        Task<int> Update(CuisineTypeModel cuisineType);
        Task<ActionResult<int>> Delete(int id);
        bool CuisineTypeExists(int id);
    }
}
