using IndoriZaika.DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Data
{
    public class IZDataAccess
    {
        
        public void Save(Recipe recipe)
        {
            using (var db = new IZDBContext())
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();
            }
        }

        public Recipe GetRecipe(int Id)
        {
            using (var db = new IZDBContext())
            {
                return (from r in db.Recipe
                        where r.Id == Id
                        select r).FirstOrDefault();
            }
        }

        public IList<Recipe> GetRecipes()
        {
            using (var db = new IZDBContext())
            {
                return (from r in db.Recipe
                        select r).ToList<Recipe>();
            }

        }

        public void Update(Recipe recipe)
        {
            using (var db = new IZDBContext())
            {
                db.Entry(recipe).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
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

        public bool Delete(int id)
        {
            using (var db = new IZDBContext())
            {
                Recipe recipe = db.Recipe.Find(id);
                if (recipe == null)
                {
                    return false;
                }

                db.Recipe.Remove(recipe);
                db.SaveChanges();

                return true;
            }
        }

        public bool RecipeExists(int id)
        {
            using (var db = new IZDBContext())
            {
                return db.Recipe.Count(e => e.Id == id) > 0;
            }
        }
    }
}
