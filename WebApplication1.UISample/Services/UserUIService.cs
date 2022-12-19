using RestSharp;
using WebApplication1.UISample.Models;

namespace WebApplication1.UISample.Services
{
    public interface IUserUIService
    {
        ApiResponse<UserQuery> Create(UserCreate model);
    }

    public class UserUIService : IUserUIService
    {
        private readonly IApiService _apiService;

        public UserUIService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public ApiResponse<UserQuery> Create(UserCreate model)
        {
            model.CreateUserName = "girekKullanıcı";

            RestRequest request = new RestRequest("/User/Create", Method.Post);
            request.AddBody(model);

            var response = _apiService.Client
                .Post<ApiResponse<UserQuery>>(request);

            return response;
        }
    }
}
