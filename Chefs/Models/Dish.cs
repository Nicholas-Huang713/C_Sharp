using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Chefs.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [MinLength(2)]
        public string DishName {get;set;}

        [Required]
        [Calories]
        public int? Calories {get;set;}
        [Required]
        [Range(1,5)]
        public int? Tastiness {get;set;}
        [Required]
        public string Description {get;set;}
        [Required]
        public int ChefId {get;set;}
        public Chef Creator {get;set;}

    }

    public class CaloriesAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value==null || value.ToString().Length == 0 || (int)value < 0)
            {
                return new ValidationResult("Colories must be greater than zero");
            }
            return ValidationResult.Success;
        }
    }
}