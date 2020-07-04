using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public class CuisineRepository : ICuisineType
    {
        private readonly IZDBContext _context;

        public CuisineRepository(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                CuisineType cuisine = db.CuisineType.Find(id);
                if (cuisine == null)
                {
                    return 0;
                }

                db.CuisineType.Remove(cuisine);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<CuisineType> GetCuisine(int Id)
        {
            using (var db = _context)
            {
                return await(from c in db.CuisineType
                             where c.Id == Id
                             select c).FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<CuisineType>> GetCuisines()
        {
            using (var db = _context)
            {
                return await(from c in db.CuisineType select c).ToListAsync();
            }
        }

        public bool CuisineExists(int id)
        {
            using (var db = _context)
            {
                return db.CuisineType.Count(e => e.Id == id) > 0;
            }
        }

        public async Task<int> Save(CuisineType cuisine)
        {
            using (var db = _context)
            {
                db.CuisineType.Add(cuisine);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(CuisineType cuisine)
        {
            using (var db = _context)
            {
                db.Entry(cuisine).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuisineExists(cuisine.Id))
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


