using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Indorizaika.Dataservice.Data
{
    public class RecipeTypeRepository : IRecipeType
    {
        private readonly IZDBContext _context;

        public RecipeTypeRepository(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                RecipeType recipeType = db.RecipeType.Find(id);
                if (recipeType == null)
                {
                    return 0;
                }

                db.RecipeType.Remove(recipeType);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<RecipeType> GetRecipeType(int id)
        {
            using (var db = _context)
            {
                return await (from c in db.RecipeType
                              where c.Id == id
                              select c).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<RecipeType>> GetRecipeTypes()
        {
            using (var db = _context)
            {
                return await (from c in db.RecipeType select c).ToListAsync();
            }
        }

        public bool RecipeTypeExists(int id)
        {
            using (var db = _context)
            {
                return db.RecipeType.Count(e => e.Id == id) > 0;
            }
        }

        public async Task<int> Save(RecipeType recipeType)
        {
            using (var db = _context)
            {
                db.RecipeType.Add(recipeType);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(RecipeType recipeType)
        {
            using (var db = _context)
            {
                db.Entry(recipeType).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeTypeExists(recipeType.Id))
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
    }
}

