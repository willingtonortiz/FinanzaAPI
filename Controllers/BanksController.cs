using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.DTOs.Input;
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
    public class BanksController : ControllerBase
    {
        private readonly ILogger<BanksController> _logger;
        private readonly IBankService _bankService;
        private readonly BankConverter _bankConverter;

        public BanksController(
            ILogger<BanksController> logger,
            IBankService bankService,
            BankConverter bankConverter
        )
        {
            _logger = logger;
            _bankService = bankService;
            _bankConverter = bankConverter;
        }


        // [Authorize(Roles = Role.User)]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<BankDTO>> FindAll()
        {
            IEnumerable<Bank> banks = _bankService.FindAll();

            IEnumerable<BankDTO> bankDTOs = banks.Select(x => _bankConverter.FromEntity(x));

            return bankDTOs.ToList();
        }

        #region FindByRuc

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<BankDTO> Create(
            [FromBody] CreateBank createBank
        )
        {
            Bank foundBank = _bankService.FindByRuc(createBank.Ruc);

            if (foundBank != null)
            {
                return NotFound();
            }

            Bank newBank = _bankConverter.CreateBankToBank(createBank);

            _bankService.Create(newBank);

            BankDTO createdBank = _bankConverter.FromEntity(newBank);

            return Ok(createdBank);
        }

        #endregion
    }
}