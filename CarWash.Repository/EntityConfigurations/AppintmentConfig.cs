using CarWash.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarWash.Repository.EntityConfigurations
{
    public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // Anahtarlar ve ilişki tanımlamaları
            builder.HasKey(a => a.Id);

            // Customer ile ilişki
            builder.HasOne(a => a.Customer)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade); // Silme davranışını isteğinize göre ayarlayabilirsiniz

            // WashPackage ile ilişki
            builder.HasOne(a => a.WashPackage)
                .WithMany(c=> c.Appointments)
                .HasForeignKey(a => a.PackageId)
                .OnDelete(DeleteBehavior.Restrict); // Silme davranışını isteğinize göre ayarlayabilirsiniz

            // Diğer konfigürasyonlar buraya eklenebilir.
        }
    }
}
