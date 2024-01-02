using Microsoft.EntityFrameworkCore;
using VABookWeb.Models;

namespace VABookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
       public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { 
        
            
        
        }
        public DbSet<Category> Categories { get; set; }
    }
}
