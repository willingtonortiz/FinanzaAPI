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
		// IEnumerable<User> FindAll();
		// User FindById(int id);
	}
}