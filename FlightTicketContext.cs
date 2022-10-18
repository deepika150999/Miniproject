using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AirTicketMiniProject.Models
{
    public partial class FLightTicketContext : DbContext
    {
        public FLightTicketContext()
        {
        }

        public FLightTicketContext(DbContextOptions<FLightTicketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BusinessClass> BusinessClasses { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<EconomyClass> EconomyClasses { get; set; } = null!;
        public virtual DbSet<Flight> Flights { get; set; } = null!;
        public virtual DbSet<LoginPage> LoginPages { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GQJ9GIB;Database=FLightTicket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__book__73951AED9EF59B56");

                entity.ToTable("book");

                entity.Property(e => e.ClassType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateofBooking).HasColumnType("datetime");

                entity.HasOne(d => d.FlightNumberNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.FlightNumber)
                    .HasConstraintName("FK__book__FlightNumb__6FE99F9F");
            });

            modelBuilder.Entity<BusinessClass>(entity =>
            {
                entity.HasKey(e => e.BusinessClsId)
                    .HasName("PK__Business__097A48D6D3235312");

                entity.ToTable("BusinessClass");

                entity.Property(e => e.BusinessClsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Business_clsId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.BusinessClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__BusinessC__Class__440B1D61");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).ValueGeneratedNever();

                entity.Property(e => e.BusinessclsId).HasColumnName("Businesscls_id");

                entity.Property(e => e.EconomyClsId).HasColumnName("Economy_clsId");
            });

            modelBuilder.Entity<EconomyClass>(entity =>
            {
                entity.HasKey(e => e.EconomyClsId)
                    .HasName("PK__EconomyC__09B99765B64BA59F");

                entity.ToTable("EconomyClass");

                entity.Property(e => e.EconomyClsId)
                    .ValueGeneratedNever()
                    .HasColumnName("Economy_clsId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.EconomyClasses)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__EconomyCl__Class__412EB0B6");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.FlightNumber)
                    .HasName("PK__Flights__2EAE6F51EFCDF395");

                entity.Property(e => e.FlightNumber).ValueGeneratedNever();

                entity.Property(e => e.ArravingPoint)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfArrving).HasColumnType("date");

                entity.Property(e => e.DateOfDeparture).HasColumnType("date");

                entity.Property(e => e.DeparturePoint)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TicketCost).HasColumnType("money");
            });

            modelBuilder.Entity<LoginPage>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("LoginPage");

                entity.Property(e => e.Sno).ValueGeneratedOnAdd();

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Confirm_Password");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.SnoNavigation)
                    .WithOne(p => p.LoginPage)
                    .HasForeignKey<LoginPage>(d => d.Sno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LoginPage__Sno__48CFD27E");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__passenge__C57755406BF272EA");

                entity.ToTable("passengers");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.PassangerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Passengers)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__passenger__Booki__72C60C4A");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Paymentid).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("paymentDate");

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Payment__Booking__76969D2E");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Sno)
                    .HasName("PK__Register__CA1FE4642E7980E7");

                entity.ToTable("Register");

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("Confirm_Password");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
