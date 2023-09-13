using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Bl;

public partial class DbStoreContext : IdentityDbContext<MyApplicationUser>
{
    public DbStoreContext()
    {
    }

    public DbStoreContext(DbContextOptions<DbStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbItem> TbItems { get; set; }

    public virtual DbSet<TbO> TbOs { get; set; }
    public virtual DbSet<TbSlider> TbSliders { get; set; }
    public virtual DbSet<TbPages> TbPages { get; set; }
    public virtual DbSet<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
    public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }

    public virtual DbSet<VwCategory> VwCategories { get; set; }

    public virtual DbSet<VwItem> VwItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.CategoryImage)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(N'')");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

            entity.HasOne(d => d.Os).WithMany(p => p.TbCategories)
                .HasForeignKey(d => d.OsId)
                .HasConstraintName("FK_TbCategories_TbOs");
        });

        modelBuilder.Entity<TbItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(N'')");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.ImageName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_TbItems_TbCategories");

            entity.HasOne(d => d.Os).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.OsId)
                .HasConstraintName("FK_TbItems_TbOs");
        });

        modelBuilder.Entity<TbO>(entity =>
        {
            entity.HasKey(e => e.OsId);

            entity.Property(e => e.CreatedBy).HasDefaultValueSql("(N'')");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            entity.Property(e => e.OsName).HasMaxLength(100);
            entity.Property(e => e.ShowInHomePage)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
        });

        modelBuilder.Entity<VwCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwCategories");

            entity.Property(e => e.CategoryImage)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.OsName).HasMaxLength(100);
        });

        modelBuilder.Entity<VwItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VwItems");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.ImageName)
                .HasMaxLength(200)
                .IsFixedLength();
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.OsName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
