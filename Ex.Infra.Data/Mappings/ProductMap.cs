using Ex.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Title)
                .HasColumnType("nvarchar(250)")
                .HasMaxLength(250)
                .IsRequired();
            builder.Property(c => c.Code)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(550)")
                .HasMaxLength(550);
            builder.Property(c => c.Price)
              .HasColumnType("decimal(18,6)")
              .HasMaxLength(550);
            builder.HasOne(p => p.Tenant).WithMany(p => p.Products).HasForeignKey(p => p.TenantId);
        }
    }
}
