using System.ComponentModel.DataAnnotations;
namespace YourNamespace.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
 
        [Required]
        public string Password { get; set; }
    }
}