using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sales>
    {

        public void Configure(EntityTypeBuilder<Sales> entity)
        {

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.ProductId).HasColumnName("productId");

            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("total");

        }
    }
}
