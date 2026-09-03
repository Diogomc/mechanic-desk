using MechanicDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechanicDesk.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.HasMany(c => c.Cars)
                .WithOne(car => car.Client)
                .HasForeignKey(car => car.ClientId);

            builder.HasMany(c => c.WorkOrders)
                .WithOne(wo => wo.Client)
                .HasForeignKey(wo => wo.ClientId);
        }
    }
}
