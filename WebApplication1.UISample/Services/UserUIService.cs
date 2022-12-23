using Newtonsoft.Json;
using RestSharp;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface IUserUIService
{
    IDataResult<string> Create(UserCreate model);
}

public class UserUIService : IUserUIService
{
    private readonly IApiService _apiService;

    public UserUIService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public IDataResult<string> Create(UserCreate model)
    {
        //TODO : giren kullanıcı alınacak.
      model.CreateUserName = "girekKullanıcı";

        RestRequest request = new RestRequest("/User/Create", Method.Post);
        request.AddBody(model);

         var response = _apiService.Client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var mesajAdd = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["message"].ToString();
            return new SuccessDataResult<string>(mesajAdd);
        }
        var mesajNotAdd = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["message"].ToString();
        return new ErrorDataResult<string>(mesajNotAdd);

    }

    
}
