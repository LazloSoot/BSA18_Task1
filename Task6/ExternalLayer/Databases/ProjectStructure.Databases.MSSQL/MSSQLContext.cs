﻿using Microsoft.EntityFrameworkCore;
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

            SeedCrews(modelBuilder);
            SeedPlanes(modelBuilder);
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


        private void SeedCrews(ModelBuilder modelBuilder)
        {
            var pilot1 = new Pilot()
            {
                 Id = 1,
                ModifiedDate = DateTime.Now,
                AddedDate = DateTime.Now,
                Birth = new DateTime(1978, 10, 2),
                ExperienceYears = 16,
                Name = "Ivan",
                Surname = "Petrov"
            };
            var pilot2 = new Pilot()
            {
                 Id = 2,
                ModifiedDate = DateTime.Now,
                AddedDate = DateTime.Now,
                Birth = new DateTime(1987, 2, 1),
                ExperienceYears = 5,
                Name = "Jack",
                Surname = "Key"
            };
            var pilot3 = new Pilot()
            {
                Id = 3,
                ModifiedDate = DateTime.Now,
                AddedDate = DateTime.Now,
                Birth = new DateTime(1988, 1, 25),
                ExperienceYears = 10,
                Name = "Petr",
                Surname = "Swin"
            };
            modelBuilder.Entity<Pilot>().HasData(
                pilot1, pilot2, pilot3,
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

            List<Stewardess> st = new List<Stewardess>()
            {
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
            };

            modelBuilder.Entity<Stewardess>().HasData(
                st.ToArray()
                );

            modelBuilder.Entity<Crew>().HasData(
                new Crew// (Pilots.First(), Stewardesses.Take(2))
                {
                    //  Id = 1,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now,
                    Pilot = pilot1,
                    Stewardesses = st.Take(3).ToList()
                },
                new Crew(Pilots.Skip(1).First(), Stewardesses.Skip(2).Take(3).ToList())
                {
                    Id = 2,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now
                },
                new Crew(Pilots.TakeLast(1).First(), Stewardesses.TakeLast(2).ToList())
                {
                    Id = 3,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now
                }
                );
        }

        private void SeedPlanes(ModelBuilder modelBuilder)
        {
            var pt = new List<PlaneType>()
            {
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
            };

            modelBuilder.Entity<PlaneType>().HasData(
                pt.ToArray()
                );

            modelBuilder.Entity<Plane>().HasData(
                new Plane(PlaneTypes.First())
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900, 0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2017, 1, 1),
                    Type = pt[0]
                },
                new Plane(PlaneTypes.First())
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900, 0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2016, 5, 20),
                    Type = pt[1]
                },
                new Plane(PlaneTypes.Skip(1).First())
                {
                    Id = 3,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(350, 0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2017, 8, 5),
                    Type = pt[2]
                }
                );
        }

        //private void SeedFlights()
        //{
        //    Flights = new List<Flight>()
        //    {
        //        new Flight()
        //        {
        //            Id = 1,
        //            AddedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
        //            ArrivalTime = new DateTime(2018, 8, 10, 12, 0,0 ),
        //            DeparturePoint = "Odessa",
        //            Destination = "Kiev",
        //            ModifiedDate = DateTime.Now
        //        },
        //        new Flight()
        //        {
        //            Id = 2,
        //            AddedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
        //            ArrivalTime = new DateTime(2018, 8, 11, 13, 0,0 ),
        //            DeparturePoint = "Kiev",
        //            Destination = "Odessa",
        //            ModifiedDate = DateTime.Now
        //        }
        //    };

        //    Tickets = new List<Ticket>();

        //    int ticketPrice = 80;
        //    int delta = 25;
        //    Ticket ticketTemp;
        //    List<Flight> flightsTemp = new List<Flight>()
        //    {
        //        new Flight()
        //        {
        //            Id = 1,
        //            AddedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
        //            ArrivalTime = new DateTime(2018, 8, 10, 12, 0,0 ),
        //            DeparturePoint = "Odessa",
        //            Destination = "Kiev",
        //            ModifiedDate = DateTime.Now
        //        },
        //        new Flight()
        //        {
        //            Id = 2,
        //            AddedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
        //            ArrivalTime = new DateTime(2018, 8, 11, 13, 0,0 ),
        //            DeparturePoint = "Kiev",
        //            Destination = "Odessa",
        //            ModifiedDate = DateTime.Now
        //        }
        //    };

        //    int cIndex = 0;
        //    int ticketId = 0;
        //    for (int i = 0; i < flightsTemp.Count; i++)
        //    {
        //        cIndex = i;
        //        for (int j = 0; j < 100; j++)
        //        {
        //            ticketTemp = new Ticket()
        //            {
        //                Id = ++ticketId,
        //                AddedDate = DateTime.Now,
        //                ModifiedDate = DateTime.Now,
        //                FlightId = flightsTemp[cIndex].Id,
        //                Price = j > 20 ? ticketPrice : ticketPrice + delta
        //            };

        //            if (j == 80)
        //                delta += 37;

        //            Tickets.Add(ticketTemp);
        //        }
        //        flightsTemp[cIndex].Tickets = Tickets.Where(t => t.FlightId == flightsTemp[cIndex].Id);
        //    }

        //    Flights = flightsTemp;
        //}

        //private void SeedDepartures()
        //{
        //    Departures = new List<Departure>()
        //    {
        //        new Departure(Crews.First(), Planes.First())
        //        {
        //            Id = 1,
        //            AddedDate = DateTime.Now,
        //            ModifiedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
        //            FlightId = 1
        //        },
        //        new Departure(Crews.Skip(1).First(), Planes.Skip(1).First())
        //        {
        //            Id = 2,
        //            AddedDate = DateTime.Now,
        //            ModifiedDate = DateTime.Now,
        //            DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
        //            FlightId = 2
        //        }
        //    };
        //}

    }
}
