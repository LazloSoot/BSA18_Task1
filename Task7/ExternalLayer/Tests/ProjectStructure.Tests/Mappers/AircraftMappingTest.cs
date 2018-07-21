using System;
using System.Collections.Generic;
using NUnit.Framework;
using mapperToTest = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Shared;

namespace ProjectStructure.Tests.Mappers
{
    [TestFixture]
    public class AircraftMappingTest
    {
        private readonly static Random rnd = new Random();

        #region Plane

        [Test]
        [TestCase(1000)]
        public void Plane_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Plane> planeIdPlane = new Dictionary<int, Plane>();
            Plane currentPlane = null;
            Dictionary<int, PlaneDTO> PlaneIdPlaneDTO = new Dictionary<int, PlaneDTO>();
            int id = 0;


            for (int j = 0; j < assertionsCount; j++)
            {
                currentPlane = new Plane()
                {
                    Id = id,
                    Lifetime = new TimeSpan(rnd.Next(10000, 100000)),
                    FlightHours = rnd.Next(100, 15000),
                    LastHeavyMaintenance = new DateTime(rnd.Next(2001, 2018), 1,1),
                    Name = $"Plane{id}",
                    ReleaseDate = new DateTime(rnd.Next(1930, 2018), 1, 1),
                    TypeId = rnd.Next(0, 10000)
                };

                planeIdPlane.Add
                    (
                        id,
                        currentPlane
                    );

                PlaneIdPlaneDTO.Add
                    (
                        id,
                        mapper.Map<PlaneDTO>(currentPlane)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < planeIdPlane.Count; i++)
            {
                Assert.AreEqual(planeIdPlane[i].Id, PlaneIdPlaneDTO[i].Id);
                Assert.AreEqual(planeIdPlane[i].Lifetime, PlaneIdPlaneDTO[i].Lifetime);
                Assert.AreEqual(planeIdPlane[i].LastHeavyMaintenance, PlaneIdPlaneDTO[i].LastHeavyMaintenance);
                Assert.AreEqual(planeIdPlane[i].FlightHours, PlaneIdPlaneDTO[i].FlightHours);
                Assert.AreEqual(planeIdPlane[i].Name, PlaneIdPlaneDTO[i].Name);
                Assert.AreEqual(planeIdPlane[i].ReleaseDate, PlaneIdPlaneDTO[i].ReleaseDate);
                Assert.AreEqual(planeIdPlane[i].TypeId, PlaneIdPlaneDTO[i].PlaneTypeId);
            }

        }

        [Test]
        [TestCase(1000)]
        public void Plane_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, PlaneDTO> planeIdPlaneDTO = new Dictionary<int, PlaneDTO>();
            PlaneDTO currentPlaneDTO = null;
            Dictionary<int, Plane> planeIdPlane = new Dictionary<int, Plane>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentPlaneDTO = new PlaneDTO()
                {
                    Lifetime = new TimeSpan(rnd.Next(10000, 100000)),
                    FlightHours = rnd.Next(100, 15000),
                    LastHeavyMaintenance = new DateTime(rnd.Next(2001, 2018), 1, 1),
                    Name = $"Plane{id}",
                    ReleaseDate = new DateTime(rnd.Next(1930, 2018), 1, 1),
                    PlaneTypeId = rnd.Next(0, 10000)
                };

                planeIdPlaneDTO.Add
                    (
                        id,
                        currentPlaneDTO
                    );

                planeIdPlane.Add
                    (
                        id,
                        mapper.Map<Plane>(currentPlaneDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < planeIdPlane.Count; i++)
            {
                Assert.AreEqual(planeIdPlaneDTO[i].Lifetime, planeIdPlane[i].Lifetime);
                Assert.AreEqual(planeIdPlaneDTO[i].LastHeavyMaintenance, planeIdPlane[i].LastHeavyMaintenance);
                Assert.AreEqual(planeIdPlaneDTO[i].ReleaseDate, planeIdPlane[i].ReleaseDate);
                Assert.AreEqual(planeIdPlaneDTO[i].Name, planeIdPlane[i].Name);
                Assert.AreEqual(planeIdPlaneDTO[i].PlaneTypeId, planeIdPlane[i].TypeId);
                Assert.AreEqual(planeIdPlaneDTO[i].FlightHours, planeIdPlane[i].FlightHours);
            }
        }

        #endregion

        #region PlaneType

        [Test]
        [TestCase(1000)]
        public void PlaneType_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, PlaneType> planeTypeIdPlaneType = new Dictionary<int, PlaneType>();
            PlaneType currentPlaneType = null;
            Dictionary<int, PlaneTypeDTO> PlaneTypeIdPlaneTypeDTO = new Dictionary<int, PlaneTypeDTO>();
            int id = 0;


            for (int j = 0; j < assertionsCount; j++)
            {
                currentPlaneType = new PlaneType()
                {
                    Id = id,
                    Capacity = rnd.Next(100, 600),
                    CargoCapacity = rnd.Next(1000, 10000),
                    Model = $"Boeng {rnd.Next(1, 10000)}"
                };

                planeTypeIdPlaneType.Add
                    (
                        id,
                        currentPlaneType
                    );

                PlaneTypeIdPlaneTypeDTO.Add
                    (
                        id,
                        mapper.Map<PlaneTypeDTO>(currentPlaneType)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < planeTypeIdPlaneType.Count; i++)
            {
                Assert.AreEqual(planeTypeIdPlaneType[i].Id, PlaneTypeIdPlaneTypeDTO[i].Id);
                Assert.AreEqual(planeTypeIdPlaneType[i].Capacity, PlaneTypeIdPlaneTypeDTO[i].Capacity);
                Assert.AreEqual(planeTypeIdPlaneType[i].CargoCapacity, PlaneTypeIdPlaneTypeDTO[i].CargoCapacity);
                Assert.AreEqual(planeTypeIdPlaneType[i].Model , PlaneTypeIdPlaneTypeDTO[i].Model);
            }

        }

        [Test]
        [TestCase(1000)]
        public void PlaneType_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, PlaneTypeDTO> planeTypeIdPlaneTypeDTO = new Dictionary<int, PlaneTypeDTO>();
            PlaneTypeDTO currentPlaneTypeDTO = null;
            Dictionary<int, PlaneType> planeTypeIdPlaneType = new Dictionary<int, PlaneType>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentPlaneTypeDTO = new PlaneTypeDTO()
                {
                    Capacity = rnd.Next(100, 600),
                    CargoCapacity = rnd.Next(1000, 10000),
                    Model = $"Boing {rnd.Next(1, 10000)}"
                };

                planeTypeIdPlaneTypeDTO.Add
                    (
                        id,
                        currentPlaneTypeDTO
                    );

                planeTypeIdPlaneType.Add
                    (
                        id,
                        mapper.Map<PlaneType>(currentPlaneTypeDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < planeTypeIdPlaneType.Count; i++)
            {
                Assert.AreEqual(planeTypeIdPlaneTypeDTO[i].CargoCapacity, planeTypeIdPlaneType[i].CargoCapacity);
                Assert.AreEqual(planeTypeIdPlaneTypeDTO[i].Capacity, planeTypeIdPlaneType[i].Capacity);
                Assert.AreEqual(planeTypeIdPlaneTypeDTO[i].Model, planeTypeIdPlaneType[i].Model);
            }
        }

        #endregion
    }
}
