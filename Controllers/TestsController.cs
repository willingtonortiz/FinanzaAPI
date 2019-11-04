using System.Collections.Generic;
using FinanzasBE.DTOs;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class TestsController : ControllerBase
	{
		private readonly IBankService _bankService;
		private readonly ILogger<TestsController> _logger;

		public TestsController(IBankService bankService, ILogger<TestsController> logger)
		{
			_logger = logger;
			_bankService = bankService;
		}
		

		[AllowAnonymous]
		[HttpGet("customers/{customerId}/orders/{orderId}")]
		public ActionResult<object> CustomUrl(int customerId, int orderId)
		{
			_logger.LogWarning($"CustomeId: {customerId}, OrderId: {orderId}");
			return Ok(new { customerId, orderId });
		}

	}
}