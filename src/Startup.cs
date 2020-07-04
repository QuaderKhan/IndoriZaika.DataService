using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using IndoriZaika.DataService.Data;
using Microsoft.OpenApi.Models;
using Indorizaika.Dataservice.Services;
using AutoMapper;
using Indorizaika.Dataservice.Data;
using Autofac.Core;

namespace IndoriZaika.DataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<IZDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IndoriZaikaDBConnectionString"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    }));

            #region Injections
            services.AddTransient<IRecipe, RecipeReposiotry>();
            services.AddTransient<ICuisineType, CuisineRepository>();
            services.AddTransient<IRecipeType, RecipeTypeRepository>();
            services.AddTransient<IRecipeDetail, RecipeDetailRepository>();
            services.AddTransient<IProcedure, ProcedureRepository>();
            services.AddTransient<IIngredients, IngredientsRepository>();
            services.AddTransient<IUserComments, UserCommentsRepository>();

            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<ICuisineTypeService, CuisineTypeService>();
            services.AddTransient<IRecipeTypeService, RecipeTypeService>();
            services.AddTransient<IRecipeDetailService, RecipeDetailService>();
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IIngredientsService, IngredientsService>();
            services.AddTransient<IUserCommentsService, UserCommentsService>();

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IndoriZaika Data API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup)); // Added Automapper

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IZDBContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IndoriZaika Data API V1");
            });


        }
    }
}
