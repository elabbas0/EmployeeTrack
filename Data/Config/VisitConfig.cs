using EmployeeTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTrack.Data.Config
{
    public class VisitConfig : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.EndDate)
                .HasColumnType("date")
                .IsRequired(false);

            builder.HasOne(e => e.Employee)
               .WithMany()
               .HasForeignKey(e => e.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.HasOne(e => e.Country)
               .WithMany()
               .HasForeignKey(e => e.CountryId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

            builder.HasOne(e => e.Category)
               .WithMany()
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
