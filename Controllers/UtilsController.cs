using System;
using FinanzasBE.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UtilsController : ControllerBase
	{
		private readonly ILogger<UtilsController> _logger;

		public UtilsController(ILogger<UtilsController> logger)
		{
			_logger = logger;
		}

		[AllowAnonymous]
		[Route("billtcea")]
		public ActionResult<double> BillTcea([FromBody] BillTceaData data)
		{
			double tcea = Math.Pow(data.DeliveredValue / data.ReceivedValue, 360.0 / data.DiscountDays) - 1;

			return Ok(new { value = tcea });
		}
	}
}
