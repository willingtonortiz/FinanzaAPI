using System.Collections.Generic;
using System.Linq;
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
	[Route("[controller]")]
	public class BankController : ControllerBase
	{
		private readonly IBankService _bankService;

		private readonly ILogger<BankController> _logger;

		public BankController(IBankService bankService, ILogger<BankController> logger)
		{
			_bankService = bankService;
			_logger = logger;
		}

		[Authorize(Roles = Role.User)]
		[HttpGet]
		public ActionResult<IEnumerable<BankDTO>> FindAll()
		{
			IEnumerable<Bank> banks = _bankService.FindAll();

			IEnumerable<BankDTO> bankDTOs = banks.Select(x => new BankDTO
			{
				BankId = x.BankId,
				BusinessName = x.BusinessName,
				Ruc = x.Ruc,
				TEASoles = x.TEASoles,
				TEADolares = x.TEADolares
			});

			return bankDTOs.ToList();
		}

	}
}
