using System;
using System.Collections.Generic;
using System.Text;
using ProjectStructure.Domain;

namespace ProjectStructure.Services.Interfaces
{
    public interface ICrewingService
    {
        void CreateCrew(Pilot pilot, IEnumerable<Stewardess> stewardesses);

        //void DisbandCrew(long id);

        //void AddPilot()
    }
}
