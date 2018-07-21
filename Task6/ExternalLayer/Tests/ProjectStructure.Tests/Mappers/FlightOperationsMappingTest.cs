using System;
using System.Collections.Generic;
using mapperToTest = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Shared;
using NUnit.Framework;
using System.Linq;

namespace ProjectStructure.Tests.Mappers
{
    [TestFixture]
    public class FlightOperationsMappingTest
    {
        private readonly static Random rnd = new Random();

        #region Flight

        [Test]
        [TestCase(1000)]
        public void Flight_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Flight> flightIdFlight = new Dictionary<int, Flight>();
            Flight currentFlight = null;
            Dictionary<int, FlightDTO> flightIdFlightDTO = new Dictionary<int, FlightDTO>();
            int id = 0;
            int ticketsCount;
            List<Ticket> currentTickets = new List<Ticket>();

            for (int j = 0; j < assertionsCount; j++)
            {
                ticketsCount = rnd.Next(40, 150);
                for (int i = 0; i < ticketsCount; i++)
                {
                    currentTickets.Add(new Ticket() { Id = rnd.Next(0, 10000) });
                }

                currentFlight = new Flight()
                {
                    Id = id,
                    DepartureTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29)),
                    ArrivalTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(1, 23), rnd.Next(1, 59), 0),
                    DeparturePoint = $"Kiev{id}",
                    Destination = $"Odessa{id}",
                    Tickets = currentTickets
                };

                flightIdFlight.Add
                    (
                        id,
                        currentFlight
                    );

                flightIdFlightDTO.Add
                    (
                        id,
                        mapper.Map<FlightDTO>(currentFlight)
                    );

                id++;
                currentTickets = new List<Ticket>();
            }

            // assert
            List<long> flightDtoTickets;
            for (int i = 0; i < flightIdFlight.Count; i++)
            {
                Assert.AreEqual(flightIdFlight[i].Id, flightIdFlightDTO[i].Id);
                Assert.AreEqual(flightIdFlight[i].DepartureTime, flightIdFlightDTO[i].DepartureTime);
                Assert.AreEqual(flightIdFlight[i].DeparturePoint, flightIdFlightDTO[i].DeparturePoint);
                Assert.AreEqual(flightIdFlight[i].Destination, flightIdFlightDTO[i].Destination);
                Assert.AreEqual(flightIdFlight[i].ArrivalTime, flightIdFlightDTO[i].ArrivalTime);
                Assert.AreEqual(flightIdFlight[i].Tickets.Count, flightIdFlightDTO[i].TicketsIds.Count());

                flightDtoTickets = flightIdFlightDTO[i].TicketsIds.ToList();
                ticketsCount = flightDtoTickets.Count;
                foreach (var t in flightIdFlight[i].Tickets)
                {
                    Assert.Contains(t.Id, flightDtoTickets);
                }
            }

        }

        [Test]
        [TestCase(1000)]
        public void Flight_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, FlightDTO> flightIdFlightDTO = new Dictionary<int, FlightDTO>();
            FlightDTO currentFlightDTO = null;
            Dictionary<int, Flight> flightIdFlight = new Dictionary<int, Flight>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentFlightDTO = new FlightDTO()
                {
                    DepartureTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29)),
                    ArrivalTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29), rnd.Next(1, 23), rnd.Next(1, 59), 0),
                    DeparturePoint = $"Kiev{id}",
                    Destination = $"Odessa{id}"
                };

                flightIdFlightDTO.Add
                    (
                        id,
                        currentFlightDTO
                    );

                flightIdFlight.Add
                    (
                        id,
                        mapper.Map<Flight>(currentFlightDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < flightIdFlight.Count; i++)
            {
                Assert.AreEqual(flightIdFlightDTO[i].ArrivalTime, flightIdFlight[i].ArrivalTime);
                Assert.AreEqual(flightIdFlightDTO[i].DeparturePoint, flightIdFlight[i].DeparturePoint);
                Assert.AreEqual(flightIdFlightDTO[i].Destination, flightIdFlight[i].Destination);
                Assert.AreEqual(flightIdFlightDTO[i].DepartureTime, flightIdFlight[i].DepartureTime);
            }
        }

        #endregion

        #region Departure

        [Test]
        [TestCase(1000)]
        public void Departure_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Departure> departureIdDeparture = new Dictionary<int, Departure>();
            Departure currentDeparture = null;
            Dictionary<int, DepartureDTO> departureIdDepartureDTO = new Dictionary<int, DepartureDTO>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentDeparture = new Departure()
                {
                    Id = id,
                    DepartureTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29)),
                    CrewId = rnd.Next(0, 10000),
                    FlightId = rnd.Next(0, 10000),
                    PlaneId = rnd.Next(0, 10000)
                };

                departureIdDeparture.Add
                    (
                        id,
                        currentDeparture
                    );

                departureIdDepartureDTO.Add
                    (
                        id,
                        mapper.Map<DepartureDTO>(currentDeparture)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < departureIdDeparture.Count; i++)
            {
                Assert.AreEqual(departureIdDeparture[i].Id, departureIdDepartureDTO[i].Id);
                Assert.AreEqual(departureIdDeparture[i].FlightId, departureIdDepartureDTO[i].FlightId);
                Assert.AreEqual(departureIdDeparture[i].CrewId, departureIdDepartureDTO[i].CrewId);
                Assert.AreEqual(departureIdDeparture[i].PlaneId, departureIdDepartureDTO[i].PlaneId);
                Assert.AreEqual(departureIdDeparture[i].DepartureTime, departureIdDepartureDTO[i].DepartureTime);
            }

        }

        [Test]
        [TestCase(1000)]
        public void Departure_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, DepartureDTO> departureIdDepartureDTO = new Dictionary<int, DepartureDTO>();
            DepartureDTO currentDepartureDTO = null;
            Dictionary<int, Departure> departureIdDeparture = new Dictionary<int, Departure>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentDepartureDTO = new DepartureDTO()
                {
                    DepartureTime = new DateTime(2018, rnd.Next(1, 13), rnd.Next(1, 29)),
                    CrewId = rnd.Next(0, 10000),
                    FlightId = rnd.Next(0, 10000),
                    PlaneId = rnd.Next(0, 10000)
                };

                departureIdDepartureDTO.Add
                    (
                        id,
                        currentDepartureDTO
                    );

                departureIdDeparture.Add
                    (
                        id,
                        mapper.Map<Departure>(currentDepartureDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < departureIdDeparture.Count; i++)
            {
                Assert.AreEqual(departureIdDepartureDTO[i].CrewId, departureIdDeparture[i].CrewId);
                Assert.AreEqual(departureIdDepartureDTO[i].PlaneId, departureIdDeparture[i].PlaneId);
                Assert.AreEqual(departureIdDepartureDTO[i].FlightId, departureIdDeparture[i].FlightId);
                Assert.AreEqual(departureIdDepartureDTO[i].DepartureTime, departureIdDeparture[i].DepartureTime);
            }
        }

        #endregion

        #region Ticket

        [Test]
        [TestCase(1000)]
        public void Ticket_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Ticket> ticketIdTicket = new Dictionary<int, Ticket>();
            Ticket currentTicket = null;
            Dictionary<int, TicketDTO> ticketIdTicketDTO = new Dictionary<int, TicketDTO>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentTicket = new Ticket()
                {
                    Id = id,
                    Price = rnd.Next(15, 10000),
                    Seat = rnd.Next(0, 10000)
                };

                ticketIdTicket.Add
                    (
                        id,
                        currentTicket
                    );

                ticketIdTicketDTO.Add
                    (
                        id,
                        mapper.Map<TicketDTO>(currentTicket)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < ticketIdTicket.Count; i++)
            {
                Assert.AreEqual(ticketIdTicket[i].Price, ticketIdTicketDTO[i].Price);
                Assert.AreEqual(ticketIdTicket[i].Seat, ticketIdTicketDTO[i].Seat);
            }

        }

        [Test]
        [TestCase(1000)]
        public void Ticket_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, TicketDTO> ticketIdTicketDTO = new Dictionary<int, TicketDTO>();
            TicketDTO currentTicketDTO = null;
            Dictionary<int, Ticket> ticketIdTicket = new Dictionary<int, Ticket>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentTicketDTO = new TicketDTO()
                {
                    Id = id,
                    Price = rnd.Next(15, 1000),
                    Seat = rnd.Next(0, 1000)
                };

                ticketIdTicketDTO.Add
                    (
                        id,
                        currentTicketDTO
                    );

                ticketIdTicket.Add
                    (
                        id,
                        mapper.Map<Ticket>(currentTicketDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < ticketIdTicket.Count; i++)
            {
                Assert.AreEqual(ticketIdTicketDTO[i].Id, ticketIdTicket[i].Id);
                Assert.AreEqual(ticketIdTicketDTO[i].Price, ticketIdTicket[i].Price);
                Assert.AreEqual(ticketIdTicketDTO[i].Seat, ticketIdTicket[i].Seat);
            }
        }

        #endregion
    }
}
