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
    public class OrderLineMap : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(c => c.Id)
               .HasColumnName("Id");
            builder.Property(c => c.Quantity)
              .HasColumnType("int");
            builder.Property(c => c.ProductPrice)
             .HasColumnType("decimal(18,6)");
            builder.Property(c => c.Cost)
            .HasColumnType("decimal(18,6)");
            builder.HasOne(p => p.Order).WithMany(p => p.OrderLines).HasForeignKey(p => p.OrderId);
        }
    }
}
