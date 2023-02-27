using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fmsapi.Models
{
    public partial class ACE42023Context : DbContext
    {
        public ACE42023Context()
        {
        }

        public ACE42023Context(DbContextOptions<ACE42023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<IBooking> IBookings { get; set; }
        public virtual DbSet<IFlight> IFlights { get; set; }
        public virtual DbSet<IUser> IUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DEVSQL.corp.local;Database=ACE 4- 2023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__iBooking__5DE3A5B10159E289");

                entity.ToTable("iBookings");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("booking_id");

                entity.Property(e => e.BookingDate)
                    .HasColumnType("date")
                    .HasColumnName("booking_date");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.SeatNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("seat_number");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<IFlight>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__iFlights__E3705765959FAB65");

                entity.ToTable("iFlights");

                entity.Property(e => e.FlightId)
                    .ValueGeneratedNever()
                    .HasColumnName("flight_id");

                entity.Property(e => e.AvailableSeats).HasColumnName("available_seats");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("destination");

                entity.Property(e => e.FlightDate)
                    .HasColumnType("date")
                    .HasColumnName("flight_date");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("flight_number");

                entity.Property(e => e.FlightPrice).HasColumnName("flight_price");

                entity.Property(e => e.FlightTime).HasColumnName("flight_time");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("origin");
            });

            modelBuilder.Entity<IUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__iUsers__B9BE370F2D23F7C0");

                entity.ToTable("iUsers");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("user_phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
