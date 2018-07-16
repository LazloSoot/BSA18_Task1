using System;
using ProjectStructure.Databases.MSSQL;
using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using ProjectStructure.Infrastructure.BL;
using ProjectStructure.Infrastructure.Data.Aircraft;
using AutoMapper;
using ProjectStructure.Infrastructure.Shared;
using System.Collections.Generic;

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
                    .ForMember(p => p.Id, opt => opt.MapFrom(pt => pt.Id))
                    .ForMember(p => p.Model, opt => opt.MapFrom(pt => pt.Model))
                    .ForMember(p => p.ModifiedDate, opt => opt.MapFrom(pt => DateTime.Now))
                    .ForMember(p => p.AddedDate, opt => opt.MapFrom(pt => DateTime.Now))
                    .ForMember(p => p.Planes, opt => opt.MapFrom(pt => new List<Plane>()));
            }).CreateMapper();

            PlaneType ptDto = m.Map<PlaneType>(new PlaneTypeDTO()
            {
                Capacity = 123,
                CargoCapacity = 123214,
                Id = 14,
                Model = "testModel"
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
