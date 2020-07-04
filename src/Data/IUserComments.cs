using IndoriZaika.DataService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public interface IUserComments
    {
        Task<int> Save(UserComments userComments);
        Task<UserComments> GetUserCommentsForRecipe(int Id);
        Task<IEnumerable<UserComments>> GetAllUserComments();
        Task<int> Update(UserComments userComments);
        Task<int> Delete(int id);
        bool UserCommentsExists(int id);
    }
}
