using System.ComponentModel.DataAnnotations;
using System;

namespace Crudelicious.Models
{
   public class Dish
   {
       [Key]
       public int DishId {get; set;}
       [Required]
       public string Name{get;set;}
       [Required]
       public string Chef{get;set;}
       [Required]
       [Range(1,5)]
       public int Tastiness{get;set;}
       [Required]
       [Range(1,900)]
       public int Calories {get;set;}
       [Required]
       public string Description {get;set;}
       [Required]
       public DateTime CreatedAt {get;set;} = DateTime.Now;
       [Required]
       public DateTime UpdatedAt {get;set;} = DateTime.Now;
   } 
}