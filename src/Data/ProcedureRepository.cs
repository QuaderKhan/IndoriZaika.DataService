using IndoriZaika.DataService.Data;
using IndoriZaika.DataService.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indorizaika.Dataservice.Data
{
    public class ProcedureRepository : IProcedure
    {
        private readonly IZDBContext _context;
        public ProcedureRepository(IZDBContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            using (var db = _context)
            {
                Procedure procedure = db.Procedure.Find(id);
                if (procedure == null)
                {
                    return 0;
                }

                db.Procedure.Remove(procedure);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Procedure>> GetAllProcedures()
        {
            using (var db = _context)
            {
                return await (from p in db.Procedure select p).ToListAsync();
            }
        }

        public async Task<Procedure> GetProcedureForRecipe(int id)
        {
            using (var db = _context)
            {
                return await (from p in db.Procedure
                              where p.Id == id
                              select p).FirstOrDefaultAsync();
            }
        }

        public bool ProcedureExists(int id)
        {
            using (var db = _context)
            {
                return db.Procedure.Count(e => e.Id == id) > 0;
            }
        }

        public async Task<int> Save(Procedure procedure)
        {
            using (var db = _context)
            {
                db.Procedure.Add(procedure);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(Procedure procedure)
        {
            using (var db = _context)
            {
                db.Entry(procedure).State = EntityState.Modified;

                try
                {
                    return await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedureExists(procedure.Id))
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
