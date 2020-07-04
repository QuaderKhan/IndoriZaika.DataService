using AutoMapper;
using Indorizaika.Dataservice.Data;
using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedure _procedureRepository;
        private readonly IMapper _mapper;
        public ProcedureService(IProcedure procedureRepository, IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _mapper = mapper;
        }
        public async Task<int> Delete(int id)
        {
            return await _procedureRepository.Delete(id);
        }

        public async Task<IEnumerable<ProcedureModel>> GetAllProcedures()
        {
            var procedures = await _procedureRepository.GetAllProcedures();
            var response = _mapper.Map<IEnumerable<ProcedureModel>>(procedures);
            return response;
        }

        public async Task<ProcedureModel> GetProcedureForRecipe(int id)
        {
            var procedure = await _procedureRepository.GetProcedureForRecipe(id);
            var response = _mapper.Map<ProcedureModel>(procedure);
            return response;
        }

        public bool ProcedureExists(int id)
        {
            return _procedureRepository.ProcedureExists(id);
        }

        public async Task<int> Save(ProcedureModel procedure)
        {
            var procedureEntity = _mapper.Map<Procedure>(procedure);
            return await _procedureRepository.Save(procedureEntity);
        }

        public async Task<int> Update(ProcedureModel procedure)
        {
            var procedureEntity = _mapper.Map<Procedure>(procedure);
            return await _procedureRepository.Update(procedureEntity);
        }
    }
}
