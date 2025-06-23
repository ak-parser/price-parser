namespace PriceParser.Domain.Common.Attributes
{
	public class EnumMemberTextAttribute : Attribute
	{
		public EnumMemberTextAttribute(string text)
		{
			Text = text;
		}

		public string Text { get; }
	}
}
