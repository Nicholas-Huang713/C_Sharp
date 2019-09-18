using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FishApp.Models
{
    public class Catch
    {
        public int CatchId {get;set;}
        public string Img {get;set;}
        
        [DataType(DataType.Date)]
        public DateTime Date {get;set;}

        [Required]
        public string Description {get;set;}
        public List<Like> Likers {get;set;}
        public int UserId {get;set;}
        public User Creator {get;set;}

        public Catch() {
            Likers = new List<Like>();
        }

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}