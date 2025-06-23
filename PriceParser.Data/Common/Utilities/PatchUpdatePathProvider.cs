using System.Linq.Expressions;

namespace PriceParser.Data.Common.Utilities
{
	public class PatchUpdatePathProvider<T>
	{
		public static string GetPath<TProperty>(Expression<Func<T, TProperty>> expr, bool asEnumerable = false)
		{
			var name = expr.Parameters[0].Name;
			var fullPath = expr.ToString()
				.Replace($"{name} => {name}", typeof(T).Name, StringComparison.OrdinalIgnoreCase);
			var delimiter = '.';
			var parts = fullPath.Split(delimiter);
			var resultDelimeter = '/';
			var isEnumerableDelimiter = "/-";
			var result = resultDelimeter + string.Join(resultDelimeter, parts.Skip(1));

			return asEnumerable ? result + isEnumerableDelimiter : result;
		}
	}
}
