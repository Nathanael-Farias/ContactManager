using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<AuthSystem.Models.ContactModel> Contacts { get; set; }
        public DbSet<AuthSystem.Models.UserModel> Users { get; set; }

        
    }
}
