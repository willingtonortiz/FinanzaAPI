using FinanzasBE.DTOs;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasBE.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly IBankService _bankService;

		public TestController(IBankService bankService)
		{
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
	}
}