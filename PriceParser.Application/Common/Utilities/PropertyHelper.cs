namespace Lynkco.Warranty.WebAPI.Application.Common.Utilities
{
	public class PropertyHelper
	{
		public object GetPropertyValue(object src, string propName)
		{
			if (propName.Contains(".", StringComparison.OrdinalIgnoreCase))
			{
				var temp = propName.Split(new char[] { '.' }, 2);
				return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
			}
			else
			{
				var prop = src?.GetType().GetProperty(propName);
				return prop?.GetValue(src) ?? null;
			}
		}
	}
}
