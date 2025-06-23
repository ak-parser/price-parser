using PriceParser.Domain.Common.Entities;
using PriceParser.Domain.User.Const;
using PriceParser.Domain.User.Entity.Parts;

namespace PriceParser.Domain.User.Entity
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
