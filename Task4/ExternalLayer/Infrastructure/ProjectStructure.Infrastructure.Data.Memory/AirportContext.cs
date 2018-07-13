using ProjectStructure.Domain;
using ProjectStructure.Domain.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectStructure.Infrastructure.Data.Memory
{
    public sealed class AirportContext : IAirportContext, IDisposable
    {
        public ICollection<Flight> Flights { get; set; }
        public ICollection<Departure> Departures { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
       
        public ICollection<Plane> Planes { get; set; }
        public ICollection<PlaneType> PlaneTypes { get; set; }
     
        public ICollection<Crew> Crews { get; set; }
        public ICollection<Pilot> Pilots { get; set; }
        public ICollection<Stewardess> Stewardesses { get; set; }

        public AirportContext()
        {
            SeedCrews();
            SeedPlanes();
            SeedFlights();
            SeedDepartures();
        }

        private void SeedCrews()
        {
            Pilots = new List<Pilot>()
            {
               new Pilot()
               {
                   Id= 1,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1978, 10,2),
                   ExperienceYears = 16,
                   Name = "Ivan",
                   Surname = "Petrov"
               },
               new Pilot()
               {
                   Id= 2,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1987, 2,1),
                   ExperienceYears = 5,
                   Name = "Jack",
                   Surname = "Key"
               },
               new Pilot()
               {
                   Id= 3,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1988, 1,25),
                   ExperienceYears = 10,
                   Name = "Petr",
                   Surname = "Swin"
               },
               new Pilot()
               {
                   Id= 4,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1991, 6,16),
                   ExperienceYears = 6,
                   Name = "Misha",
                   Surname = "Mavashy"
               }
            };

            Stewardesses = new List<Stewardess>()
            {
                new Stewardess()
                {
                   Id= 1,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1988, 1,25),
                   Name = "Tetia",
                   Surname = "Motia"
                },
                new Stewardess()
                {
                   Id= 2,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1989, 11,1),
                   Name = "Kateryna",
                   Surname = "Valuk"
                },
                new Stewardess()
                {
                   Id= 3,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1993, 5,18),
                   Name = "Alena",
                   Surname = "Malena"
                },
                new Stewardess()
                {
                   Id= 4,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1997, 2,15),
                   Name = "Marina",
                   Surname = "Kalina"
                },
                new Stewardess()
                {
                   Id= 5,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1988, 1,25),
                   Name = "Elena",
                   Surname = "Trojanskaja"
                },
                new Stewardess()
                {
                   Id= 6,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1989, 1,25),
                   Name = "Galina",
                   Surname = "Gonchar"
                },
                new Stewardess()
                {
                   Id= 7,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1995, 2, 5),
                   Name = "Anna",
                   Surname = "Petrova"
                },
                new Stewardess()
                {
                   Id= 8,
                   ModifiedDate = DateTime.Now,
                   AddedDate = DateTime.Now,
                   Birth = new DateTime(1995, 1,11),
                   Name = "Maria",
                   Surname = "Deva"
                }
            };

            Crews = new List<Crew>()
            {
                new Crew(Pilots.First(), Stewardesses.Take(2))
                {
                    Id = 1,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now
                },
                new Crew(Pilots.Skip(1).Take(1).First(), Stewardesses.Skip(2).Take(3))
                {
                    Id = 2,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now
                },
                new Crew(Pilots.TakeLast(1).First(), Stewardesses.TakeLast(3))
                {
                    Id = 3,
                    ModifiedDate = DateTime.Now,
                    AddedDate = DateTime.Now
                }
            };
        }

        private void SeedPlanes()
        {
            PlaneTypes = new List<PlaneType>()
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

            Planes = new List<Plane>()
            {
                new Plane(PlaneTypes.First())
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900,0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2017, 1, 1)
                },
                new Plane(PlaneTypes.First())
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(900,0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2016, 5, 20)
                },
                new Plane(PlaneTypes.Skip(1).First())
                {
                    Id = 3,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Lifetime = new TimeSpan(350,0, 0, 0),
                    Name = "Samolet",
                    ReleaseDate = new DateTime(2017, 8, 5)
                }
            };
        }

        private void SeedFlights()
        {
            Flights = new List<Flight>()
            {
                new Flight()
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 10, 12, 0,0 ),
                    DeparturePoint = "Odessa",
                    Destination = "Kiev",
                    ModifiedDate = DateTime.Now
                },
                new Flight()
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 11, 13, 0,0 ),
                    DeparturePoint = "Kiev",
                    Destination = "Odessa",
                    ModifiedDate = DateTime.Now
                }
            };

            Tickets = new List<Ticket>();

            int ticketPrice = 80;
            int delta = 25;
            Ticket ticketTemp;
            List<Flight> flightsTemp = new List<Flight>()
            {
                new Flight()
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 10, 12, 0,0 ),
                    DeparturePoint = "Odessa",
                    Destination = "Kiev",
                    ModifiedDate = DateTime.Now
                },
                new Flight()
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
                    ArrivalTime = new DateTime(2018, 8, 11, 13, 0,0 ),
                    DeparturePoint = "Kiev",
                    Destination = "Odessa",
                    ModifiedDate = DateTime.Now
                }
            };

            int cIndex = 0;
            int ticketId = 0;
            for (int i = 0; i < flightsTemp.Count; i++)
            {
                cIndex = i;
                for (int j = 0; j < 100; j++)
                {
                    ticketTemp = new Ticket()
                    {
                        Id = ++ticketId,
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        FlightId = flightsTemp[cIndex].Id,
                        Price = j > 20 ? ticketPrice : ticketPrice + delta
                    };

                    if (j == 80)
                        delta += 37;

                    Tickets.Add(ticketTemp);
                }
                flightsTemp[cIndex].Tickets = Tickets.Where(t => t.FlightId == flightsTemp[cIndex].Id);
            }

            Flights = flightsTemp;
        }

        private void SeedDepartures()
        {
            Departures = new List<Departure>()
            {
                new Departure(Crews.First(), Planes.First())
                {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                    FlightId = 1
                },
                new Departure(Crews.Skip(1).First(), Planes.Skip(1).First())
                {
                    Id = 2,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    DepartureTime = new DateTime(2018, 8, 11, 12, 0, 0),
                    FlightId = 2
                }
            };
        }

        public void Dispose()
        {
            
        }
    }
}
