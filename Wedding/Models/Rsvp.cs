using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Wedding.Models
{
    public class Rsvp
    {
        public int RsvpId {get;set;}
        public int User_Id {get;set;}
        public User User {get;set;}
        public int WeddingId {get;set;}
        public Plan Wedding {get;set;}

    }
}