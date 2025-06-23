namespace PriceParser.Domain.Common.Attributes
{
	public class OrderAttribute : Attribute
	{
		public string OrderField { get; }
		public OrderAttribute(string orderField)
		{
			OrderField = orderField;
		}
	}
}
