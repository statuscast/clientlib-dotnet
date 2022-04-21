using System.Net.Http.Headers;

var statuspage = "https://<STATUSPAGE>";
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

var components = apiClient.Components();

Console.WriteLine($"{components.Count} components found");