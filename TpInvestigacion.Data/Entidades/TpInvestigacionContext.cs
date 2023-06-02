using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TpInvestigacion.Data.Entidades
{
    public partial class TpInvestigacionContext : DbContext
    {
        public TpInvestigacionContext()
        {
        }

        public TpInvestigacionContext(DbContextOptions<TpInvestigacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bloque> Bloques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BUTNA10\\SQLEXPRESS;Database=TpInvestigacion;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bloque>(entity =>
            {
                entity.ToTable("Bloque");

                entity.Property(e => e.Datos)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Hash)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HashAnterior)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Hash_anterior");

                entity.Property(e => e.Tiempo).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
