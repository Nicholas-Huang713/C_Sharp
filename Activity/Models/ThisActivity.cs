using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Activity.Models
{
    public class ThisActivity
    {
        public int ThisActivityId {get;set;}
        [Required]
        public string Title {get;set;}

        [DataType(DataType.Date)]
        public DateTime Date {get;set;}

        
        public string Time {get;set;}
        
        public int Duration {get;set;}
        
        public string TimeType{get;set;}

        [Required]
        public string Description {get;set;}
        public int UserId {get;set;}
        public User Coordinator {get;set;}

        public List<ThisAction> Participants {get;set;} 
        public ThisActivity() {
            Participants = new List<ThisAction>(); 
        }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}