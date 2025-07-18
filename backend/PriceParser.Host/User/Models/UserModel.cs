﻿using Newtonsoft.Json;
using PriceParser.Domain.User.Const;

namespace PriceParser.Host.User.Models
{
	public class UserModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("username")]
		public string UserName { get; set; }

		[JsonProperty("creationTime")]
		public DateTime CreationTime { get; set; }

		[JsonProperty("lastActiveTime")]
		public DateTime LastActiveTime { get; set; }

		[JsonProperty("roles")]
		public List<UserRole> Roles { get; set; } = new();
	}
}
