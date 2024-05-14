using Lynkco.Warranty.WebAPI.Domain.Common.Entities;
using Lynkco.Warranty.WebAPI.Domain.User.Const;
using Lynkco.Warranty.WebAPI.Domain.User.Entity.Parts;

namespace Lynkco.Warranty.WebAPI.Domain.User.Entity
{
	public class UserEntity : BaseEntity
	{
		public string Email { get; set; }
		public string UserName { get; set; }
		public long CreationTime { get; set; }
		public long LastActiveTime { get; set; }
		public Customizations Customizations { get; set; } = new();
		public List<UserRole> Roles { get; set; } = new();
	}
}
