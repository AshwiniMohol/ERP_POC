using Microsoft.EntityFrameworkCore;
using RequisitionApi.Models;

namespace RequisitionApi.Data
{
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options ): base(options){}
        public DbSet<Requisition> Requisitions {get; set;}
    }

}