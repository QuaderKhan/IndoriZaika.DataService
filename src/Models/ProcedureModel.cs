using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indorizaikaDataService.Models
{
    public class ProcedureModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ProcedureSteps { get; set; }
    }
}
