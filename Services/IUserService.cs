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
	public interface IUserService
	{
		UserAuthentication Authenticate(long username, string password);
		User FindByUsername(long username);
		void Save(User user);
		// User FindById(int id);
		IEnumerable<User> FindAll();
	}
}