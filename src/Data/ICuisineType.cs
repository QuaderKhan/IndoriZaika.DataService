using IndoriZaika.DataService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface ICuisineType
    {
        Task<int> Save(CuisineType cuisine);
        Task<CuisineType> GetCuisine(int Id);
        Task<IEnumerable<CuisineType>> GetCuisines();
        Task<int> Update(CuisineType cuisine);
        Task<int> Delete(int id);
        bool CuisineExists(int id);
    }
}
