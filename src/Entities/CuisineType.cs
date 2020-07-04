using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndoriZaika.DataService.Entities
{
    [Table("CuisineType")]
    [DisplayColumn("Id", "CuisineTypeId")]
    public class CuisineType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public EnumCuisineType CusineType { get; set; }
        public string Description { get; set; }

    }
}
