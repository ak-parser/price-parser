namespace PriceParser.Domain.Common.Entities.Contracts
{
	public interface IExpirable
	{
		public long ExpirationDate { get; set; }
	}
}
