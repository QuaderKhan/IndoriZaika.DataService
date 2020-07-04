using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public class IngredientsRepository : IIngredients
    {
        private readonly IZDBContext _context;

        public IngredientsRepository(IZDBContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                Ingredients ingredients = db.Ingredients.Find(id);
                if (ingredients == null)
                {
                    return 0;
                }

                db.Ingredients.Remove(ingredients);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ingredients>> GetAllIngredients()
        {
            using (var db = _context)
            {
                return await (from c in db.Ingredients select c).ToListAsync();
            }
        }

        public async Task<Ingredients> GetIngredientsForRecipe(int id)
        {
            using (var db = _context)
            {
                return await(from i in db.Ingredients
                             where i.Id == id
                             select i).FirstOrDefaultAsync();
            }
        }

        public bool IngredientsExists(int id)
        {
            using (var db = _context)
            {
                return db.Ingredients.Count(e => e.Id == id) > 0;
            }
        }

        public async Task<int> Save(Ingredients ingredients)
        {
            using (var db = _context)
            {
                db.Ingredients.Add(ingredients);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(Ingredients ingredients)
        {
            using (var db = _context)
            {
                db.Entry(ingredients).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientsExists(ingredients.Id))
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
