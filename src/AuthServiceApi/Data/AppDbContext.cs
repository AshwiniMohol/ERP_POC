using Microsoft.EntityFrameworkCore;
using AuthServiceApi.Models;

namespace AuthServiceApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } 
    }
}
