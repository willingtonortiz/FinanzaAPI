using System;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.Entities;
using FinanzasBE.Enums;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IPymeService _pymeService;

        public AuthenticationController(
            ILogger<UsersController> logger,
            IUserService userService,
            IPymeService pymeService
        )
        {
            _logger = logger;
            _userService = userService;
            _pymeService = pymeService;
        }


        #region Login

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<UserAuthenticationDTO> Login([FromBody] User userParam)
        {
            UserAuthenticationDTO user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        #endregion


        #region Register

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterUserDto registerUser)
        {
            try
            {
                User foundUser = _userService.FindByUsername(registerUser.Username);

                if (foundUser != null)
                {
                    return BadRequest(new {message = "User already exists"});
                }

                User newUser = new User()
                {
                    Username = registerUser.Username,
                    Password = registerUser.Password,
                    Role = RoleType.USER
                };
                _userService.Save(newUser);
                _logger.LogError("guardo al usuario");
                Pyme newPyme = new Pyme()
                {
                    Ruc = registerUser.Username,
                    BusinessName = registerUser.BusinessName,
                    Address = registerUser.Address,
                    PymeId = newUser.UserId
                };
                _pymeService.Save(newPyme);

                UserAuthenticationDTO authUser = _userService.Authenticate(newUser.Username, newUser.Password);

                return Ok(authUser);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}