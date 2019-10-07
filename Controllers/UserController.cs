using System.Collections;
using System.Collections.Generic;
using FinanzasBE.Entities;
using FinanzasBE.Helpers;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ILogger<UserController> _logger;

		public UserController(IUserService userService, ILogger<UserController> logger)
		{
			_userService = userService;
			_logger = logger;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody] User userParam)
		{
			UserAuthentication user = _userService.Authenticate(userParam.Username, userParam.Password);

			if (user == null)
			{
				return BadRequest(new { message = "Username or password is incorrect" });
			}

			return Ok(user);
		}

		// [Authorize(Roles = Role.Admin)]
		// [HttpGet]
		// public IActionResult GetAll()
		// {
		// 	IEnumerable<User> users = _userService.FindAll();
		// 	return Ok(users);
		// }

		// [HttpGet("{id}")]
		// public IActionResult GetById(int id)
		// {
		// 	User user = _userService.FindById(id);

		// 	if (user == null)
		// 	{
		// 		return NotFound();
		// 	}

		// 	int currentUserId = int.Parse(User.Identity.Name);
		// 	if (id != currentUserId && !User.IsInRole(Role.Admin))
		// 	{
		// 		return Forbid();
		// 	}

		// 	return Ok(user);
		// }
	}
}