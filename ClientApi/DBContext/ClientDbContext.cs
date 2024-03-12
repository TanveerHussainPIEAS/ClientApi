﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.DBContext;

public partial class ClientDbContext : DbContext
{
    public ClientDbContext()
    {
    }

    public ClientDbContext(DbContextOptions<ClientDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartProduct> CartProducts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDesigner> ProductDesigners { get; set; }

    public virtual DbSet<ProductEdit> ProductEdits { get; set; }

    public virtual DbSet<ProductGenCategory> ProductGenCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<WishListProduct> WishListProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=tcp:clientapidbserver.database.windows.net,1433;Initial Catalog=ClientApi_db_live;User Id=circularadmin@clientapidbserver;Password=Fayyaz@1122");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartProducts_Product");

            entity.HasOne(d => d.User).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CartProducts_User");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Country");

            entity.Property(e => e.CountryCode).HasMaxLength(50);
            entity.Property(e => e.Lang)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Lat)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Product");

            entity.Property(e => e.Brand).HasMaxLength(300);
            entity.Property(e => e.Code).HasMaxLength(300);
            entity.Property(e => e.Color).HasMaxLength(300);
            entity.Property(e => e.Condition).HasMaxLength(300);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.InternationalSize).HasMaxLength(300);
            entity.Property(e => e.IsAvailable)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.IsEbayStore).HasColumnName("IsEBayStore");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Price).HasMaxLength(300);
            entity.Property(e => e.RentPrice16Days).HasMaxLength(300);
            entity.Property(e => e.RentPrice30Days).HasMaxLength(300);
            entity.Property(e => e.RentPrice4Days).HasMaxLength(300);
            entity.Property(e => e.RentPrice8Days).HasMaxLength(300);
            entity.Property(e => e.Rrp)
                .HasMaxLength(300)
                .HasColumnName("RRP");
            entity.Property(e => e.SellPrice).HasMaxLength(300);
            entity.Property(e => e.Size).HasMaxLength(300);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_ProductCategory");

            entity.HasOne(d => d.Designer).WithMany(p => p.Products)
                .HasForeignKey(d => d.DesignerId)
                .HasConstraintName("FK_Product_ProductDesigner");

            entity.HasOne(d => d.Edit).WithMany(p => p.Products)
                .HasForeignKey(d => d.EditId)
                .HasConstraintName("FK_Product_ProductEdits");

            entity.HasOne(d => d.ProductGenCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductGenCategoryId)
                .HasConstraintName("FK_Product_ProductGenCategory");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductType");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Type).HasMaxLength(300);
        });

        modelBuilder.Entity<ProductDesigner>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Detail).HasMaxLength(900);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(300);
        });

        modelBuilder.Entity<ProductEdit>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            entity.Property(e => e.Detail).HasMaxLength(900);
            entity.Property(e => e.ImageUrl).HasMaxLength(900);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(300);
        });

        modelBuilder.Entity<ProductGenCategory>(entity =>
        {
            entity.ToTable("ProductGenCategory");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Type).HasMaxLength(300);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductImage");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.Url).HasMaxLength(300);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImage_Product");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductType");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Type).HasMaxLength(300);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");

            entity.Property(e => e.City).HasMaxLength(300);
            entity.Property(e => e.Country).HasMaxLength(300);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Email).HasMaxLength(300);
            entity.Property(e => e.MobileNumber).HasMaxLength(300);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.PhoneNumber).HasMaxLength(300);
            entity.Property(e => e.State).HasMaxLength(300);
            entity.Property(e => e.UserName).HasMaxLength(300);
            entity.Property(e => e.ZipCode).HasMaxLength(300);

            entity.HasOne(d => d.Permission).WithMany(p => p.Users)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Permission");

            entity.HasOne(d => d.Type).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserType");
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserPermission");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UserPermissionCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_Activity_CreatedBy_User");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.UserPermissionDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_Activity_DeletedBy_User");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.UserPermissionModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Activity_ModifiedBy_User");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserType");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Type).HasMaxLength(300);
        });

        modelBuilder.Entity<WishListProduct>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.WishListProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WishListProducts_Product");

            entity.HasOne(d => d.User).WithMany(p => p.WishListProducts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_WishListProducts_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
