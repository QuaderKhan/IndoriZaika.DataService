using IndoriZaika.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface IProcedure
    {
        Task<int> Save(Procedure procedure);
        Task<Procedure> GetProcedureForRecipe(int id);
        Task<IEnumerable<Procedure>> GetAllProcedures();
        Task<int> Update(Procedure procedure);
        Task<int> Delete(int id);
        bool ProcedureExists(int id);
    }
}
