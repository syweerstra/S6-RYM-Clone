using Microsoft.EntityFrameworkCore;

namespace UserService
{
    public class SqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        
    }
}
