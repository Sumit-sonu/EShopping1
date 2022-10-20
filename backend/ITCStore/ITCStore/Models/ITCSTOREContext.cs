using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ITCStore.Models
{
    public partial class ITCSTOREContext : DbContext
    {
        public ITCSTOREContext()
        {
        }

        public ITCSTOREContext(DbContextOptions<ITCSTOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderTbl> OrderTbls { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ITCDNFS08;Initial Catalog=ITCSTORE;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_Description");

                entity.Property(e => e.CategoryImage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_Image");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category_Name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderDetailsId).HasColumnName("Order_Details_Id");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_Price");

                entity.Property(e => e.ProductQty).HasColumnName("Product_Qty");
            });

            modelBuilder.Entity<OrderTbl>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Order_Tbl");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.IsDelivered)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Is_Delivered");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.OrderNo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Order_No");

                entity.Property(e => e.OrderTotal).HasColumnName("Order_Total");

                entity.Property(e => e.ShippingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Shipping_Date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("Product_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Image1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Desc");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
