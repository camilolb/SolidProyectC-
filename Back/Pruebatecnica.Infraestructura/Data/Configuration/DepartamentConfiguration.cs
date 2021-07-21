﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaTecnica.Core.Entities;

namespace Pruebatecnica.Infraestructura.Data.Configuration
{
    public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> entity)
        {

            entity.ToTable("Departament");

            entity.Property(e => e.Create).HasColumnType("datetime");

            entity.Property(e => e.Modify).HasColumnType("datetime");

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Build)
                .WithMany(p => p.Departaments)
                .HasForeignKey(d => d.BuildId)
                .HasConstraintName("FK_Departament_BuildID");

        }
    }
}
