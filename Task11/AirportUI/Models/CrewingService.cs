using AirportUI.Models.Entities;
using AirportUI.Models.Helpers;
using AirportUI.Models.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportUI.Models
{
    public class CrewingService : ICrewingService
    {
        string baseUri = @"http://localhost:54400/api/";
        public Task<Crew> CreateCrewAsync(long pilotId, IEnumerable<long> stewardessesIds, CancellationToken ct =  default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Crew>> GetAllCrewsInfoAsync(CancellationToken ct = default(CancellationToken))
        {
#if DEBUGOFFLINE

            return await Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return new List<Crew>()
            {
                new Crew()
                {
                    Id = 1,
                    PilotId = 1,
                    StewardessesIds = new List<long>{1,2}
                },
                new Crew()
                {
                    Id = 2,
                    PilotId = 2,
                    StewardessesIds = new List<long>{3,4}
                },
                new Crew()
                {
                    Id = 3,
                    PilotId = 3,
                    StewardessesIds = new List<long>{5,6}
                }

            };
            });
#endif

            //SemaphoreSlim crewsSemaphore = new SemaphoreSlim()
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + "crews");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.GetAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                IEnumerable<Crew> crews = null;
                try
                {
                    crews = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<IEnumerable<Crew>>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (crews == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return crews;
            }
            finally
            {
               // semaphore.Release();
            }
        }


        public async Task<IEnumerable<Pilot>> GetAllPilotsInfoAsync(CancellationToken ct = default(CancellationToken))
        {
#if DEBUGOFFLINE

            return await Task.Run(() =>
            {
                Task.Delay(1500).Wait();
                return new List<Pilot>()
            {
                new Pilot()
                {
                    Id = 1,
                    Birth = DateTime.Now,
                    ExperienceYears = 25,
                    Name = "Gadila",
                    Surname = "Dmitrich"
                },
                new Pilot()
                {
                    Id = 2,
                    Birth = DateTime.Now,
                    ExperienceYears =1,
                    Name = "Vasia",
                    Surname = "Grud"
                },
                new Pilot()
                {
                    Id = 3,
                    Birth = DateTime.Now,
                    ExperienceYears = 25,
                    Name = "Grisha",
                    Surname = "NeObychnyj"
                },
                new Pilot()
                {
                    Id = 41,
                    Birth = DateTime.Now,
                    ExperienceYears = 25,
                    Name = "Alexej",
                    Surname = "Petrovich"
                }
            };
            });
            
#endif

            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + "crews/pilots");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.GetAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                IEnumerable<Pilot> pilots = null;
                try
                {
                    pilots = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<IEnumerable<Pilot>>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (pilots == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return pilots;
            }
            finally
            {
                // semaphore.Release();
            }
        }

        public async Task<IEnumerable<Stewardess>> GetAllStewardessesInfoAsync(CancellationToken ct = default(CancellationToken))
        {
#if DEBUGOFFLINE
            return await Task.Run(() =>
            {
                Task.Delay(500).Wait();
                return new List<Stewardess>()
            {
                new Stewardess
                {
                    Id = 1,
                    Birth = DateTime.Now,
                    Name = "Maria",
                    Surname = "Woods"
                },
                new Stewardess
                {
                    Id = 2,
                    Birth = DateTime.Now,
                    Name = "Jane",
                    Surname = "Piters"
                },
                new Stewardess
                {
                    Id = 3,
                    Birth = DateTime.Now,
                    Name = "Öli",
                    Surname = "Boil"
                },
                new Stewardess
                {
                    Id = 4,
                    Birth = DateTime.Now,
                    Name = "Pina",
                    Surname = "Colada"
                },
                new Stewardess
                {
                    Id = 5,
                    Birth = DateTime.Now,
                    Name = "Enny",
                    Surname = "Jones"
                },
                new Stewardess
                {
                    Id = 6,
                    Birth = DateTime.Now,
                    Name = "Victory",
                    Surname = "Amstrong"
                }
            };
            });
#endif
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + "crews/stewardesses");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.GetAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                IEnumerable<Stewardess> stewar = null;
                try
                {
                    stewar = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<IEnumerable<Stewardess>>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (stewar == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return stewar;
            }
            finally
            {
                // semaphore.Release();
            }
        }

        public async Task<Pilot> HirePilotAsync(Pilot pilot, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews");

                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(pilot);
                    httpResponse = await httpClient.PostAsync(requestUri, new Windows.Web.Http.HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                Pilot result;
                try
                {
                    result = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<Pilot>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (result == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return result;
            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<Stewardess> HireStewardessAsync(Stewardess stewardess, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/stewardesses");

                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(stewardess);
                    httpResponse = await httpClient.PostAsync(requestUri, new Windows.Web.Http.HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                Stewardess result;
                try
                {
                    result = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<Stewardess>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (result == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return result;
            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<Crew> ReformCrewAsync(long crewId, Crew crew, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews");
                
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(crew);
                    httpResponse = await httpClient.PutAsync(requestUri, new Windows.Web.Http.HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                    return null;
                }



                Crew result;
                try
                {
                    result = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<Crew>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (result == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return result;
            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<bool> TryDeleteCrewAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/{id}");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.DeleteAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                    return false;
                }

                return true;

            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<bool> TryDismissPilotAsync(long id, CancellationToken ct = default(CancellationToken))
        {
#if DEBUGOFFLINE

            return await Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return true;
            });
#endif

            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/pilots/{id}");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.DeleteAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                    return false;
                }

                return true;

            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<bool> TryDismissStewardessAsync(long id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/stewardresses/{id}");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    //Send the GET request
                    httpResponse = await httpClient.DeleteAsync(requestUri);
                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                    return false;
                }

                return true;

            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<Pilot> UpdatePilotInfoAsync(long id, Pilot pilot, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/pilots");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(pilot);
                    httpResponse = await httpClient.PutAsync(requestUri, new Windows.Web.Http.HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                Pilot result;
                try
                {
                    result = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<Pilot>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (result == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return result;
            }
            finally
            {
                // semaphore.Release();
            }
        }
        

        public async Task<Stewardess> UpdateStewardessInfoAsync(long id, Stewardess stewardess, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

                Uri requestUri = new Uri(baseUri + $"crews/stewardesses");

                //Send the GET request asynchronously and retrieve the response as a string.
                Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
                string httpResponseBody = "";

                try
                {
                    string jsonContent = JsonConvert.SerializeObject(stewardess);
                    httpResponse = await httpClient.PutAsync(requestUri, new Windows.Web.Http.HttpStringContent(jsonContent, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                    httpResponse.EnsureSuccessStatusCode();
                    httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
                }



                Stewardess result;
                try
                {
                    result = await Task.Run(() => {
                        return JsonConvert.DeserializeObject<Stewardess>(httpResponseBody) ?? null;
                    }, ct);
                }
                catch (Exception ex)
                {
                    throw ex;
                }


                if (result == null)
                    throw new ArgumentNullException("Failed to deserialize data!");

                return result;
            }
            finally
            {
                // semaphore.Release();
            }
        }
    }
}
