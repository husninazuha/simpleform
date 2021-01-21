using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class Product
    {
        [Key]
        public int ProdId { get; set; }
        [Display(Name = "Package")]
        public string ProdTyp { get; set; }
        public string Price { get; set; }
    }
}
