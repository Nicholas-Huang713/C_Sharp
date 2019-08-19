using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuotingDojo.Models
{
    public class Quote
    {
        [Required]
        [Display(Name="Your Name: ")]
        public string name {get;set;}
        [Required]
        [Display(Name="Your Comment: ")]
        public string quote{get;set;}

    }
}