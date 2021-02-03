using IdentityModel.Client;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp.Client
{
    public static class TokenService
    {
        public static async Task<string> FetchToken()
        {
            HttpClient client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Debug.WriteLine(disco.Error);

            }

            var tokenRes = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "consoleApp",
                ClientSecret = "consolesecret",
                Scope = "searchvehicle.findbymake",
                GrantType = "client_credentials"
            }
            );

            if (tokenRes.IsError)
            {
                Debug.WriteLine(tokenRes.Error);
            }

            System.Console.WriteLine(tokenRes.AccessToken);

            return tokenRes.AccessToken;

        }



    }
}
