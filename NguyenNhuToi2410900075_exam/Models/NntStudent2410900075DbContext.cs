using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NguyenNhuToi2410900075_exam.Models;

public partial class NntStudent2410900075DbContext : DbContext
{
    public NntStudent2410900075DbContext()
    {
    }

    public NntStudent2410900075DbContext(DbContextOptions<NntStudent2410900075DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NntMember> NntMembers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NntStudent_2410900075_Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NntMember>(entity =>
        {
            entity.ToTable("NntMember");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NntEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NntGender).HasMaxLength(10);
            entity.Property(e => e.NntName).HasMaxLength(50);
            entity.Property(e => e.NntPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
