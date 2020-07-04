using AutoMapper;
using Indorizaika.Dataservice.Data;
using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredients _ingredientsRepository;
        private readonly IMapper _mapper;

        public IngredientsService(IIngredients ingredientsRepository, IMapper mapper)
        {
            _ingredientsRepository = ingredientsRepository;
            _mapper = mapper;
        }
        public async Task<int> Delete(int id)
        {
            return await _ingredientsRepository.Delete(id);
        }

        public async Task<IEnumerable<IngredientsModel>> GetAllIngredients()
        {
            var ingredients = await _ingredientsRepository.GetAllIngredients();
            var response = _mapper.Map<IEnumerable<IngredientsModel>>(ingredients);
            return response;
        }

        public async Task<IngredientsModel> GetIngredientsForRecipe(int id)
        {
            var ingredients = await _ingredientsRepository.GetIngredientsForRecipe(id);
            var response = _mapper.Map<IngredientsModel>(ingredients);
            return response;
        }

        public bool IngredientsExists(int id)
        {
            return _ingredientsRepository.IngredientsExists(id);
        }

        public async Task<int> Save(IngredientsModel ingredients)
        {
            var ingredientsEntity = _mapper.Map<Ingredients>(ingredients);
            return await _ingredientsRepository.Save(ingredientsEntity);
        }

        public async Task<int> Update(IngredientsModel ingredients)
        {
            var ingredientsEntity = _mapper.Map<Ingredients>(ingredients);
            return await _ingredientsRepository.Update(ingredientsEntity);
        }
    }
}
