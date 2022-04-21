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
            var httpClient = new HttpClient();

            var apiClient = new StatusCastApi.Client(httpClient);
            apiClient.BaseUrl = "https://scott-test.ngrok.io";

            var auth = apiClient.AuthenticateAsync(new StatusCastApi.AuthenticationRequest 
            { 
                UserName = "scott@statuscast.com", 
                Password = "Q!q1q1q1" 
            }).Result;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.Token);

            var components = apiClient.ComponentsAsync().Result;


        }
    }
}
