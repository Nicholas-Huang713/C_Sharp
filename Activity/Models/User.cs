using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Activity.Models
{
    public class User
    {
        
        public int UserId {get;set;}
        [Required]
        [MinLength(2)]
        public string Name {get;set;}

        [EmailAddress]
        [Required]
        public string Email {get;set;}

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8)]
        public string Password {get;set;}
        public List<ThisActivity> CreatedActivities {get; set;}
        public List<ThisAction> Actions {get;set;}
        public User() {
            Actions = new List<ThisAction>();
        }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}
    }  
}