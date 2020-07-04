using AutoMapper;
using Indorizaika.Dataservice.Data;
using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public class UserCommentsService : IUserCommentsService
    {
        private readonly IUserComments _userCommentsRepository;
        private readonly IMapper _mapper;
        public UserCommentsService(IUserComments userCommentsRepository, IMapper mapper)
        {
            _userCommentsRepository = userCommentsRepository;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _userCommentsRepository.Delete(id);
        }

        public async Task<IEnumerable<UserCommentsModel>> GetAllUserComments()
        {
            var userComments = await _userCommentsRepository.GetAllUserComments();
            var response = _mapper.Map<IEnumerable<UserCommentsModel>>(userComments);
            return response;
        }

        public async Task<UserCommentsModel> GetUserCommentsForRecipe(int id)
        {
            var userCommentsForRecipe = await _userCommentsRepository.GetUserCommentsForRecipe(id);
            var response = _mapper.Map<UserCommentsModel>(userCommentsForRecipe);
            return response;
        }

        public async Task<int> Save(UserCommentsModel userComments)
        {
            var userCommentsEntity = _mapper.Map<UserComments>(userComments);
            return await _userCommentsRepository.Save(userCommentsEntity);
        }

        public async Task<int> Update(UserCommentsModel userComments)
        {
            var userCommentsEntity = _mapper.Map<UserComments>(userComments);
            return await _userCommentsRepository.Update(userCommentsEntity);
        }

        public bool UserCommentsExists(int id)
        {
            return _userCommentsRepository.UserCommentsExists(id);
        }
    }
}
