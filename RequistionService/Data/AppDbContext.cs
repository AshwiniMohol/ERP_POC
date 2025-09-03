using Microsoft.EntityFrameworkCore;
using RequistionService.Models;

namespace RequistionService.Data
{
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options){}
        public DbSet<Requisition> Requisitions {get; set;}
    }

}