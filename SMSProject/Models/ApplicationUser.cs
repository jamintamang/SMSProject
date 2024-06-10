using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SMSProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Name { get; set; }
        public DateOnly BOD { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Course { get; set; }
    }
}
