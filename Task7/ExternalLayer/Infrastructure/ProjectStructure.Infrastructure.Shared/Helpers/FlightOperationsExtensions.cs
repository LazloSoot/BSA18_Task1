using ProjectStructure.Domain;
using ProjectStructure.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Infrastructure.Shared.Helpers
{
    public static class FlightOperationsExtensions
    {
        public static async Task<Flight> GetDelayedFlight(this IFlightOperationsService service, long targetId, CancellationToken ct = default(CancellationToken))
        {
            TaskCompletionSource<Flight> tcs = new TaskCompletionSource<Flight>();
            System.Timers.Timer t = new System.Timers.Timer(1500);
            t.Elapsed += (s, e) =>
           {
               var result = service.GetFlightInfo(targetId);
               tcs.SetResult(result);
           };

           return await tcs.Task;
        }
        
    }
}
