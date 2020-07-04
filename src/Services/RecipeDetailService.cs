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
    public class RecipeDetailService : IRecipeDetailService
    {
        private readonly IRecipeDetail _recipeDetailRepository;
        private readonly IMapper _mapper;
        public RecipeDetailService(IRecipeDetail recipeDetailRepository, IMapper mapper)
        {
            _recipeDetailRepository = recipeDetailRepository;
            _mapper = mapper;
        }
        public async Task<int> Delete(int id)
        {
            return await _recipeDetailRepository.Delete(id);
        }

        public async Task<RecipeDetailModel> GetRecipeDetail(int id)
        {
            var recipeDetail = await _recipeDetailRepository.GetRecipeDetail(id);
            var response = _mapper.Map<RecipeDetailModel>(recipeDetail);
            return response;
        }

        public async Task<IEnumerable<RecipeDetailModel>> GetRecipeDetails()
        {
            var recipeDetails = await _recipeDetailRepository.GetRecipeDetails();
            var response = _mapper.Map<IEnumerable<RecipeDetailModel>>(recipeDetails);
            return response;
        }

        public bool RecipeDetailExists(int id)
        {
            return _recipeDetailRepository.RecipeDetailExists(id);
        }

        public async Task<int> Save(RecipeDetailModel recipeDetail)
        {
            var recipeDetailEntity = _mapper.Map<RecipeDetail>(recipeDetail);
            return await _recipeDetailRepository.Save(recipeDetailEntity);
        }

        public async Task<int> Update(RecipeDetailModel recipeDetail)
        {
            var recipeDetailEntity = _mapper.Map<RecipeDetail>(recipeDetail);
            return await _recipeDetailRepository.Update(recipeDetailEntity);
        }
    }
}
