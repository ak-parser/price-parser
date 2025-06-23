using System.Reflection;
using System.Runtime.Serialization;
using PriceParser.Domain.Common.Attributes;

namespace PriceParser.Domain.Common.Utility
{
	public static class EnumExtensions
	{
		public static string GetEnumMemberValue<TEnum>(this TEnum enumValue)
			where TEnum : Enum
			=> enumValue.GetEnumAttribute<EnumMemberAttribute>()?.Value ?? string.Empty;

		public static string GetEnumMemberText<TEnum>(this TEnum enumValue)
			where TEnum : Enum
			=> enumValue.GetEnumAttribute<EnumMemberTextAttribute>()?.Text ?? string.Empty;

		public static TAttribute GetEnumAttribute<TAttribute>(this Enum enumValue)
			where TAttribute : Attribute
			=> enumValue.GetEnumAttributes<TAttribute>().FirstOrDefault();

		public static IEnumerable<TAttribute> GetEnumAttributes<TAttribute>(this Enum enumValue)
			where TAttribute : Attribute
		{
			var type = enumValue.GetType();
			var memInfo = type.GetMember(enumValue.ToString()).First();
			var attributes = memInfo.GetCustomAttributes<TAttribute>(false);

			return attributes;
		}
	}
}
