using CleanTemplate.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanTemplate.Infrastructure.Core;

    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Area");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.LastModifiedDate)
                .HasColumnName("LastModifiedDate")
                .HasColumnType("datetime");
        }
    }
