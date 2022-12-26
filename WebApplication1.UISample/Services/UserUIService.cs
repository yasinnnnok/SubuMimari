using Newtonsoft.Json;
using RestSharp;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface IUserUIService
{
    IDataResult<string> Create(UserCreate model);
    IDataResult<string> Delete(int id);
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

    public IDataResult<string> Delete(int id)
    {
		//  RestRequest request = new RestRequest("/User/Remove", Method.Delete);
		//request.AddBody(id);
		RestRequest request = new RestRequest($"/User/Remove?id={id}", Method.Delete);        
        var response = _apiService.Client.Execute(request);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
			var mesajDelete = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["message"].ToString();
			return new SuccessDataResult<string>(mesajDelete);
		}
		var mesajNotDelete = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["message"].ToString();
		return new ErrorDataResult<string>(mesajNotDelete);
	}
}
