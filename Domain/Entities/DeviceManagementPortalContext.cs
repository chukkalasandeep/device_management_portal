using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeviceManagementPortal.Domain.Entities
{
    public partial class DeviceManagementPortalContext : DbContext
    {
        public DeviceManagementPortalContext()
        {
        }

        public DeviceManagementPortalContext(DbContextOptions<DeviceManagementPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Backend> Backend { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceBackend> DeviceBackend { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS; initial catalog=DeviceManagementPortal; user id=sa; password=pass@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backend>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Device")
                    .IsUnique();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Imei)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SimCardNumber).HasColumnType("numeric(20, 0)");
            });

            modelBuilder.Entity<DeviceBackend>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_DeviceBackend")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MappedDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Backend)
                    .WithMany(p => p.DeviceBackend)
                    .HasForeignKey(d => d.BackendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceBackend_Backend");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceBackend)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceBackend_Device");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
