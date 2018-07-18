using System;
using System.Collections.Generic;
using NUnit.Framework;
using mapperToTest = ProjectStructure.Infrastructure.Shared.Mappings.AutoMapper;
using ProjectStructure.Domain;
using ProjectStructure.Infrastructure.Shared;
using System.Linq;

namespace ProjectStructure.Tests.Mappers
{
    [TestFixture]
    public class CrewingMappingTest
    {
        private readonly static Random rnd = new Random();

        #region Pilot

        [Test]
        [TestCase(1000)]
        public void Pilot_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Pilot> pilotIdPilot = new Dictionary<int, Pilot>();
            Pilot currentPilot = null;
            Dictionary<int, PilotDTO> pilotIdPilotDTO = new Dictionary<int, PilotDTO>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentPilot = new Pilot()
                {
                    Id = id,
                    Birth = new DateTime(rnd.Next(1920, 2000), 10, 2),
                    ExperienceYears = rnd.Next(2, 25),
                    Name = $"Ivan#{id}",
                    Surname = $"Petrov#{id}",
                };

                pilotIdPilot.Add
                    (
                        id,
                        currentPilot
                    );

                pilotIdPilotDTO.Add
                    (
                        id,
                        mapper.Map<PilotDTO>(currentPilot)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < pilotIdPilot.Count; i++)
            {
                Assert.AreEqual(pilotIdPilot[i].Id, pilotIdPilotDTO[i].Id);
                Assert.AreEqual(pilotIdPilot[i].Name, pilotIdPilotDTO[i].Name);
                Assert.AreEqual(pilotIdPilot[i].Surname, pilotIdPilotDTO[i].Surname);
                Assert.AreEqual(pilotIdPilot[i].Birth, pilotIdPilotDTO[i].Birth);
                Assert.AreEqual(pilotIdPilot[i].ExperienceYears, pilotIdPilotDTO[i].ExperienceYears);
            }

        }

        [Test]
        [TestCase(1000)]
        public void Pilot_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, PilotDTO> pilotIdPilotDTO = new Dictionary<int, PilotDTO>();
            Dictionary<int, Pilot> pilotIdPilot = new Dictionary<int, Pilot>();
            PilotDTO currentPilotDTO = null;
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentPilotDTO = new PilotDTO()
                {
                    Birth = new DateTime(rnd.Next(1920, 2000), 10, 2),
                    ExperienceYears = rnd.Next(2, 25),
                    Name = $"Ivan#{id}",
                    Surname = $"Petrov#{id}",
                };

                pilotIdPilotDTO.Add
                    (
                        id,
                        currentPilotDTO
                    );

                pilotIdPilot.Add
                    (
                        id,
                        mapper.Map<Pilot>(currentPilotDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < pilotIdPilot.Count; i++)
            {
                Assert.AreEqual(pilotIdPilotDTO[i].Name, pilotIdPilot[i].Name);
                Assert.AreEqual(pilotIdPilotDTO[i].Surname, pilotIdPilot[i].Surname);
                Assert.AreEqual(pilotIdPilotDTO[i].Birth, pilotIdPilot[i].Birth);
                Assert.AreEqual(pilotIdPilotDTO[i].ExperienceYears, pilotIdPilot[i].ExperienceYears);
            }

        }

        #endregion

        #region Stewardress

        [Test]
        [TestCase(1000)]
        public void Stewardess_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Stewardess> stewardressIdStewardress = new Dictionary<int, Stewardess>();
            Stewardess currentStewardess = null;
            Dictionary<int, StewardessDTO> stewardessIdStewardessDTO = new Dictionary<int, StewardessDTO>();
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentStewardess = new Stewardess()
                {
                    Id = id,
                    Birth = new DateTime(rnd.Next(1920, 2000), 10, 2),
                    Name = $"Lena#{id}",
                    Surname = $"Komarova#{id}",
                };

                stewardressIdStewardress.Add
                    (
                        id,
                        currentStewardess
                    );

