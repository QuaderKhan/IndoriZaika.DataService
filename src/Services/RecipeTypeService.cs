using AutoMapper;
using Indorizaika.Dataservice.Data;
using IndoriZaika.DataService.Entities;
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class RecipeTypeService : IRecipeTypeService
    {
        private readonly IRecipeType _recipeTypeRepository;
        private readonly IMapper _mapper;

        public RecipeTypeService(IRecipeType recipeTypeRepository, IMapper mapper)
        {
            _recipeTypeRepository = recipeTypeRepository;
            _mapper = mapper;
        }

        public bool RecipeTypeExists(int id)
        {
            return _recipeTypeRepository.RecipeTypeExists(id);
        }

        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _recipeTypeRepository.Delete(id);
        }

        public async Task<RecipeTypeModel> GetRecipeType(int id)
        {
            var recipeType = await _recipeTypeRepository.GetRecipeType(id);
            var response = _mapper.Map<RecipeTypeModel>(recipeType);
            return response;
        }

        public async Task<IEnumerable<RecipeTypeModel>> GetRecipeTypes()
        {
            var recipeTypes = await _recipeTypeRepository.GetRecipeTypes();
            var response = _mapper.Map<IEnumerable<RecipeTypeModel>>(recipeTypes);
            return response;
        }

        public async Task<int> Save(RecipeTypeModel recipeType)
        {
            var recipeTypeEntity = _mapper.Map<RecipeType>(recipeType);
            return await _recipeTypeRepository.Save(recipeTypeEntity);
        }

        public async Task<int> Update(RecipeTypeModel recipeType)
        {
            var recipeTypeEntity = _mapper.Map<RecipeType>(recipeType);
            return await _recipeTypeRepository.Update(recipeTypeEntity);
        }
    }
}
