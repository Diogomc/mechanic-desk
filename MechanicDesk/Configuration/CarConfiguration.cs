using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechanicDesk.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.LicencePlate)
                .IsRequired()
                .HasMaxLength(7);

            builder.HasOne(c => c.Client)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.ClientId);

            builder.HasMany(c => c.WorkOrders)
                .WithOne(c => c.Car)
                .HasForeignKey(c => c.CarId);
        }
    }
}
