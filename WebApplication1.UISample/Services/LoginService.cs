using Newtonsoft.Json;
using RestSharp;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface ILoginService
{
    IDataResult<string> login(LoginModel model);
}

public class LoginService : ILoginService
{
    private readonly IApiService _apiService;

    public LoginService(IApiService apiService)
    {
        _apiService = apiService;
    }


    public IDataResult<string> login(LoginModel model)
    {

        RestRequest request = new RestRequest("/Auth/Login", Method.Post);
        request.AddBody(model);

        var response = _apiService.Client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["data"].ToString();
            return new SuccessDataResult<string>(token);
        }

         var mesaj = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["message"].ToString();
        return new ErrorDataResult<string>(mesaj);
    }


}
