using System.Collections.Generic;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller")]
	public class PymeController : ControllerBase
	{
		private readonly IPymeService _pymeService;

		public PymeController(IPymeService pymeService)
		{
			_pymeService = pymeService;
		}
	}
}