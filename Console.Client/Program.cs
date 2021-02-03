using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var start = Console.ReadLine();

            MainAsync().GetAwaiter().GetResult();


        }

        private static async Task MainAsync()
        {
            try
            {
                var token = await TokenService.FetchToken();
                HttpRequestMessage msg = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:5010/api/vehicle/abc123"),
                };
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Bearer", token);

                    var res = await httpClient.SendAsync(msg);

                    res.EnsureSuccessStatusCode();

                    var response = await res.Content.ReadAsStringAsync();

                    System.Console.WriteLine(response);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
