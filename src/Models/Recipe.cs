using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Cuisine Cuisine { get; set; }
        public RecipeType RecipeType { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public string ThumbnailImagePath { get; set; }
    }
}
