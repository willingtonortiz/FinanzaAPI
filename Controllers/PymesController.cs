using System.Collections.Generic;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class PymesController : ControllerBase
	{
		private readonly IPymeService _pymeService;

		public PymesController(IPymeService pymeService)
		{
			_pymeService = pymeService;
		}
	}
}