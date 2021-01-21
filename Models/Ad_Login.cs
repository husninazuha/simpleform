using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test4.Models;
using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class Ad_Login
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
