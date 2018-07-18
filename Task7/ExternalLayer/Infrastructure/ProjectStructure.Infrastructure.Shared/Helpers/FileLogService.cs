using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStructure.Infrastructure.Shared.Helpers
{
    public class FileLogService
    {
        private readonly static string path;
        private readonly string logFileNameBase;
        private readonly static SemaphoreSlim writeSemafore = new SemaphoreSlim(1);
        private readonly static SemaphoreSlim formSemafore = new SemaphoreSlim(1);

        public FileLogService(string logFileName = "bsa18")
        {
            logFileNameBase = logFileName;
        }

        static FileLogService()
        {
            path = GetPath();
        }

        public async Task<IEnumerable<string>> FormCrewsText(IEnumerable<Crew> crews, CancellationToken ct = default(CancellationToken))
        {
            await formSemafore.WaitAsync();

            try
            {
                return await Task.Run(() =>
                {
                    StringBuilder st = new StringBuilder();
                    st.AppendLine("crewId,pilotId,pilot_CrewId,pilot_birthDate,pilot_Name,pilot_surName,pilot_exp,stewardess_Id,stewardess_CrewId,stewardess_birthDate,stewardess_Name,stewardess_Surname.");
                    foreach (var c in crews)
                    {
                        foreach (var s in c.Stewardesses)
                        {
                            st.Append($"{c.Id},{c.Pilot.Id},{c.Pilot.CrewId},{c.Pilot.Birth},{c.Pilot.Name},{c.Pilot.Surname},{c.Pilot.ExperienceYears},{s.Id},{s.CrewId},{s.Birth},{s.Name},{s.Surname}.");
                        }
                    }
                    return st.ToString().Split('.').AsEnumerable();
                }, ct);
            }
            finally
            {
                formSemafore.Release();
            }
        }

        public async Task WriteLogAsync(IEnumerable<string> dataLines, CancellationToken ct = default(CancellationToken))
        {
            await writeSemafore.WaitAsync(ct);

            try
            {
                if (dataLines == null || dataLines.Count() < 1)
                    throw new ArgumentException("Data is empty!");

                var fullPath = Path.Combine(path, $"{logFileNameBase}_{DateTimeOffset.UtcNow}.csv");

                await File.AppendAllLinesAsync(path, dataLines, ct);
            }
            finally
            {
                writeSemafore.Release();
            }
        }

        private static string GetPath()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;

            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                string startDirectory = null;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
                if (startDirectory != null)
                {
                    startDirectory = Directory.GetParent(startDirectory).Parent.Parent.FullName;
                }
                return startDirectory;
            }
            else
                return AppContext.BaseDirectory;
        }
    }
}
