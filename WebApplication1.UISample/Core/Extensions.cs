using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Refit;
using SUBU.Models;
using System.Net;
using System.Text.Json;


namespace WebApplication1.UISample;
public static class Extensions
{
	public static List<EnumDataType> ConvertEnumToDictionary<T>()
	{
		return Enum.GetValues(typeof(T)).Cast<int>().Select(i => new EnumDataType { Name = Enum.GetName(typeof(T), i), Id = i }).ToList();
	}
	public static T ConvertJsonElementToClass<T>(object jsonElement)
	{
		return JsonConvert.DeserializeObject<T>(ConvertObjectToJsonElement(jsonElement).ToString())!;
	}
	private static JsonElement ConvertObjectToJsonElement(object obj)
	{
		return System.Text.Json.JsonSerializer.Deserialize<JsonElement>(System.Text.Json.JsonSerializer.Serialize(obj));
	}
	public static async Task<TResult> RefitResponseHandler<TResult>(Func<Task<Refit.ApiResponse<TResult>>> requestFunc, ITempDataDictionary tempData)
	{
		try
		{
			var response = await requestFunc();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return response.Content;
			}
			else
			{
				tempData["ResponseError"] = response.Error.Message;
				return (TResult)(object)response.Error;
			}
		}
		catch (ApiException ex)
		{
			tempData["ResponseError"] = ex.Message;
			return default(TResult);
		}
	}

	public static async Task<TResult> RefitResponseHandler<TModel, TResult>(TModel model, Func<TModel, Task<Refit.ApiResponse<TResult>>> requestFunc, ITempDataDictionary tempData)
	{
		try
		{
			var response = await requestFunc(model);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return response.Content;
			}
			else
			{
				tempData["ResponseError"] = response.Error.Message;
				return (TResult)(object)response.Error;
			}
		}
		catch (ApiException ex)
		{
			tempData["ResponseError"] = ex.Message;
			return default(TResult);
		}
	}
}
