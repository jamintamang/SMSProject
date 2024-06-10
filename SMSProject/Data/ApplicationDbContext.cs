using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSProject.Models;

namespace SMSProject.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  :base (options) 
        { 
        }   

        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }  
    }
}
