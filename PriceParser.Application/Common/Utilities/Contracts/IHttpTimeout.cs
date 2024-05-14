namespace Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts
{
	public interface IHttpTimeout
	{
		public TimeSpan Timeout { get; set; }
	}
}
