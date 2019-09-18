using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FishApp.Models
{
    public class Like
    {
        public int LikeId {get;set;}
        public int UserId{get;set;}
        public int CatchId {get;set;}
        public User User {get;set;}
        public Catch Catch {get;set;}
    }
}