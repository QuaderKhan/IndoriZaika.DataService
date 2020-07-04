using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndoriZaika.DataService.Models
{
    public class RecipeResponse
    {
        public IList<RecipeModel> RecipeList { get; set; }
    }
}
