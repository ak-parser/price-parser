namespace PriceParser.Domain.User.Entity.Parts
{
	public class Customizations
	{
		public Dictionary<string, string> ColumnsCustomizations { get; set; } = new();
		public Dictionary<string, string> FiltersCustomizations { get; set; } = new();
	}
}
