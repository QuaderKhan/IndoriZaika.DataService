using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace indorizaikaDataService.Models
{
    public class UserCommentsModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Comment { get; set; }
    }
}
