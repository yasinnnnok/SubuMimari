using Newtonsoft.Json;
using SUBU.Models;
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
}
