using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace unitronicsWebApi.Model
{
    public partial class UnitronicsContext : DbContext
    {
        public UnitronicsContext()
        {
        }

        public UnitronicsContext(DbContextOptions<UnitronicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Parking> Parkings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Develop\\WORK-PROJECTS\\UNITRONICS\\WEBAPI\\tronix-webAPI\\MDF\\mdftest.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Parking>(entity =>
            {
                entity.ToTable("Parking");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CheckInTime)
                    .HasColumnName("checkInTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentLot).HasColumnName("currentLot");

                entity.Property(e => e.ExpirationTime)
                    .HasColumnName("expirationTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasColumnName("ticketType")
                    .HasMaxLength(10);

                entity.Property(e => e.VehicleHeight).HasColumnName("vehicleHeight");

                entity.Property(e => e.VehicleLength).HasColumnName("vehicleLength");

                entity.Property(e => e.VehicleWidth).HasColumnName("vehicleWidth");

                entity.Property(e => e.Vehicletype)
                    .IsRequired()
                    .HasColumnName("vehicletype")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}