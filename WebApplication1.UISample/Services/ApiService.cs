using RestSharp;
using RestSharp.Authenticators;

namespace WebApplication1.UISample.Services;

public interface IApiService
{
    RestClient Client { get; }
}

public class ApiService : IApiService
{
    public RestClient Client { get; private set; }

    public ApiService(IConfiguration configuration)
    {
        Client = new RestClient(configuration.GetValue<string>("ApiService:Endpoint"));

        //Client.Authenticator = new JwtAuthenticator("token");
    }
}
