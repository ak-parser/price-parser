using System.Runtime.Serialization;

namespace PriceParser.Application.Product.Events.Const
{
	public enum ProductEventType
	{
		[EnumMember(Value = "vehicle-warranty-void-status-changed")]
		VehicleWarrantyVoidChanged = 1
	}
}
