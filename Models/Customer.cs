using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class Customer
    {
        [Key]
        public int CustId { get; set; }
        [Display(Name = "Customer Name")]
        [Required]
        public string CustName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAdd { get; set; }
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DteCreated { get; set; }
        [Required]
        [Display(Name = "Package")]
        public string ProdTyp { get; set; }
    }
}
