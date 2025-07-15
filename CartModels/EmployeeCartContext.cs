using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InfosysTest.CartModels
{
    public partial class EmployeeCartContext : DbContext
    {
        public EmployeeCartContext()
        {
        }

        public EmployeeCartContext(DbContextOptions<EmployeeCartContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        public virtual DbSet<Empproduct> Empproduct { get; set; }
        public virtual DbSet<EmpproductDetail> EmpproductDetail { get; set; }
        public virtual DbSet<Empsalary> Empsalary { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=localhost;database=EmployeeCart;user id=sa1;password=password@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__Employee__14CCD97DE45CBA9E");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empproduct>(entity =>
            {
                entity.ToTable("EMPProduct");

                entity.Property(e => e.EmpproductId).HasColumnName("EMPProductID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Title)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpproductDetail>(entity =>
            {
                entity.ToTable("EMPProductDetail");

                entity.Property(e => e.EmpproductDetailId).HasColumnName("EMPProductDetailID");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.Property(e => e.EmpproductId).HasColumnName("EMPProductID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.EmpproductDetail)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__EMPProduc__EMPID__3E52440B");

                entity.HasOne(d => d.Empproduct)
                    .WithMany(p => p.EmpproductDetail)
                    .HasForeignKey(d => d.EmpproductId)
                    .HasConstraintName("FK__EMPProduc__EMPPr__3F466844");
            });

            modelBuilder.Entity<Empsalary>(entity =>
            {
                entity.ToTable("EMPSalary");

                entity.Property(e => e.EmpsalaryId).HasColumnName("EMPSalaryID");

                entity.Property(e => e.Empid).HasColumnName("EMPID");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Empsalary)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__EMPSalary__EMPID__398D8EEE");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
