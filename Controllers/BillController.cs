using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class BillController : ControllerBase
	{
		private readonly IBillService _billService;
		private readonly IPymeService _pymeService;

		public BillController(IBillService billService, IPymeService pymeService)
		{
			_billService = billService;
			_pymeService = pymeService;
		}

		[Authorize(Roles = Role.User)]
		[HttpGet("{ruc}")]
		public ActionResult<IEnumerable<Bill>> FindByRuc(string ruc)
		{
			Pyme foundPyme = _pymeService.FindByRuc(ruc);

			if (foundPyme == null)
			{
				return BadRequest();
			}

			return _billService.FindByRuc(ruc).ToList();
		}
	}
}