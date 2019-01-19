using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NetCore.Models
{
    public partial class APIDBContext : DbContext
    {
        public APIDBContext()
        {
        }

        public APIDBContext(DbContextOptions<APIDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=APIDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Managers>(entity =>
            {
                entity.HasKey(e => e.ManagerId)
                    .HasName("PK_dbo.Managers");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_dbo.Workers");

                entity.HasIndex(e => e.ManagerId)
                    .HasName("IX_ManagerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_dbo.Workers_dbo.Managers_ManagerID");
            });
        }
    }
}
