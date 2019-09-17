using Microsoft.EntityFrameworkCore;
 
namespace FishApp.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Like> Likes {get;set;}
        public DbSet<Catch> Catches {get;set;}
        
    }
}