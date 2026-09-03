using MechanicDesk.Models.WorkOrderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechanicDesk.Configuration.WorkOrderAggConfiguration;

public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.ToTable("WorkOrders");
        builder.HasKey(wo => wo.Id);

        builder.Property(wo => wo.ProblemDescription)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(wo => wo.InitialDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(wo => wo.FinalDate)
            .IsRequired()
            .HasColumnType("date");

        builder.Property(wo => wo.WorkerName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(wo => wo.IsFinished)
            .IsRequired();

        builder.HasMany(wo => wo.WorkOrderServices)
            .WithOne(wo => wo.WorkOrder)
            .HasForeignKey(wo => wo.WorkOrderId);

        builder.HasMany(wo => wo.WorkOrderParts)
            .WithOne(wo => wo.WorkOrder)
            .HasForeignKey(wo => wo.WorkOrderId);

        builder.HasOne(wo => wo.Client)
            .WithMany(wo => wo.WorkOrders)
            .HasForeignKey(wo => wo.ClientId);

        builder.HasOne(wo => wo.Car)
            .WithMany(wo => wo.WorkOrders)
            .HasForeignKey(wo => wo.CarId);
    }
}
