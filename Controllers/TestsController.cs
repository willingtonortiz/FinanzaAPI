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
		[HttpPost]
		public ActionResult<BankDTO> Create([FromBody] BankDTO bankDto)
		{
			Bank foundBank = _bankService.FindByRuc(bankDto.Ruc);


			if (foundBank != null)
			{
				return BadRequest();
			}

			Bank bank = new Bank(bankDto);

			_bankService.Create(bank);

			bankDto.BankId = bank.BankId;

			return bankDto;
		}

		[AllowAnonymous]
		[HttpGet("customers/{customerId}/orders/{orderId}")]
		public ActionResult<string> CustomUrl(int customerId, int orderId)
		{
			_logger.LogWarning($"CustomeId: {customerId}, OrderId: {orderId}");
			return Ok(new {customerId, orderId});
		}
	}
}