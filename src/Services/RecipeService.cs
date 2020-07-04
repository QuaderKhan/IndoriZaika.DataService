using AutoMapper;
using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipe _recipeRepository;
        private readonly IMapper _mapper;
        public RecipeService(IRecipe recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _recipeRepository.Delete(id);
        }

        public async Task<RecipeModel> GetRecipe(int id)
        {
            var recipe = await _recipeRepository.GetRecipe(id);
            var response = _mapper.Map<RecipeModel>(recipe);
            return response;
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var recipes = await _recipeRepository.GetRecipes();
            var response = _mapper.Map<IEnumerable<RecipeModel>>(recipes);
            return response;
        }

        public bool RecipeExists(int id)
        {
            return  _recipeRepository.RecipeExists(id);
        }

        public async Task<int> Save(RecipeModel recipe)
        {
            var recipeEntity = _mapper.Map<Recipe>(recipe);
            return await _recipeRepository.Save(recipeEntity);
        }

        public async Task<int> Update(RecipeModel recipe)
        {
            var recipeEntity = _mapper.Map<Recipe>(recipe);
            return await _recipeRepository.Update(recipeEntity);
        }
    }
}
