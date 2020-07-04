using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoriZaika.DataService.Entities
{
    [Table("RecipeType")]
    [DisplayColumn("Id", "RecipeTypeId")]
    public class RecipeType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public EnumRecipeType Type { get; set; }
        public string Description { get; set; }
    }
}
