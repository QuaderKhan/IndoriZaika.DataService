using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoriZaika.DataService.Entities
{
    [Table("RecipeDetail")]
    public class RecipeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        
        [ForeignKey("RecipeId")]
        public int RecipeId { get; set; }
        public string VideoPath { get; set; }
        public string ThumbnailPath { get; set; }
        public string FullImagePath { get; set; }
    }
}
