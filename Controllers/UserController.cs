using System.Collections;
using System.Collections.Generic;
using FinanzasBE.DTOs;
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
				return BadRequest(new { message = "Nombre de usuario o contraseña incorrectos" });
			}

			return Ok(user);
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody] RegisterUserDto registerUser)
		{
			User foundUser = _userService.FindByUsername(registerUser.Username);

			if (foundUser != null)
			{
				return BadRequest(new { message = "User already exists" });
			}

			User newUser = new User()
			{
				Username = registerUser.Username,
				Password = registerUser.Password,
				Role = Role.User
			};

			_userService.Save(newUser);

			UserAuthentication authUser = _userService.Authenticate(newUser.Username, newUser.Password);

			return Ok(authUser);
		}

		[Authorize(Roles = Role.Admin)]
		[HttpGet]
		public IActionResult GetAll()
		{
			IEnumerable<User> users = _userService.FindAll();
			return Ok(users);
		}

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