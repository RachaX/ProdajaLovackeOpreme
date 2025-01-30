using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProdavnicaLovackeOpreme.Models;

public partial class ProdavnicaContext : DbContext
{
    private static String _connectionString = ConfigurationManager.ConnectionStrings["ProdajaLovackeOpremeDB"].ConnectionString;

    public static String ConnectionString
    {
        get { return _connectionString; }
    }
    public ProdavnicaContext()
    {
    }

    public ProdavnicaContext(DbContextOptions<ProdavnicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillItem> BillItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<OfferItem> OfferItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<StorageItem> StorageItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(ConnectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PRIMARY");

            entity.ToTable("bill");

            entity.HasIndex(e => e.ReportReportId, "fk_bill_report1_idx");

            entity.HasIndex(e => e.UserUserId, "fk_bill_user1_idx");

            entity.Property(e => e.BillId).HasColumnName("billID");
            entity.Property(e => e.ReportReportId).HasColumnName("report_reportID");
            entity.Property(e => e.UserUserId).HasColumnName("user_userID");

            entity.HasOne(d => d.ReportReport).WithMany(p => p.Bills)
                .HasForeignKey(d => d.ReportReportId)
                .HasConstraintName("fk_bill_report1");

            entity.HasOne(d => d.UserUser).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bill_user1");
        });

        modelBuilder.Entity<BillItem>(entity =>
        {
            entity.HasKey(e => new { e.ProductProductId, e.BillBillId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("bill_item");

            entity.HasIndex(e => e.BillBillId, "fk_bill_item_bill1_idx");

            entity.Property(e => e.ProductProductId).HasColumnName("product_productID");
            entity.Property(e => e.BillBillId).HasColumnName("bill_billID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.BillBill).WithMany(p => p.BillItems)
                .HasForeignKey(d => d.BillBillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bill_item_bill1");

            entity.HasOne(d => d.ProductProduct).WithMany(p => p.BillItems)
                .HasForeignKey(d => d.ProductProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bill_item_product1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(45)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PRIMARY");

            entity.ToTable("offer");

            entity.HasIndex(e => e.UserUserId, "fk_offer_user1_idx");

            entity.Property(e => e.OfferId).HasColumnName("offerID");
            entity.Property(e => e.UserUserId).HasColumnName("user_userID");

            entity.HasOne(d => d.UserUser).WithMany(p => p.Offers)
                .HasForeignKey(d => d.UserUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_offer_user1");
        });

        modelBuilder.Entity<OfferItem>(entity =>
        {
            entity.HasKey(e => new { e.OfferOfferId, e.ProductProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("offer_item");

            entity.HasIndex(e => e.OfferOfferId, "fk_offer_item_offer1_idx");

            entity.HasIndex(e => e.ProductProductId, "fk_offer_item_product1_idx");

            entity.Property(e => e.OfferOfferId).HasColumnName("offer_offerID");
            entity.Property(e => e.ProductProductId).HasColumnName("product_productID");

            entity.HasOne(d => d.OfferOffer).WithMany(p => p.OfferItems)
                .HasForeignKey(d => d.OfferOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_offer_item_offer1");

            entity.HasOne(d => d.ProductProduct).WithMany(p => p.OfferItems)
                .HasForeignKey(d => d.ProductProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_offer_item_product1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryCategoryName, "fk_product_category1_idx");

            entity.HasIndex(e => e.UserUserId, "fk_product_user1_idx");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.CategoryCategoryName)
                .HasMaxLength(45)
                .HasColumnName("category_categoryName");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("mediumblob")
                .HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(5, 2)
                .HasColumnName("price");
            entity.Property(e => e.UserUserId).HasColumnName("user_userID");

            entity.HasOne(d => d.CategoryCategoryNameNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryCategoryName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_category1");

            entity.HasOne(d => d.UserUser).WithMany(p => p.Products)
                .HasForeignKey(d => d.UserUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_user1");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PRIMARY");

            entity.ToTable("report");

            entity.HasIndex(e => e.UserUserId, "fk_report_user1_idx");

            entity.Property(e => e.ReportId).HasColumnName("reportID");
            entity.Property(e => e.Type).HasMaxLength(45);
            entity.Property(e => e.UserUserId).HasColumnName("user_userID");

            entity.HasOne(d => d.UserUser).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_report_user1");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.StorageId).HasName("PRIMARY");

            entity.ToTable("storage");

            entity.Property(e => e.StorageId).HasColumnName("storageID");
            entity.Property(e => e.Location)
                .HasMaxLength(45)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StorageItem>(entity =>
        {
            entity.HasKey(e => new { e.ProductProductId, e.StorageStorageId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("storage_item");

            entity.HasIndex(e => e.StorageStorageId, "fk_storage_item_storage1_idx");

            entity.Property(e => e.ProductProductId).HasColumnName("product_productID");
            entity.Property(e => e.StorageStorageId).HasColumnName("storage_storageID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.ProductProduct).WithMany(p => p.StorageItems)
                .HasForeignKey(d => d.ProductProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_storage_item_product1");

            entity.HasOne(d => d.StorageStorage).WithMany(p => p.StorageItems)
                .HasForeignKey(d => d.StorageStorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_storage_item_storage1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.CompanyName).HasMaxLength(45);
            entity.Property(e => e.Font).HasMaxLength(45);
            entity.Property(e => e.Jib)
                .HasMaxLength(13)
                .IsFixedLength()
                .HasColumnName("JIB");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(512);
            entity.Property(e => e.Surname).HasMaxLength(45);
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
