using CleanTemplate.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanTemplate.Infrastructure.Core;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate)
                .HasColumnName("LastModifiedDate")
                .HasColumnType("datetime");

            builder .HasOne(e => e.Area)
                .WithMany(e => e.Employees);
        }
    }