using AutoMapper;
using ProjectStructure.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStructure.Infrastructure.Shared.Mappings
{
    public class AutoMapper
    {
        public static IMapper GetDefaultMapper()
        {
           return new MapperConfiguration(cfg =>
            {
                #region Aircraft

                cfg.CreateMap<PlaneTypeDTO, PlaneType>()
                    .ForMember(p => p.Capacity, opt => opt.MapFrom(pt => pt.Capacity))
                    .ForMember(p => p.CargoCapacity, opt => opt.MapFrom(pt => pt.CargoCapacity))
                    .ForMember(p => p.Model, opt => opt.MapFrom(pt => pt.Model));
                cfg.CreateMap<PlaneType, PlaneTypeDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.Capacity, opt => opt.MapFrom(pt => pt.Capacity))
                    .ForMember(p => p.CargoCapacity, opt => opt.MapFrom(pt => pt.CargoCapacity))
                    .ForMember(p => p.Model, opt => opt.MapFrom(pt => pt.Model));

                cfg.CreateMap<PlaneDTO, Plane>()
                    .ForMember(p => p.Lifetime, opt => opt.MapFrom(po => po.Lifetime))
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.Lifetime, opt => opt.MapFrom(po => po.Lifetime))
                    .ForMember(p => p.LastHeavyMaintenance, opt => opt.MapFrom(po => po.LastHeavyMaintenance))
                    .ForMember(p => p.ReleaseDate, opt => opt.MapFrom(po => po.ReleaseDate))
                    .ForMember(p => p.TypeId, opt => opt.MapFrom(po => po.PlaneTypeId));
                cfg.CreateMap<Plane, PlaneDTO>()
                   .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                   .ForMember(p => p.Lifetime, opt => opt.MapFrom(po => po.Lifetime))
                   .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.LastHeavyMaintenance, opt => opt.MapFrom(po => po.LastHeavyMaintenance))
                   .ForMember(p => p.ReleaseDate, opt => opt.MapFrom(po => po.ReleaseDate))
                   .ForMember(p => p.PlaneTypeId, opt => opt.MapFrom(po => po.TypeId));

                #endregion

                #region Crewing

                cfg.CreateMap<Crew, CrewDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.PilotId, opt => opt.MapFrom(po => po.Pilot.Id))
                    .ForMember(p => p.StewardessesIds, opt => opt.MapFrom(po => po.Stewardesses.Select(c => c.Id)));

                cfg.CreateMap<PilotDTO, Pilot>()
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.Surname, opt => opt.MapFrom(po => po.Surname))
                    .ForMember(p => p.ExperienceYears, opt => opt.MapFrom(po => po.ExperienceYears))
                    .ForMember(p => p.Birth, opt => opt.MapFrom(po => po.Birth));
                cfg.CreateMap<Pilot, PilotDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.Surname, opt => opt.MapFrom(po => po.Surname))
                    .ForMember(p => p.ExperienceYears, opt => opt.MapFrom(po => po.ExperienceYears))
                    .ForMember(p => p.Birth, opt => opt.MapFrom(po => po.Birth));

                cfg.CreateMap<StewardessDTO, Stewardess>()
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.Surname, opt => opt.MapFrom(po => po.Surname))
                    .ForMember(p => p.Birth, opt => opt.MapFrom(po => po.Birth));
                cfg.CreateMap<Stewardess, StewardessDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.Surname, opt => opt.MapFrom(po => po.Surname))
                    .ForMember(p => p.Birth, opt => opt.MapFrom(po => po.Birth));


                cfg.CreateMap<CrewExtendedDTO, Crew>()
                    .ForMember(p => p.Pilot, opt => opt.MapFrom(po => po.PilotDTO.FirstOrDefault()))
                    .ForMember(p => p.Stewardesses, opt => opt.MapFrom(po => po.StewardessesDtos));
                cfg.CreateMap<Crew, CrewExtendedDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.PilotDTO, opt => opt.MapFrom(po => new List<Pilot>() { po.Pilot }))
                    .ForMember(p => p.StewardessesDtos, opt => opt.MapFrom(po => po.Stewardesses));
                #endregion

                #region FlightsOperations

                cfg.CreateMap<TicketDTO, Ticket>()
                    .ForMember(p => p.Price, opt => opt.MapFrom(po => po.Price))
                    .ForMember(p => p.Seat, opt => opt.MapFrom(po => po.Seat));
                cfg.CreateMap<Ticket, TicketDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.Price, opt => opt.MapFrom(po => po.Price))
                    .ForMember(p => p.Seat, opt => opt.MapFrom(po => po.Seat));

                cfg.CreateMap<FlightDTO, Flight>()
                    .ForMember(p => p.ArrivalTime, opt => opt.MapFrom(po => po.ArrivalTime))
                    .ForMember(p => p.DeparturePoint, opt => opt.MapFrom(po => po.DeparturePoint))
                    .ForMember(p => p.DepartureTime, opt => opt.MapFrom(po => po.DepartureTime))
                    .ForMember(p => p.Destination, opt => opt.MapFrom(po => po.Destination));
                cfg.CreateMap<Flight, FlightDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.ArrivalTime, opt => opt.MapFrom(po => po.ArrivalTime))
                    .ForMember(p => p.DeparturePoint, opt => opt.MapFrom(po => po.DeparturePoint))
                    .ForMember(p => p.DepartureTime, opt => opt.MapFrom(po => po.DepartureTime))
                    .ForMember(p => p.Destination, opt => opt.MapFrom(po => po.Destination))
                    .ForMember(p => p.TicketsIds, opt => opt.MapFrom(po => po.Tickets.Select(t => t.Id)));

                cfg.CreateMap<DepartureDTO, Departure>()
                    .ForMember(p => p.DepartureTime, opt => opt.MapFrom(po => po.DepartureTime))
                    .ForMember(p => p.CrewId, opt => opt.MapFrom(po => po.CrewId))
                    .ForMember(p => p.PlaneId, opt => opt.MapFrom(po => po.PlaneId))
                    .ForMember(p => p.FlightId, opt => opt.MapFrom(po => po.FlightId));
                ;
                cfg.CreateMap<Departure, DepartureDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.DepartureTime, opt => opt.MapFrom(po => po.DepartureTime))
                    .ForMember(p => p.CrewId, opt => opt.MapFrom(po => po.CrewId))
                    .ForMember(p => p.PlaneId, opt => opt.MapFrom(po => po.PlaneId))
                    .ForMember(p => p.FlightId, opt => opt.MapFrom(po => po.FlightId));

                #endregion

            }).CreateMapper();
        }
    }
}
