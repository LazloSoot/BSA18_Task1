using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectStructure.Infrastructure.Shared.Helpers
{
    public static class FlightOperationsExtensions
    {
        public static async Task<IEnumerable<Flight>> GetFlightsWithDelay(this IFlightOperationsService service)
        {
            TaskCompletionSource<IEnumerable<Flight>> tcs = new TaskCompletionSource<IEnumerable<Flight>>();
            Timer t = new Timer(1500);
            t.Elapsed += (s, e) =>
           {

           };

        }
        
    }
}
