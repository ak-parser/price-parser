using System.Runtime.Serialization;

namespace Lynkco.Warranty.WebAPI.Application.VehicleWarranty.Events.Const
{
	public enum ProductEventType
	{
		[EnumMember(Value = "vehicle-warranty-void-status-changed")]
		VehicleWarrantyVoidChanged = 1
	}
}
