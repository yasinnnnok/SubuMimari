using RestSharp;
using WebApplication1.UISample.Models;

namespace WebApplication1.UISample.Services
{
    public interface ILoginService
    {
        LoginUser login(LoginUser model);
       // LoginUser login(LoginUser model);
    }

    public class LoginService:ILoginService
    {
        private readonly IApiService _apiService;

        public LoginService(IApiService apiService)
        {
            _apiService = apiService;
        }


        public  LoginUser  login(LoginUser model)
        {

            RestRequest request = new RestRequest("/Auth/Login", Method.Post);
            request.AddBody(model);

            var response = _apiService.Client
                .Post<ApiResponse<LoginUser>>(request);

            return response.data;
        }


    }
}
