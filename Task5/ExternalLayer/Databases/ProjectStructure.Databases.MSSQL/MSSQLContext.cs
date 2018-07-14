using Microsoft.EntityFrameworkCore;
using ProjectStructure.Infrastructure.Data;
using ProjectStructure.Domain;

namespace ProjectStructure.Databases.MSSQL
{
    public class MSSQLContext : AirportContext
    {
        public MSSQLContext()
        {

        }

        // Data Source=DESKTOP-N1FVMAR\MZSERVER;Initial Catalog=Northwind;Integrated Security=True
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.Pilot)
                        .WithOne(e => e.Crew)
                        .HasForeignKey<Pilot>(e => e.CrewId);
            });

            modelBuilder.Entity<Pilot>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ExperienceYears)
                        .IsRequired()
                        .HasMaxLength(30);
                entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.Surname)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.Birth)
                        .IsRequired();

            });

            modelBuilder.Entity<Stewardess>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.Surname)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.Birth)
                        .IsRequired();

                entity.HasOne(e => e.Crew)
                        .WithMany(e => e.Stewardesses)
                        .HasForeignKey(e => e.CrewId);
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Lifetime)
                        .IsRequired();
                entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.ReleaseDate)
                        .IsRequired();

                entity.HasOne(e => e.Type)
                        .WithMany(e => e.Planes)
                        .HasForeignKey(e => e.TypeId);
            });

            modelBuilder.Entity<PlaneType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Capacity)
                        .IsRequired()
                        .HasMaxLength(500);
                entity.Property(e => e.CargoCapacity)
                        .IsRequired()
                        .HasMaxLength(10000);
                entity.Property(e => e.Model)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();

            });

            modelBuilder.Entity<Departure>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DepartureTime)
                        .IsRequired();

                entity.HasOne(e => e.Crew)
                        .WithOne()
                        .HasForeignKey<Crew>();

                entity.HasOne(e => e.Plane)
                        .WithOne()
                        .HasForeignKey<Plane>();

                entity.HasOne(e => e.Flight)
                        .WithOne()
                        .HasForeignKey<Flight>();
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DepartureTime)
                        .IsRequired();
                entity.Property(e => e.DeparturePoint)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                entity.Property(e => e.ArrivalTime)
                        .IsRequired();
                entity.Property(e => e.Destination)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Price)
                        .IsRequired();
                entity.HasOne(e => e.Flight)
                        .WithMany(e => e.Tickets)
                        .HasForeignKey(e => e.FlightId);
            });

            // base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-N1FVMAR\MZSERVER;Database=BSA18_Task5;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
