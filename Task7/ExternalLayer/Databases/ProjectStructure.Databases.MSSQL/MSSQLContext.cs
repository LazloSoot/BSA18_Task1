using Microsoft.EntityFrameworkCore;
using ProjectStructure.Infrastructure.Data;
using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Databases.MSSQL
{
    public class MSSQLContext : AirportContext
    {
        public MSSQLContext()
        {
            Database.EnsureCreated();
        }

        
        
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
                entity.Ignore(c => c.Lifetime);
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
                        .HasForeignKey<Departure>(e => e.CrewId);

                entity.HasOne(e => e.Plane)
                        .WithOne()
                        .HasForeignKey<Departure>(e => e.PlaneId);

                entity.HasOne(e => e.Flight)
                        .WithOne()
                        .HasForeignKey<Departure>(e => e.FlightId);
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

             SeedCrews(modelBuilder);
             SeedPlanes(modelBuilder);
             SeedFlights(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-N1FVMAR\MZSERVER;Database=BSA18_Task5;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }


        private void SeedCrews(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pilot>().HasData(
                new Pilot()
                {
                    Id = 1,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1978, 10, 2),
                    ExperienceYears = 16,
                    Name = "Ivan",
                    Surname = "Petrov"
                },
                new Pilot()
                {
                    Id = 2,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1987, 2, 1),
                    ExperienceYears = 5,
                    Name = "Jack",
                    Surname = "Key"
                },
                new Pilot()
                {
                    Id = 3,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1988, 1, 25),
                    ExperienceYears = 10,
                    Name = "Petr",
                    Surname = "Swin"
                },
                new Pilot()
               {
                   Id = 4,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1991, 6, 16),
                   ExperienceYears = 6,
                   Name = "Misha",
                   Surname = "Mavashy"
               }
                );

            modelBuilder.Entity<Stewardess>().HasData(
                new Stewardess()
                {
                    Id = 1,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1988, 1, 25),
                    Name = "Tetia",
                    Surname = "Motia"
                },
                new Stewardess()
                {
                    Id = 2,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1989, 11, 1),
                    Name = "Kateryna",
                    Surname = "Valuk"
                },
                new Stewardess()
                {
                    Id = 3,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1993, 5, 18),
                    Name = "Alena",
                    Surname = "Malena"
                },
                new Stewardess()
                {
                    Id = 4,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1997, 2, 15),
                    Name = "Marina",
                    Surname = "Kalina"
                },
                new Stewardess()
                {
                    Id = 5,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1988, 1, 25),
                    Name = "Elena",
                    Surname = "Trojanskaja"
                },
                new Stewardess()
                {
                    Id = 6,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1989, 1, 25),
                    Name = "Galina",
                    Surname = "Gonchar"
                },
                new Stewardess()
                {
                    Id = 7,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1995, 2, 5),
                    Name = "Anna",
                    Surname = "Petrova"
                },
                new Stewardess()
                {
                    Id = 8,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Birth = new DateTime(1995, 1, 11),
                    Name = "Maria",
                    Surname = "Deva"
                }
                );
        }

        private void SeedPlanes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneType>().HasData(
                new PlaneType()
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Capacity = 100,
                    CargoCapacity = 5000,
                    Model = "IL-207"
                },
                new PlaneType()
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Capacity = 100,
                    CargoCapacity = 7500,
                    Model = "IL-12M"
                },
                new PlaneType()
                {
                    Id = 3,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Capacity = 200,
                    CargoCapacity = 7000,
                    Model = "Jk-21/2n"
                }
                );

            DateTime dt = DateTime.Now - new TimeSpan(2500, 0, 0, 0, 0);
            modelBuilder.Entity<Plane>().HasData(
                new Plane()
                {
                    Id = (long)1,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                    Name = "Edelvejs",
                    ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0),
                    FlightHours = 15,
                    LastHeavyMaintenance = DateTime.Now,
                    TypeId = (long)1
                },
                new Plane()
                {
                    Id = (long)2,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900, 0, 0, 0),
                    Name = "Malutka",
                    FlightHours = 0,
                    LastHeavyMaintenance = DateTime.Now,
                    ReleaseDate = new DateTime(2016, 5, 20, 0, 0, 0),
                    TypeId = (long)1
                },
                new Plane()
                {
                    Id = (long)3,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(350, 0, 0, 0),
                    Name = "Redhook",
                    LastHeavyMaintenance = dt,
                    ReleaseDate = new DateTime(2017, 8, 5, 0, 0, 0),
                    FlightHours = 400,
                    TypeId = (long)2
                }
                );
        }

        private void SeedFlights(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData
                (
                new Flight()
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                    DeparturePoint = "Odessa",
                    Destination = "Kiev",
                    ModifiedDate = DateTime.Now
                },
                new Flight()
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 11, 13, 0, 0),
                    DeparturePoint = "Kiev",
                    Destination = "Odessa",
                    ModifiedDate = DateTime.Now
                }
                );
        }

    }
}
