using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoriZaika.DataService.Entities
{
    [Table("Recipe")]
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("CusineTypeId")]
        public EnumCuisineType CusineType { get; set; }
        
        [ForeignKey("RecipeTypeId")]
        public EnumRecipeType RecipeType { get; set; }
        public string Description { get; set; }
    }
}
