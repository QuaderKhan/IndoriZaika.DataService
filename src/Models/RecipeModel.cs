using IndoriZaika.DataService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EnumCuisineType CuisineType { get; set; }
        public EnumRecipeType RecipeType { get; set; }
        public string Description { get; set; }
    }
}
