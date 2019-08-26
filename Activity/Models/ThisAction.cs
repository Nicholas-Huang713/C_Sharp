using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Activity.Models
{
    public class ThisAction
    {
        public int ThisActionId {get;set;}
        public int User_Id {get;set;}
        public User User {get;set;}
        public int ThisActivityId {get;set;}
        public ThisActivity ThisActivity {get;set;}
    }
}