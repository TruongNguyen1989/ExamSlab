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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");
            builder.Property(c => c.Sum)
              .HasColumnType("decimal(18,6)");
            builder.Property(c => c.Number)
             .HasColumnType("bigint");

            builder.Property(e => e.TenantId).HasColumnName("TenantId");
            builder.Property(e => e.CustomerId).HasColumnName("CustomerId");
           
            builder.HasOne(d => d.Tenant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Tenant_Orders_TenantId");

            builder.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_Customer_Orders_CustomerId");
           
        }
    }
}
