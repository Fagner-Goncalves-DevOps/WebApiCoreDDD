using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mappings
{
    public class TabTelecomConsolidadoMap : IEntityTypeConfiguration<TabTelecomConsolidado>
    {
        public void Configure(EntityTypeBuilder<TabTelecomConsolidado> builder)
        {
            builder.HasKey(key => key.Id);
            ///builder.HasKey(key => key.IdConsolidado);

            builder.Property(p => p.Dia)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(p => p.Fila)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Terminator)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.StatusInicial)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(p => p.StatusFinal)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Disparos)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.Custo)
               .IsRequired()
               .HasColumnType("decimal ");

            builder.Property(p => p.Servidor)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("TabTelecomConsolidado");
        }
    }
}

