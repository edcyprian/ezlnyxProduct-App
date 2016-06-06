using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EzlynxProductApp.Models
{
    public class Product
    {

        public int id { get; set; }

        [Required(ErrorMessage ="Provide product name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Provide product type")]
        public string type { get; set; }

        [Required(ErrorMessage = "Provide product short Description")]
        public string shortDesc { get; set; }
    }
}
