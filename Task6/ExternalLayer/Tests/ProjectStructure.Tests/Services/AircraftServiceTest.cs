using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using ProjectStructure.Domain;
using ProjectStructure.Domain.Enums;
using ProjectStructure.Domain.Interfaces;
using ProjectStructure.Infrastructure.BL;

namespace ProjectStructure.Tests.Services
{
    [TestFixture]
    public class AircraftServiceTest
    {

        #region Planes

        #region TechConditionTests

        [Test]
        [TestCase(450)]
        public void GetPlaneTechCondition_When_FlightHours_less_than_500_then_returns_None(int flightHours)
        {
            // Arrange
            var mock = new Mock<IDbAircraftUnitOfWork>();

            var service = new AircraftService(mock.Object);

            Plane plane = new Plane()
            {
                LastHeavyMaintenance = DateTime.Now - new TimeSpan(3000, 0, 0, 0),
                FlightHours = flightHours
            };

            // Act
            var result = service.GetPlaneTechCondition(plane);

            // Assert
            Assert.AreEqual(CheckNeeded.None, result);
        }

        [Test]
        [TestCase(500)]
        [TestCase(2999)]
        public void GetPlaneTechCondition_When_FlightHours_greaterOrEqual_500_and_Less_Than_300_then_returns_A_Check(int flightHours)
        {
            // Arrange
            var mock = new Mock<IDbAircraftUnitOfWork>();
            mock.SetReturnsDefault<object>(null);

            var service = new AircraftService(mock.Object);

            Plane plane = new Plane()
            {
                LastHeavyMaintenance = DateTime.Now - new TimeSpan(3000, 0, 0, 0),
                FlightHours = flightHours
            };

            // Act
            var result = service.GetPlaneTechCondition(plane);

            // Assert
            Assert.AreEqual(CheckNeeded.A_Check, result);
        }

        [Test]
        [TestCase(3000)]
        [TestCase(7499)]
        public void GetPlaneTechCondition_When_FlightHours_greaterOrEqual_3000_and_Less_Than_7000_then_returns_B_Check(int flightHours)
        {
            // Arrange
            var mock = new Mock<IDbAircraftUnitOfWork>();
            mock.SetReturnsDefault<object>(null);

            var service = new AircraftService(mock.Object);

            Plane plane = new Plane()
            {
                LastHeavyMaintenance = DateTime.Now - new TimeSpan(3000, 0, 0, 0),
                FlightHours = flightHours
            };

            // Act
            var result = service.GetPlaneTechCondition(plane);

            // Assert
            Assert.AreEqual(CheckNeeded.B_Check, result);
        }

        [Test]
        [TestCase(7500)]
        [TestCase(10000)]
        public void GetPlaneTechCondition_When_FlightHours_greaterOrEqual_7500_then_returns_C_Check(int flightHours)
        {
            // Arrange
            var mock = new Mock<IDbAircraftUnitOfWork>();
            mock.SetReturnsDefault<object>(null);

            var service = new AircraftService(mock.Object);

            Plane plane = new Plane()
            {
                LastHeavyMaintenance = DateTime.Now - new TimeSpan(3000, 0, 0, 0),
                FlightHours = flightHours
            };

            // Act
            var result = service.GetPlaneTechCondition(plane);

            // Assert
            Assert.AreEqual(CheckNeeded.C_Check, result);
        }

        [Test]
        [TestCase(12)]
        [TestCase(22)]
        public void GetPlaneTechCondition_When_Since_LastHeavyMaintenanceDate_12Years_passed_then_returns_D_Check(int yearsCount)
        {
            // Arrange
            var mock = new Mock<IDbAircraftUnitOfWork>();
            mock.SetReturnsDefault<object>(null);

            var service = new AircraftService(mock.Object);

            Plane plane = new Plane()
            {
                FlightHours = 8000,
                LastHeavyMaintenance = DateTime.Now - new TimeSpan(365 * yearsCount, 0, 0, 0, 0)
            };

            // Act
            var result = service.GetPlaneTechCondition(plane);

            // Assert
            Assert.AreEqual(CheckNeeded.D_Check, result);
        }

        #endregion


        void CarryOutMaintenance_When_()
        {

        }
        

        //IEnumerable<Plane> GetAllPlanesInfo();

        //Plane GetPlaneInfo(long id);

        //Plane AddPlane(Plane plane);

        //Plane ModifyPlaneInfo(Plane plane);

        //bool TryDeletePlane(long id);

        #endregion

        //#region PlaneTypes

        //IEnumerable<PlaneType> GetAllPlaneTypesInfo();

        //PlaneType GetPlaneTypeInfo(long id);

        //PlaneType AddPlaneType(PlaneType type);

        //PlaneType ModifyPlaneType(PlaneType type);

        //bool TryDeletePlaneType(long id);
    }
}
