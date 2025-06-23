using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceParser.Application.Common.Mapper.Contracts;
using PriceParser.Application.User.Service.Contracts;
using PriceParser.Data.Common.Pagination;
using PriceParser.Data.User.Utility.Contracts;
using PriceParser.Domain.User.Const;
using PriceParser.Domain.User.Entity;
using PriceParser.Domain.User.Repository.Contracts;
using PriceParser.Host.User.Models;
using PriceParser.Infrastructure.Common.Controllers;

namespace PriceParser.Host.User.Controller
{
	[ApiController]
	[Authorize]
	[Route("user")]
	public class UserController : BaseController
	{
		private readonly ILogger<UserController> _logger;
		private readonly IMapper<UserEntity, UserModel> _mapper;
		private readonly IUserRepository _userRepository;
		private readonly IUserManagementEntityService _userManagementService;
		private readonly IUserManager _userManager;

		public UserController(
			ILogger<UserController> logger,
			IMapper<UserEntity, UserModel> mapper,
			IUserRepository userRepository,
			IUserManagementEntityService userManagementService,
			IUserManager userManager)
		{
			_logger = logger;
			_mapper = mapper;
			_userRepository = userRepository;
			_userManagementService = userManagementService;
			_userManager = userManager;
		}

		/// <summary>
		/// Get paginatted list of users
		/// </summary>
		/// <param name="paginationModel">Pagination parameters</param>
		/// <param name="filterModel">Filter parameters</param>
		/// <param name="orderModel">Order parameters</param>
		/// <param name="cancellationToken">Cancellation token</param>
		/// <returns>List with users if success, NoContent if there are no users</returns>
		[HttpGet(Name = "Get users")]
		[Authorize(Roles = UserRoles.Admin)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<UserModel>>> GetAll(
			[FromQuery] PaginationParametersModel paginationModel,
			CancellationToken cancellationToken)
		{
			_logger.LogInformation("Get list of users");

			var itemCount = await _userRepository.GetCount(cancellationToken);
			if (itemCount == 0)
			{
				return NoContent();
			}

			if (paginationModel == null)
			{
				paginationModel = new PaginationParametersModel();
			}

			var result = await _userRepository.GetAllAsync(
				paginationModel,
				cancellationToken);

			return OkPaged(
				_mapper.MapCollection(result),
				paginationModel,
				itemCount);
		}

		[HttpGet("public", Name = "Get users public info")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<IEnumerable<UserPublicModel>>> GetAllPublicInfo(CancellationToken ct)
		{
			_logger.LogInformation("Get list of users public info");

			var users = await _userRepository.SelectAsync(user => new UserPublicModel()
			{
				Id = user.Id,
				UserName = user.UserName,
				Roles = user.Roles,
			}, ct);

			return Ok(users);
		}

		/// <summary>
		/// Get user model
		/// </summary>
		/// <param name="id">User ID</param>
		/// <param name="token">Token</param>
		/// <returns>User model</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UserModel>> Get(string id, CancellationToken token)
		{
			_logger.LogInformation("Get user by ID");

			var currentUserInfo = _userManager.GetCurrentUser();
			if (!currentUserInfo.UserRoles.Contains(UserRole.Admin))
			{
				if (currentUserInfo.UserId != id)
				{
					return StatusCode(StatusCodes.Status403Forbidden, "ID does not match the current user ID.");
				}
			}

			var user = await _userRepository.GetItemByKeyAsync(id, token);
			if (user == null)
			{
				return NotFound("User was not found.");
			}

			return Ok(_mapper.Map(user));
		}

		/// <summary>
		/// Set user roles
		/// </summary>
		/// <param name="userRoles">Fields to set user roles</param>
		/// <param name="token">Token</param>
		/// <returns>Ok if user roles was updated or BadRequest if user not exists</returns>
		[HttpPost]
		[Authorize(Roles = UserRoles.Admin)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> SetRoles(
			[FromBody] UserRolesModel userRoles,
			CancellationToken token)
		{
			_logger.LogInformation($"Change user(Id - {userRoles.Id}) roles");

			var user = await _userRepository.GetItemByKeyAsync(userRoles.Id, token);
			if (user == null)
			{
				return BadRequest("User with given ID does not exist.");
			}

			user.Roles = userRoles.Roles;
			await _userManagementService.UpdateUserAsync(user, token);
			var model = _mapper.Map(user);

			return Ok(model);
		}
	}
}
