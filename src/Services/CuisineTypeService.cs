using AutoMapper;
using Indorizaika.Dataservice.Data;
using IndoriZaika.DataService.Entities;
using IndoriZaika.DataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class CuisineTypeService : ICuisineTypeService
    {
        private readonly ICuisineType _cuisineTypeRepository;
        private readonly IMapper _mapper;

        public CuisineTypeService(ICuisineType cuisineTypeRepository, IMapper mapper)
        {
            _cuisineTypeRepository = cuisineTypeRepository;
            _mapper = mapper;
        }

        public bool CuisineTypeExists(int id)
        {
            return _cuisineTypeRepository.CuisineExists(id);
        }

        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _cuisineTypeRepository.Delete(id);
        }

        public async Task<CuisineTypeModel> GetCuisineType(int id)
        {
            var cuisineType = await _cuisineTypeRepository.GetCuisine(id);
            var response = _mapper.Map<CuisineTypeModel>(cuisineType);
            return response;
        }

        public async Task<IEnumerable<CuisineTypeModel>> GetCuisineTypes()
        {
            var cuisineTypes = await _cuisineTypeRepository.GetCuisines();
            var response = _mapper.Map<IEnumerable<CuisineTypeModel>>(cuisineTypes);
            return response;
        }

        public async Task<int> Save(CuisineTypeModel cuisineType)
        {
            var recipeEntity = _mapper.Map<CuisineType>(cuisineType);
            return await _cuisineTypeRepository.Save(recipeEntity);
        }

        public async Task<int> Update(CuisineTypeModel cuisineType)
        {
            var recipeEntity = _mapper.Map<CuisineType>(cuisineType);
            return await _cuisineTypeRepository.Update(recipeEntity);
        }
    }
}
