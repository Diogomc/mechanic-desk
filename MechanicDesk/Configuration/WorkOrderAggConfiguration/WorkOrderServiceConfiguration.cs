using MechanicDesk.Models.WorkOrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace MechanicDesk.Configuration.WorkOrderAggConfiguration;

public class WorkOrderServiceConfiguration : IEntityTypeConfiguration<WorkOrderService>
{
    public void Configure(EntityTypeBuilder<WorkOrderService> builder)
    {
        builder.ToTable("WorkOrderServices");
        builder.HasKey(ws => ws.Id);

        builder.Property(ws => ws.ServiceName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ws => ws.Price)
            .IsRequired();

        builder.HasOne(ws => ws.WorkOrder)
            .WithMany(ws => ws.WorkOrderServices)
            .HasForeignKey(ws => ws.WorkOrderId);

    }
}
