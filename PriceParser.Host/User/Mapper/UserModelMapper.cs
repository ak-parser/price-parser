using Lynkco.Warranty.WebAPI.Application.Common.Mapper;
using Lynkco.Warranty.WebAPI.Application.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Data.Common.Utilities.Contracts;
using Lynkco.Warranty.WebAPI.Domain.User.Entity;
using Lynkco.Warranty.WebAPI.Host.User.Models;

namespace Lynkco.Warranty.WebAPI.Host.User.Mapper
{
	public class UserModelMapper : MapperBase<UserEntity, UserModel>
	{
		private readonly IEpochHelper _epochHelper;
		private readonly ITimezoneOffsetProvider _timezoneOffsetProvider;

		public UserModelMapper(
			IEpochHelper epochHelper,
			ITimezoneOffsetProvider timezoneOffsetProvider)
		{
			_epochHelper = epochHelper;
			_timezoneOffsetProvider = timezoneOffsetProvider;
		}

		public override UserModel Map(UserEntity source)
			=> new UserModel()
			{
				Id = source.Id,
				Email = source.Email,
				UserName = source.UserName,
				CreationTime = _timezoneOffsetProvider.OffsetToLocalTime(_epochHelper.EpochToDateTime(source.CreationTime)),
				LastActiveTime = _timezoneOffsetProvider.OffsetToLocalTime(_epochHelper.EpochToDateTime(source.LastActiveTime)),
				Roles = source.Roles
			};
	}
}
