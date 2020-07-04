using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface IProcedureService
    {
        Task<int> Save(ProcedureModel procedure);
        Task<ProcedureModel> GetProcedureForRecipe(int id);
        Task<IEnumerable<ProcedureModel>> GetAllProcedures();
        Task<int> Update(ProcedureModel procedure);
        Task<int> Delete(int id);
        bool ProcedureExists(int id);
    }
}
