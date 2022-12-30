using Nancy.Json;
using Newtonsoft.Json;
using RestSharp;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface IUserUIService
{
	IDataResult<string> Create(UserCreate model);
	IDataResult<string> Delete(int id);
	IDataResult<IEnumerable<UserQuery>> List();
	IDataResult<string> Update(int id, UserUpdate model);


}

public class UserUIService : IUserUIService
{
	private readonly IApiService _apiService;

	public UserUIService(IApiService apiService)
	{
		_apiService = apiService;
	}

	public IDataResult<IEnumerable<UserQuery>> List()
	{
		RestRequest request = new RestRequest("/User/List", Method.Get);
		var response = _apiService.Client.Execute(request);
		//1.YÖNTEM
		var usersResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(response.Content)["data"].ToString();
		var serializer = new JavaScriptSerializer();
		var users = serializer.Deserialize<IEnumerable<UserQuery>>(usersResponse);
		//boş olsada success -false gelmiyor.
		return new SuccessDataResult<IEnumerable<UserQuery>>(users);


		//2.YÖNTEM - APİ RESPONSE CLASSINI KULLANARAK
		//var model = _apiService.Client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);
		//return View(model.data);
	}

	public IDataResult<string> Create(UserCreate model)
	{
		//TODO : giren kullanıcı alınacak.
		model.CreateUserName = "girekKullanıcı";
		model.Status = true;

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

	//bu şekilde
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



	public IDataResult<string> Update(int id, UserUpdate model)
	{

		RestRequest request = new RestRequest($"/User/Update", Method.Put);
		//request.AddHeader("Content-Type", "application/json");
		request.AddQueryParameter("id", id);
		model.CreateUserName = "";
		request.AddBody(model);
		var response = _apiService.Client.Execute(request);
		//var response = _apiService.Client.Put<ApiResponse<UserUpdate>>(request);

		if (response.StatusCode == System.Net.HttpStatusCode.OK)
		{
			return new SuccessDataResult<string>("update başarılı");
		}
		return new ErrorDataResult<string>("başarısız");

	}


}
