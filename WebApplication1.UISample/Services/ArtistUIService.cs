using RestSharp;
using RestSharp.Authenticators;
using WebApplication1.UISample.Models;

namespace WebApplication1.UISample.Services
{
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
            //RestClient client = new RestClient("http://localhost:5097");
            RestRequest request = new RestRequest("/Artist/List", Method.Get);

            //_apiService.Client.Authenticator = new JwtAuthenticator("token");
            //_apiService.Client.Authenticator = new HttpBasicAuthenticator("","");

            var response = _apiService.Client
                .Get<ApiResponse<IEnumerable<ArtistQuery>>>(request);

            return response.data;
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
}
