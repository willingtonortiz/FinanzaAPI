using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FinanzasBE.Entities;
using FinanzasBE.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinanzasBE.Services
{
	public class UserServiceImpl : IUserService
	{
		// private List<User> _users = new List<User>
		// {
		// 	new User{UserId = 1, Username = "admin", Password="admin", Role = Role.Admin},
		// 	new User{UserId = 2, Username = "user", Password="user", Role = Role.User},
		// };

		private readonly FinanzasContext _context;
		private readonly ILogger<UserServiceImpl> _logger;
		private readonly AppSettings _appSettings;

		public UserServiceImpl(FinanzasContext context, IOptions<AppSettings> appSettings, ILogger<UserServiceImpl> logger)
		{
			_context = context;
			_appSettings = appSettings.Value;
			_logger = logger;
		}

		public UserAuthentication Authenticate(long username, string password)
		{
			User user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

			if (user == null)
				return null;

			UserAuthentication authUser = new UserAuthentication();
			authUser.Username = user.Username;
			authUser.Role = user.Role;
			
			// Agregando el token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]{
					new Claim(ClaimTypes.Name, user.Username.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			// El tamaño de la 'SecretKey' debe ser grande
			// admin
			//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJyb2xlIjoiQURNSU4iLCJuYmYiOjE1NzA0MDI5MTMsImV4cCI6MTU3MTAwNzcxMywiaWF0IjoxNTcwNDAyOTEzfQ.h36f2_9EvudGe_anf68yU9Q_Vptmspekk4I6wzCJSF8
			//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiVVNFUiIsIm5iZiI6MTU3MDQwMzQwOCwiZXhwIjoxNTcxMDA4MjA4LCJpYXQiOjE1NzA0MDM0MDh9.kAmkGKflQ8rc2sfC7G0oemibd8UVXA8cTKZPcNawK0k
			var token = tokenHandler.CreateToken(tokenDescriptor);
			authUser.Token = tokenHandler.WriteToken(token);

			user.Password = null;
			// "Secret": "MySecretKey"
			return authUser;
		}

		// public IEnumerable<User> FindAll()
		// {
		// 	return _context.Users.ToList().Select(x => 
		// 	{
		// 		x.Password = null;
		// 		return x;
		// 	});
		// }

		// public User FindById(int id)
		// {
		// 	var user = _context.Users.FirstOrDefault(x => x.Username == id);

		// 	if (user != null)
		// 		user.Password = null;

		// 	return user;
		// }
	}
}