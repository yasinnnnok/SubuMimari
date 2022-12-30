using Refit;
using RestSharp;
using RestSharp.Authenticators;

namespace WebApplication1.UISample.Services;

public interface IApiService
{
    RestClient Client { get; }
	ISUBUApi SubuApi { get; }
}

public class ApiService : IApiService
{
    public RestClient Client { get; private set; }
	public ISUBUApi SubuApi { get; private set; }
    
	public ApiService(IConfiguration configuration)
    {
        Client = new RestClient(configuration.GetValue<string>("ApiService:Endpoint"));

		
		HttpClient httpClient = new HttpClient();
		httpClient.BaseAddress = new Uri(configuration.GetValue<string>("ApiService:Endpoint"));

		SubuApi = RestService.For<ISUBUApi>(httpClient);
		
		//Client.Authenticator = new JwtAuthenticator("token");
	}
}
