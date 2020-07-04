using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public class RecipeDetailRepository : IRecipeDetail
    {
        private readonly IZDBContext _context;
        public RecipeDetailRepository(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                RecipeDetail recipeDetail = db.RecipeDetail.Find(id);
                if (recipeDetail == null)
                {
                    return 0;
                }

                db.RecipeDetail.Remove(recipeDetail);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<RecipeDetail> GetRecipeDetail(int Id)
        {
            using (var db = _context)
            {
                return await(from r in db.RecipeDetail
                             where r.Id == Id
                             select r).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<RecipeDetail>> GetRecipeDetails()
        {
            using (var db = _context)
            {
                return await(from c in db.RecipeDetail select c).ToListAsync();
            }
        }

        public bool RecipeDetailExists(int id)
        {
            using (var db = _context)
            {
                return db.RecipeDetail.Count(e => e.Id == id) > 0;
            }
        }

        public async Task<int> Save(RecipeDetail recipeDetail)
        {
            using (var db = _context)
            {
                db.RecipeDetail.Add(recipeDetail);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(RecipeDetail recipeDetail)
        {
            using (var db = _context)
            {
                db.Entry(recipeDetail).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeDetailExists(recipeDetail.Id))
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
