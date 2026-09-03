using MechanicDesk.Models.WorkOrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechanicDesk.Configuration.WorkOrderAggConfiguration;

public class WorkOrderPartsConfiguration : IEntityTypeConfiguration<WorkOrderParts>
{
    public void Configure(EntityTypeBuilder<WorkOrderParts> builder)
    {
        builder.ToTable("WorkOrderParts");
        builder.HasKey(wp => wp.Id);

        builder.Property(wp => wp.PartName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(wp => wp.Price)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder.HasOne(wp => wp.WorkOrder)
            .WithMany(wp => wp.WorkOrderParts)
            .HasForeignKey(wp => wp.WorkOrderId);

    }
}
