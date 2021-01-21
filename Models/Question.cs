using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace test4.Models
{
    public class Question
    {
        public string CheckBoxQuestion { get; set; }
        [Display(Name = "Webmail Problem")]
        public bool CheckBoxAnswer1 { get; set; }
        [Display(Name = "Server Problem")]
        public bool CheckBoxAnswer2 { get; set; }
        [Display(Name = "Email Problem")]
        public bool CheckBoxAnswer3 { get; set; }
        [Display(Name = "Internet Problem")]
        public bool CheckBoxAnswer4 { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks1 { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks2 { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks3 { get; set; }

        [Display(Name = "Remarks")]
        public string Remarks4 { get; set; }


    }
}
