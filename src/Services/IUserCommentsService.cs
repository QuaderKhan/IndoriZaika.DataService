using IndoriZaika.DataService.Entities;
using indorizaikaDataService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Services
{
    public interface IUserCommentsService
    {
        Task<int> Save(UserCommentsModel userComments);
        Task<UserCommentsModel> GetUserCommentsForRecipe(int Id);
        Task<IEnumerable<UserCommentsModel>> GetAllUserComments();
        Task<int> Update(UserCommentsModel userComments);
        Task<int> Delete(int id);
        bool UserCommentsExists(int id);
    }
}
