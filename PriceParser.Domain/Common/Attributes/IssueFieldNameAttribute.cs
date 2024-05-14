namespace Lynkco.Warranty.WebAPI.Domain.Common.Attributes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class IssueFieldNameAttribute : Attribute
	{
		public IssueFieldNameAttribute(string fieldName)
		{
			FieldName = fieldName;
		}

		public string FieldName { get; }
	}
}
