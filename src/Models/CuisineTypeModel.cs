using IndoriZaika.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Models
{
    public class CuisineTypeModel
    {
        public int Id { get; set; }
        public EnumCuisineType Type { get; set; }
        public string Description { get; set; }
    }
}
