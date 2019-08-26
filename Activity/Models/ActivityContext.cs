using Microsoft.EntityFrameworkCore;
 
namespace Activity.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<ThisActivity> Activities {get;set;}
        public DbSet<ThisAction> Actions {get;set;}
        
    }
}