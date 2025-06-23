using PriceParser.Application.Common.Mapper;
using PriceParser.Application.Common.Utilities.Contracts;
using PriceParser.Data.Common.Utilities.Contracts;
using PriceParser.Domain.User.Entity;
using PriceParser.Host.User.Models;

namespace PriceParser.Host.User.Mapper
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
			=> new()
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
