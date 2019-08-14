using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2)]
        [Display(Name="Name: ")]
        public string Name {get;set;}

        [Required]
        [Display(Name="Location: ")]
        public string Location{get;set;}

        [Required]
        [Display(Name="Language: ")]
        public string Language{get;set;}

        [MaxLength(20)]
        [Display(Name="Comment(Optional): ")]
        public string Comment{get;set;}
    }
}