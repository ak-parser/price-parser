namespace PriceParser.Domain.Common.Attributes
{
	public class NotificationFieldNameAttribute : Attribute
	{
		public NotificationFieldNameAttribute(string fieldName)
		{
			FieldName = fieldName;
		}

		public string FieldName { get; }
	}
}
