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
            var statuspage = "<STATUSPAGE>";
            var username = "<USERNAME>";
            var password = "<PASSWORD>";

            var httpClient = new HttpClient();
            var apiClient = new StatusCastApi.Client(httpClient);
            apiClient.BaseUrl = statuspage;

            var auth = apiClient.Authenticate(new StatusCastApi.AuthenticationRequest 
            { 
                UserName = username, 
                Password = password
            });

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

            var components = apiClient.ComponentsAsync();
        }
    }
}
