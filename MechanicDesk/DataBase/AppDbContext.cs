using MechanicDesk.Configuration;
using MechanicDesk.Models;
using MechanicDesk.Models.WorkOrderAgg;
using Microsoft.EntityFrameworkCore;

namespace MechanicDesk.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> 
            options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }

    }
}