                stewardessIdStewardessDTO.Add
                    (
                        id,
                        mapper.Map<StewardessDTO>(currentStewardess)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < stewardressIdStewardress.Count; i++)
            {
                Assert.AreEqual(stewardressIdStewardress[i].Id, stewardessIdStewardessDTO[i].Id);
                Assert.AreEqual(stewardressIdStewardress[i].Name, stewardessIdStewardessDTO[i].Name);
                Assert.AreEqual(stewardressIdStewardress[i].Surname, stewardessIdStewardessDTO[i].Surname);
                Assert.AreEqual(stewardressIdStewardress[i].Birth, stewardessIdStewardessDTO[i].Birth);
            }

        }

        [Test]
        [TestCase(1000)]
        public void Stewardess_Maping_DTO_TO_DomainModel(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, StewardessDTO> stewardessIdStewardessDTO = new Dictionary<int, StewardessDTO>();
            Dictionary<int, Stewardess> stewardessIdStewardess = new Dictionary<int, Stewardess>();
            StewardessDTO currentStewardessDTO = null;
            int id = 0;

            for (int j = 0; j < assertionsCount; j++)
            {
                currentStewardessDTO = new StewardessDTO()
                {
                    Birth = new DateTime(rnd.Next(1920, 2000), 10, 2),
                    Name = $"Lena#{id}",
                    Surname = $"Petrova#{id}",
                };

                stewardessIdStewardessDTO.Add
                    (
                        id,
                        currentStewardessDTO
                    );

                stewardessIdStewardess.Add
                    (
                        id,
                        mapper.Map<Stewardess>(currentStewardessDTO)
                    );

                id++;
            }

            // assert
            for (int i = 0; i < stewardessIdStewardess.Count; i++)
            {
                Assert.AreEqual(stewardessIdStewardessDTO[i].Name, stewardessIdStewardess[i].Name);
                Assert.AreEqual(stewardessIdStewardessDTO[i].Surname, stewardessIdStewardess[i].Surname);
                Assert.AreEqual(stewardessIdStewardessDTO[i].Birth, stewardessIdStewardess[i].Birth);
            }

        }

        #endregion Stewardess

        #region Crew

        [Test]
        [TestCase(1000)]
        public void Crew_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Crew> crewIdCrew = new Dictionary<int, Crew>();
            Crew currentCrew = null;
            Dictionary<int, CrewDTO> crewIdCrewDTO = new Dictionary<int, CrewDTO>();
            int id = 0;
            int stewardessesCount = 0;
            List<Stewardess> currentStewardesses = new List<Stewardess>();

            for (int j = 0; j < assertionsCount; j++)
            {
                stewardessesCount = rnd.Next(2, 15);
                for (int i = 0; i < stewardessesCount; i++)
                {
                    currentStewardesses.Add(new Stewardess() { Id = rnd.Next(0, 10000) });
                }

                currentCrew = new Crew()
                {
                    Id = id,
                    Pilot = new Pilot() { Id = id + rnd.Next(1, 100) },
                    Stewardesses = currentStewardesses
                };
                currentStewardesses = new List<Stewardess>();

                crewIdCrew.Add
                    (
                        id,
                        currentCrew
                    );

                crewIdCrewDTO.Add
                    (
                        id,
                        mapper.Map<CrewDTO>(currentCrew)
                    );

                id++;
            }

            // assert
            List<long> stewardessesIds = null;
            for (int i = 0; i < crewIdCrew.Count; i++)
            {
                Assert.AreEqual(crewIdCrew[i].Id, crewIdCrewDTO[i].Id);
                Assert.AreEqual(crewIdCrew[i].Pilot.Id, crewIdCrewDTO[i].PilotId);

                stewardessesIds = crewIdCrewDTO[i].StewardessesIds.ToList();
                foreach (var s in crewIdCrew[i].Stewardesses)
                {
                    Assert.Contains(s.Id, stewardessesIds);
                }
            }

        }

        [Test]
        [TestCase(1000)]
        public void CrewExtended_Maping_DomainModel_TO_DTO(int assertionsCount)
        {
            // Arrange
            var mapper = mapperToTest.GetDefaultMapper();

            // act
            Dictionary<int, Crew> crewIdCrew = new Dictionary<int, Crew>();
            Crew currentCrew = null;
            Dictionary<int, CrewExtendedDTO> crewIdCrewDTO = new Dictionary<int, CrewExtendedDTO>();
            int id = 0;
            int stewardessesCount = 0;
            List<Stewardess> currentStewardesses = new List<Stewardess>();

            for (int j = 0; j < assertionsCount; j++)
            {
                stewardessesCount = rnd.Next(2, 15);
                for (int i = 0; i < stewardessesCount; i++)
                {
                    currentStewardesses.Add(new Stewardess() { Id = rnd.Next(0, 10000) });
                }

                currentCrew = new Crew()
                {
                    Id = id,
                    Pilot = new Pilot() { Id = id + rnd.Next(1, 100) },
                    Stewardesses = currentStewardesses
                };
                currentStewardesses = new List<Stewardess>();

                crewIdCrew.Add
                    (
                        id,
                        currentCrew
                    );

                crewIdCrewDTO.Add
                    (
                        id,
                        mapper.Map<CrewExtendedDTO>(currentCrew)
                    );

                id++;
            }

            // assert
            List<StewardessDTO> stewardessesDtos = null;
            for (int i = 0; i < crewIdCrew.Count; i++)
            {
                Assert.AreEqual(crewIdCrew[i].Id, crewIdCrewDTO[i].Id);
                Assert.AreEqual(crewIdCrew[i].Pilot.Id, crewIdCrewDTO[i].PilotDTO.FirstOrDefault()?.Id);
                Assert.AreEqual(crewIdCrew[i].Pilot.Name, crewIdCrewDTO[i].PilotDTO.FirstOrDefault()?.Name);
                Assert.AreEqual(crewIdCrew[i].Pilot.Surname, crewIdCrewDTO[i].PilotDTO.FirstOrDefault()?.Surname);
                Assert.AreEqual(crewIdCrew[i].Pilot.Birth, crewIdCrewDTO[i].PilotDTO.FirstOrDefault()?.Birth);
                Assert.AreEqual(crewIdCrew[i].Pilot.ExperienceYears, crewIdCrewDTO[i].PilotDTO.FirstOrDefault()?.ExperienceYears);

                stewardessesDtos = crewIdCrewDTO[i].StewardessesDtos.ToList();
                foreach (var s in crewIdCrew[i].Stewardesses)
                {
                    var st = stewardessesDtos.Find(stw => stw.Id == s.Id);
                    Assert.NotNull(st);
                    Assert.AreEqual(s.Name, st.Name);
                    Assert.AreEqual(s.Surname, st.Surname);
                    Assert.AreEqual(s.Birth, st.Birth);
                }
            }

        }

        #endregion
    }
}
