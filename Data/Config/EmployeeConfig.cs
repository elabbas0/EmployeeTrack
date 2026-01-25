using EmployeeTrack.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTrack.Data.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(e => e.LastName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(e => e.FatherName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.StopDate)
                .HasColumnType("date")
                .IsRequired(false);

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,4)")
                .IsRequired();

            builder.HasOne(e => e.Position)
               .WithMany(e => e.Employees)
               .HasForeignKey(e => e.PositionId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();
        }
    }
}
