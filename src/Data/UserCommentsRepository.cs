using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public class UserCommentsRepository : IUserComments
    {
        private readonly IZDBContext _context;
        public UserCommentsRepository(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                UserComments userComments = db.UserComments.Find(id);
                if (userComments == null)
                {
                    return 0;
                }

                db.UserComments.Remove(userComments);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserComments>> GetAllUserComments()
        {
            using (var db = _context)
            {
                return await (from u in db.UserComments select u).ToListAsync();
            }
        }

        public async Task<UserComments> GetUserCommentsForRecipe(int id)
        {
            using (var db = _context)
            {
                return await (from u in db.UserComments
                              where u.Id == id
                              select u).FirstOrDefaultAsync();
            }
        }

        public async Task<int> Save(UserComments userComments)
        {
            using (var db = _context)
            {
                db.UserComments.Add(userComments);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(UserComments userComments)
        {
            using (var db = _context)
            {
                db.Entry(userComments).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCommentsExists(userComments.Id))
                    {
                        throw;
                    }
                    else
                    {
                        throw;
                    }
                }

            }
        }

        public bool UserCommentsExists(int id)
        {
            using (var db = _context)
            {
                return db.UserComments.Count(e => e.Id == id) > 0;
            }
        }
    }
}
