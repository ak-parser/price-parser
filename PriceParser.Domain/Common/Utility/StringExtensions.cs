namespace Lynkco.Warranty.WebAPI.Domain.Common.Utility
{
	public static class StringExtensions
	{
		/// <summary>
		/// Indicates whether the specified string is "None".
		/// </summary>
		/// <param name="value">The string to test.</param>
		/// <returns>true if value is "None"; otherwise, false.</returns>
		public static bool IsNone(this string value)
		{
			return value == "None";
		}

		/// <summary>
		/// Tests the value for all conditions, and returns prepared value
		/// </summary>
		/// <param name="value">The string to handle.</param>
		/// <returns>Prepared value.</returns>
		public static string GetPreparedValue(this string value)
		{
			return value.IsNone() ? string.Empty : value;
		}

		/// <summary>
		/// Builds class field name from string value
		/// </summary>
		/// <param name="value">nameof field</param>
		/// <returns>real field name</returns>
		public static string GetAsFieldName(this string value)
		{
			return $"<{value}>k__BackingField";
		}
	}
}
