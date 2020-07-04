using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoriZaika.DataService.Entities
{
    [Table("Procedure")]
    public class Procedure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("RecipeId")]
        public int RecipeId { get; set; }
        public string ProcedureSteps { get; set; }
    }
}
