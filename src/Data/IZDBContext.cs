using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IndoriZaika.DataService.Entities;
using AutoMapper.Mappers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            builder.Entity<Recipe>(recipe =>
            {
                recipe.Property(c => c.CusineType).HasConversion(new EnumToStringConverter<EnumCuisineType>());
                recipe.Property(r => r.RecipeType).HasConversion(new EnumToStringConverter<EnumRecipeType>());                
            });
            builder.Entity<CuisineType>(cuisineType =>
            {
                cuisineType.Property(c => c.CusineType).HasConversion(new EnumToStringConverter<EnumCuisineType>());
                cuisineType.HasIndex(c => c.CusineType).IsUnique();
            });
            builder.Entity<RecipeType>(recipeType =>
            {
                recipeType.Property(r => r.Type).HasConversion(new EnumToStringConverter<EnumRecipeType>());
                recipeType.HasIndex(r => r.Type).IsUnique();
            });
            builder.Entity<RecipeDetail>();
            builder.Entity<Ingredients>();
            builder.Entity<Procedure>();
            builder.Entity<UserComments>();
        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<CuisineType> CuisineType { get; set; }
        public DbSet<RecipeType> RecipeType { get; set; }
        public DbSet<RecipeDetail> RecipeDetail { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<UserComments> UserComments { get; set; }

    }
}
