using SUBU.Shared;

namespace WebApplication1.UISample
{
	public static class Extensions
	{
		public static List<EnumDataType> ConvertEnumToDictionary<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<int>().Select(i => new EnumDataType { Name = Enum.GetName(typeof(T), i), Id = i }).ToList();
		}
	}
}
