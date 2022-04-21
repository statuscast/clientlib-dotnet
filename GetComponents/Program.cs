using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GetComponents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var statuspage = "<STATUSPAGE>";
            var username = "<USERNAME>";
            var password = "<PASSWORD>";

            var httpClient = new HttpClient();
            var apiClient = new StatusCast.Client(httpClient)
            {
                BaseUrl = statuspage
            };

            var auth = apiClient.Authenticate(new StatusCast.AuthenticationRequest
            {
                UserName = username,
                Password = password
            });

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

            var components = apiClient.ComponentsAsync();
        }
    }
}
