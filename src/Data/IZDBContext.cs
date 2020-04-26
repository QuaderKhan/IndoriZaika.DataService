using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IndoriZaika.DataService.Models;

namespace IndoriZaika.DataService.Data
{
    public class IZDBContext : DbContext
    {

        public IZDBContext() : base()
        {
            
        }
        public IZDBContext(DbContextOptions<IZDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Recipe> Recipe { get; set; }
    }
}
