using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Wedding.Models
{
    public class Plan
    {
        public int PlanId {get;set;}
        [Required]
        public string Bride {get;set;}
        [Required]
        public string Groom {get;set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date {get;set;}
        [Required]
        public string Address {get;set;}
        public int User_Id {get;set;}
        public User User {get;set;}
        public List<Rsvp> Guests {get;set;}
        public Plan() {
            Guests = new List<Rsvp>();
        }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}