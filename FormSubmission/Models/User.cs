using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [Display(Name="First Name: ")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(4)]
        [Display(Name="Last Name: ")]
        public string LastName {get; set;}

        [Required]
        [Range(1,100)]
        [Display(Name="Age: ")]
        public int Age {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name="Email: ")]
        public string Email {get;set;}

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string Password {get; set;}
    }
}