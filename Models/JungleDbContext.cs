using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JungleApi.Web.Models
{
    public partial class JungleDbContext : DbContext
    {
        public JungleDbContext()
        {
        }

        public JungleDbContext(DbContextOptions<JungleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<LineSery> LineSeries { get; set; }
        public virtual DbSet<Month> Months { get; set; }
        public virtual DbSet<Name> Names { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product1> Product1 { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<SalesByCategoryAndYear> SalesByCategoryAndYears { get; set; }
        public virtual DbSet<SalesData> SalesDatas { get; set; }
        public virtual DbSet<SalesHistory> SalesHistories { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Trackball> Trackballs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL5041.site4now.net;Initial Catalog=DB_A63157_dcassin234;User Id=DB_A63157_dcassin234_admin;Password=Anim@te1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Address1).HasMaxLength(50);

                entity.Property(e => e.Address2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.ToTable("Corporation");

                entity.Property(e => e.OrganizationNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrderAggregateProductTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("CustomerOrder");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Carrier).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderSubTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShipDate).HasColumnType("date");

                entity.Property(e => e.ShippingCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Empcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("EmployeeDetail");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.AddressLine1).HasMaxLength(50);

                entity.Property(e => e.AddressLine2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PayrollStatus).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("money");

                entity.Property(e => e.State).HasMaxLength(50);
            });

            modelBuilder.Entity<LineSery>(entity =>
            {
                entity.Property(e => e.Month).HasMaxLength(50);
            });

            modelBuilder.Entity<Month>(entity =>
            {
                entity.ToTable("Month");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Name>(entity =>
            {
                entity.ToTable("Name");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.LargePhotoFileName)
                    .HasColumnName("LargePhotoFIleName")
                    .HasMaxLength(50);

                entity.Property(e => e.LineTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50);

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.SizeUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50);

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.WeightUnitMeasureCode)
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Product1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LargePhotoFileName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(50);

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory");

                entity.Property(e => e.ProductSubcategoryId).HasColumnName("ProductSubcategoryID");

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.SubCategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<SalesByCategoryAndYear>(entity =>
            {
                entity.ToTable("SalesByCategoryAndYear");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Year)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<SalesData>(entity =>
            {
                entity.ToTable("SalesData");

                entity.Property(e => e.DateString).HasMaxLength(50);

                entity.Property(e => e.Day).HasColumnType("date");
            });

            modelBuilder.Entity<SalesHistory>(entity =>
            {
                entity.ToTable("SalesHistory");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Month)
                    .HasMaxLength(3)
                    .IsFixedLength();

                entity.Property(e => e.SalesDate).HasColumnType("date");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Trackball>(entity =>
            {
                entity.ToTable("Trackball");

                entity.Property(e => e.X)
                    .HasColumnName("x")
                    .HasColumnType("date");

                entity.Property(e => e.Y).HasColumnName("y");

                entity.Property(e => e.Y1).HasColumnName("y1");

                entity.Property(e => e.Y2).HasColumnName("y2");

                entity.Property(e => e.Y3).HasColumnName("y3");

                entity.Property(e => e.Y4).HasColumnName("y4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
