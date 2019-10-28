using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FinanzasBE.Entities;
using FinanzasBE.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FinanzasBE.Helpers;
using FinanzasBE.Services;

namespace FinanzasBE.ServicesImpl
{
	public class UserServiceImpl : IUserService
	{
		private readonly FinanzasContext _context;
		private readonly ILogger<UserServiceImpl> _logger;
		private readonly AppSettings _appSettings;

		public UserServiceImpl(
			FinanzasContext context,
			IOptions<AppSettings> appSettings,
			ILogger<UserServiceImpl> logger
			)
		{
			_context = context;
			_appSettings = appSettings.Value;
			_logger = logger;
		}

		public UserAuthenticationDTO Authenticate(string username, string password)
		{
			User user = _context.Users
				.AsNoTracking()
				.SingleOrDefault(x => x.Username == username && x.Password == password);

			if (user == null)
				return null;

			UserAuthenticationDTO authUser = new UserAuthenticationDTO();
			authUser.Id = user.UserId;
			authUser.Username = user.Username;
			authUser.Role = user.Role;

			// Agregando el token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]{
					new Claim(ClaimTypes.Name, user.UserId.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			authUser.Token = tokenHandler.WriteToken(token);

			user.Password = null;
			return authUser;
		}

		public User FindByUsername(string username)
		{
			User foundUser = _context.Users
				.AsNoTracking()
				.FirstOrDefault(x => x.Username == username);

			return foundUser;
		}

		public void Save(User user)
		{
			_context.Users
				.Add(user);
			_context.SaveChanges();
		}

		public User FindById(int id)
		{
			var user = _context.Users
				.AsNoTracking()
				.FirstOrDefault(x => x.UserId == id);

			if (user != null)
				user.Password = null;

			return user;
		}

		public IEnumerable<User> FindAll()
		{
			return _context.Users
				.AsNoTracking()
				.ToList()
				.Select(x =>
				{
					x.Password = null;
					return x;
				});
		}

	}
}