using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace StatusCastApiDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var apiClient = new StatusCastApi.Client(new HttpClient());
            apiClient.BaseUrl = "https://<STATUSPAGE>";
            var auth = apiClient.AuthenticateAsync(new StatusCastApi.AuthenticationRequest { UserName = "<USERNAME>", Password = "<PASSWORD>" }).Result;

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

            var components = apiClient.ComponentsAsync().Result;
        }
    }
}
