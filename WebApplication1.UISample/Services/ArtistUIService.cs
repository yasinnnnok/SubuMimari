using RestSharp;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface IArtistUIService
{
    IEnumerable<ArtistQuery> List();
    ArtistQuery Create(ArtistCreate model);
}

public class ArtistUIService : IArtistUIService
{
    private readonly IApiService _apiService;

    public ArtistUIService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public IEnumerable<ArtistQuery> List()
    {
        //RestClient client = new RestClient("http://localhost:5097");// BUNA GEREK KALMADI BU ADRESİ - APPSETTİNGS'TEN OKUYACAĞIZ

        RestRequest request = new RestRequest("/Artist/List", Method.Get);
			var response = _apiService.Client
			   .Get<ApiResponse<IEnumerable<ArtistQuery>>>(request);

			return response.data;

			//_apiService.Client.Authenticator = new JwtAuthenticator("token");
			//_apiService.Client.Authenticator = new HttpBasicAuthenticator("","");


		}

    public ArtistQuery Create(ArtistCreate model)
    {
        //RestClient client = new RestClient("http://localhost:5097");
        RestRequest request = new RestRequest("/Artist/Create", Method.Post);
        request.AddBody(model);

        var response = _apiService.Client
            .Post<ApiResponse<ArtistQuery>>(request);

        return response.data;
    }
}
