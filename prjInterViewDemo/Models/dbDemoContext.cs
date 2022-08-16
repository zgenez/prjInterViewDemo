using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace prjInterViewDemo.Models
{
    public partial class dbDemoContext : DbContext
    {
        public dbDemoContext()
        {
        }

        public dbDemoContext(DbContextOptions<dbDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAccess> TAccesses { get; set; }
        public virtual DbSet<TCustomer> TCustomers { get; set; }
        public virtual DbSet<TEmployee> TEmployees { get; set; }
        public virtual DbSet<TProduct> TProducts { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbDemo;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<TAccess>(entity =>
            {
                entity.HasKey(e => e.FAccessId);

                entity.ToTable("tAccess");

                entity.Property(e => e.FAccessId)
                    .ValueGeneratedNever()
                    .HasColumnName("fAccessId");

                entity.Property(e => e.FAccessName)
                    .HasMaxLength(10)
                    .HasColumnName("fAccessName");
            });

            modelBuilder.Entity<TCustomer>(entity =>
            {
                entity.HasKey(e => e.FId);

                entity.ToTable("tCustomer");

                entity.Property(e => e.FId)
                    .ValueGeneratedNever()
                    .HasColumnName("fId");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhone)
                    .HasMaxLength(50)
                    .HasColumnName("fPhone");
            });

            modelBuilder.Entity<TEmployee>(entity =>
            {
                entity.HasKey(e => e.FEmployeesId);

                entity.ToTable("tEmployees");

                entity.Property(e => e.FEmployeesId)
                    .ValueGeneratedNever()
                    .HasColumnName("fEmployeesId");

                entity.Property(e => e.FAccess).HasColumnName("fAccess");

                entity.Property(e => e.FName)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("fName");

                entity.Property(e => e.FPosition)
                    .HasMaxLength(10)
                    .HasColumnName("fPosition");

                entity.Property(e => e.F隸屬)
                    .HasMaxLength(50)
                    .HasColumnName("f隸屬");
            });

            modelBuilder.Entity<TProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tProducts");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(50)
                    .HasColumnName("fAddress");

                entity.Property(e => e.FPrice)
                    .HasColumnType("money")
                    .HasColumnName("fPrice");

                entity.Property(e => e.FProductId).HasColumnName("fProductId");

                entity.Property(e => e.FProductName)
                    .HasMaxLength(50)
                    .HasColumnName("fProductName");

                entity.Property(e => e.F坪數)
                    .HasMaxLength(10)
                    .HasColumnName("f坪數");

                entity.Property(e => e.F屋齡).HasColumnName("f屋齡");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
