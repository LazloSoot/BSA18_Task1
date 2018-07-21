using System;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Infrastructure.Data.Aircraft;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var m = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PlaneTypeDTO, PlaneType>()
                    .ForMember(p => p.Capacity, opt => opt.MapFrom(pt => pt.Capacity))
                    .ForMember(p => p.CargoCapacity, opt => opt.MapFrom(pt => pt.CargoCapacity))
                    .ForMember(p => p.Model, opt => opt.MapFrom(pt => pt.Model));

                cfg.CreateMap<PlaneDTO, Plane>()
                    .ForMember(p => p.Lifetime, opt => opt.MapFrom(po => po.Lifetime))
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.ReleaseDate, opt => opt.MapFrom(po => po.ReleaseDate));
                //  .ForMember(p => p.Type, opt => opt.MapFrom(po => po.Type));

                cfg.CreateMap<Plane, PlaneDTO>()
                    .ForMember(p => p.Lifetime, opt => opt.MapFrom(po => po.Lifetime))
                    .ForMember(p => p.Name, opt => opt.MapFrom(po => po.Name))
                    .ForMember(p => p.ReleaseDate, opt => opt.MapFrom(po => po.ReleaseDate))
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.PlaneTypeId, opt => opt.MapFrom(po => po.TypeId));

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

                cfg.CreateMap<Crew, CrewDTO>()
                    .ForMember(p => p.Id, opt => opt.MapFrom(po => po.Id))
                    .ForMember(p => p.PilotId, opt => opt.MapFrom(po => po.Pilot.Id))
                    .ForMember(p => p.StewardessesIds, opt => opt.MapFrom(po => po.Stewardesses.Select(c => c.Id)));

            }).CreateMapper();

            PlaneType ptDto = m.Map<PlaneType>(new PlaneTypeDTO()
            {
                Capacity = 123,
                CargoCapacity = 123214,
                Id = 14,
                Model = "testModel"
            });

            

            var pp = m.Map<Plane>(new PlaneDTO()
            {
                Lifetime = new TimeSpan(1, 1, 1),
                Name = "name",
                ReleaseDate = DateTime.Now
                //Type = new PlaneTypeDTO()
                //{
                //    Capacity = 123,
                //    CargoCapacity = 123214,
                //    Id = 14,
                //    Model = "testModel"
                //}
            });

            PlaneDTO d = m.Map<PlaneDTO>(pp);

            List<Plane> planes = m.Map<List<Plane>>(new List<PlaneDTO>()
            {
                new PlaneDTO()
            {
                Lifetime = new TimeSpan(1, 1, 1),
                Name = "name",
                ReleaseDate = DateTime.Now
            },
                new PlaneDTO()
            {
                Lifetime = new TimeSpan(1, 1, 1),
                Name = "name",
                ReleaseDate = DateTime.Now
            }
            });
              var succesful = TestMapping(ptDto);

            //MSSQLContext context = new MSSQLContext();

            //context.Tickets.Add(new ProjectStructure.Domain.Ticket()
            //{
            //    Price = 1000
            //});
            Console.ReadLine();
        }

        static bool TestMapping(PlaneType planeType)
        {
            if (planeType != null && planeType is PlaneType)
                return true;
            return false;
        }
    }
}
