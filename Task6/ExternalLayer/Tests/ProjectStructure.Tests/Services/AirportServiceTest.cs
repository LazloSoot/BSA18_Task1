using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Services.Interfaces;

namespace ProjectStructure.Tests.Services
{
    [TestFixture]
    public class AirportServiceTest
    {
        [Test]
        public void SheduleDepartureTest_When_Flight_NotExist_And_FlightId_IsDefined_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(default(Flight));

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = 1,
                FlightId = flightId,
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_Flight_NotExist_And_Flight_IsDefined_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(default(Flight));

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = 1,
                Flight = new Flight() { Id = flightId }
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_Flight_And_FlightId_IsNot_Defined_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = 1
            };

            // act 
            // assert
            Assert.Throws<ArgumentNullException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_Flight_IsExist_But_DepartureDateTime_IsNot_Correspond_To_FlightDatetime_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;

            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(1993, 8, 10, 11, 0, 0),
                PlaneId = 1,
                FlightId = flightId,
            };
            var departure2 = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 3, 10, 11, 0, 0),
                PlaneId = 1,
                FlightId = flightId,
            };
            var departure3 = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 8, 10, 12, 0, 0),
                PlaneId = 1,
                FlightId = flightId,
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure2);
            }));
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure3);
            }));
        }


        [Test]
        public void SheduleDepartureTest_When_Flight_IsOk_But_Plane_Lifetime_Has_Expired_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;
            long planeId = 1;
            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            var plane = new Plane
            {
                Id = planeId,
                Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                Name = "Edelvejs",
                ReleaseDate = new DateTime(2012, 1, 1, 0, 0, 0),
                FlightHours = 15,
                LastHeavyMaintenance = DateTime.Now,
                TypeId = 1
            };

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);
            aircraftMock.SetupSequence(e => e.GetPlaneInfo(planeId)).Returns(plane);

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = 1,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = planeId,
                FlightId = flightId
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_FlightPlaneCrew_IsOk_But_Crew_HasNot_Pilot_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;
            long planeId = 1;
            long crewId = 1;
            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            var plane = new Plane
            {
                Id = planeId,
                Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                Name = "Edelvejs",
                ReleaseDate = DateTime.Now,
                FlightHours = 15,
                LastHeavyMaintenance = DateTime.Now,
                TypeId = 1
            };
            var crew = new Crew()
            {
                Id = crewId,
                Stewardesses = new List<Stewardess> { new Stewardess(), new Stewardess(), new Stewardess() }
            };

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);
            aircraftMock.SetupSequence(e => e.GetPlaneInfo(planeId)).Returns(plane);
            crewingMock.SetupSequence(e => e.GetIncludedCrewInfo(crewId, false)).Returns(crew);

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = crewId,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = planeId,
                FlightId = flightId
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_FlightPlaneCrew_IsOk_But_CrewPilot_HasNotEnough_Experience_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;
            long planeId = 1;
            long crewId = 1;
            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            var plane = new Plane
            {
                Id = planeId,
                Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                Name = "Edelvejs",
                ReleaseDate = DateTime.Now,
                FlightHours = 15,
                LastHeavyMaintenance = DateTime.Now,
                TypeId = 1
            };
            var crew = new Crew()
            {
                Id = crewId,
                Pilot = new Pilot() { ExperienceYears = 1},
                Stewardesses = new List<Stewardess> { new Stewardess(), new Stewardess(), new Stewardess() }
            };

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);
            aircraftMock.SetupSequence(e => e.GetPlaneInfo(planeId)).Returns(plane);
            crewingMock.SetupSequence(e => e.GetIncludedCrewInfo(crewId, false)).Returns(crew);

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = crewId,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = planeId,
                FlightId = flightId
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }


        [Test]
        public void SheduleDepartureTest_When_FlightPlaneCrew_IsOk_But_Crew_HasNotEnough_Stewardesses_Then_Throw_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;
            long planeId = 1;
            long crewId = 1;
            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            var plane = new Plane
            {
                Id = planeId,
                Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                Name = "Edelvejs",
                ReleaseDate = DateTime.Now,
                FlightHours = 15,
                LastHeavyMaintenance = DateTime.Now,
                TypeId = 1
            };
            var crew = new Crew()
            {
                Id = crewId,
                Pilot = new Pilot() { ExperienceYears = 1 },
                Stewardesses = new List<Stewardess> { new Stewardess()}
            };

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);
            aircraftMock.SetupSequence(e => e.GetPlaneInfo(planeId)).Returns(plane);
            crewingMock.SetupSequence(e => e.GetIncludedCrewInfo(crewId, false)).Returns(crew);
            
            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = crewId,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = planeId,
                FlightId = flightId
            };

            // act 
            // assert
            Assert.Throws<ArgumentException>(new TestDelegate(() =>
            {
                service.SheduleDeparture(departure);
            }));
        }

        [Test]
        public void SheduleDepartureTest_When_FlightPlaneCrew_IsOk_Then_NotThrow_Exception()
        {
            // Arrange
            var aircraftMock = new Mock<IAircraftService>();
            var crewingMock = new Mock<ICrewingService>();
            var flightOpMock = new Mock<IFlightOperationsService>();
            long flightId = 1;
            long planeId = 1;
            long crewId = 1;
            var flight = new Flight()
            {
                Id = flightId,
                AddedDate = DateTime.Now,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                ArrivalTime = new DateTime(2018, 8, 10, 12, 0, 0),
                DeparturePoint = "Odessa",
                Destination = "Kiev",
                ModifiedDate = DateTime.Now
            };
            var plane = new Plane
            {
                Id = planeId,
                Lifetime = new TimeSpan(900, 0, 0, 0, 0),
                Name = "Edelvejs",
                ReleaseDate = DateTime.Now,
                FlightHours = 15,
                LastHeavyMaintenance = DateTime.Now,
                TypeId = 1
            };
            var crew = new Crew()
            {
                Id = crewId,
                Pilot = new Pilot() { ExperienceYears = 11 },
                Stewardesses = new List<Stewardess> { new Stewardess(), new Stewardess(), new Stewardess() }
            };

            flightOpMock.SetupSequence(e => e.GetFlightInfo(flightId)).Returns(flight);
            aircraftMock.SetupSequence(e => e.GetPlaneInfo(planeId)).Returns(plane);
            crewingMock.SetupSequence(e => e.GetIncludedCrewInfo(crewId, false)).Returns(crew);
            

            var service = new AiroportService(aircraftMock.Object, crewingMock.Object, flightOpMock.Object);

            var departure = new Departure()
            {
                CrewId = crewId,
                DepartureTime = new DateTime(2018, 8, 10, 11, 0, 0),
                PlaneId = planeId,
                FlightId = flightId
            };

            // act 
            // assert
            Assert.DoesNotThrow(() => { service.SheduleDeparture(departure); });
        }

    }
}
