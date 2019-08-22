using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Chefs.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required]
        [MinLength(2)]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2)]
        public string LastName {get;set;}

        [Required]
        [FutureDate]
        [Age]
        public DateTime? Birthday {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public List<Dish> CreateDishes {get;set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value)>DateTime.Now)
                return new ValidationResult("Date must be in the past!");
            return ValidationResult.Success;
        }
    }
    public class AgeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ( DateTime.Today.Year - Convert.ToDateTime(value).Year < 18)
                return new ValidationResult("Chef age must be 18 or over!");
            return ValidationResult.Success;
        }
    }
    
}