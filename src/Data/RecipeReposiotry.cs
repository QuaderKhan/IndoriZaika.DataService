using IndoriZaika.DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Data
{
    public class RecipeReposiotry : IRecipe
    {
        private readonly IZDBContext _context;
        public RecipeReposiotry(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Save(Recipe recipe)
        {
            using (var db = _context)
            {
                db.Recipe.Add(recipe);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<Recipe> GetRecipe(int Id)
        {
            using (var db = _context)
            {
                return await (from r in db.Recipe
                              where r.Id == Id
                              select r).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            using (var db = _context)
            {
                return await (from r in db.Recipe select r).ToListAsync();
            }
        }

        public async Task<int> Update(Recipe recipe)
        {
            using (var db = _context)
            {
                db.Entry(recipe).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
        public async Task<ActionResult<int>> Delete(int id)
        {
            using (var db = _context)
            {
                Recipe recipe = db.Recipe.Find(id);
                if (recipe == null)
                {
                    return 0;
                }

                db.Recipe.Remove(recipe);
                return await db.SaveChangesAsync();
            }
        }

        public bool RecipeExists(int id)
        {
            using (var db = _context)
            {
                return db.Recipe.Count(e => e.Id == id) > 0;
            }
        }

    }
}
