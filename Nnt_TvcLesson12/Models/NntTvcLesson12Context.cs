using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nnt_TvcLesson12.Models;

public partial class NntTvcLesson12Context : DbContext
{
    public NntTvcLesson12Context()
    {
    }

    public NntTvcLesson12Context(DbContextOptions<NntTvcLesson12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NntProduct> NntProducts { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Nnt_TvcLesson12;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NntProduct>(entity =>
        {
            entity.HasKey(e => e.NntId).HasName("PK__NntProdu__4237102DB5ED4C66");

            entity.Property(e => e.NntCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NntImage).HasMaxLength(255);
            entity.Property(e => e.NntName).HasMaxLength(255);
            entity.Property(e => e.NntPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NntSalePrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
