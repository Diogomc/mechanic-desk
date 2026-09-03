using MechanicDesk.Configuration;
using MechanicDesk.Configuration.WorkOrderAggConfiguration;
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
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderPartsConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOrderServiceConfiguration());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<WorkOrderParts> WorkOrderParts { get; set; }
        public DbSet<WorkOrderService> WorkOrderServices { get; set; }

    }
}
