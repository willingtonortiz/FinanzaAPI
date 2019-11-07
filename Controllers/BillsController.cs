using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.DTOs.Input;
using FinanzasBE.Entities;
using FinanzasBE.Enums;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class BillsController : ControllerBase
    {
        private readonly ILogger<BillsController> _logger;
        private readonly IBillService _billService;
        private readonly IPymeService _pymeService;
        private readonly BillConverter _billConverter;


        #region Constructor

        public BillsController(
            ILogger<BillsController> logger,
            IBillService billService,
            IPymeService pymeService,
            BillConverter billConverter
        )
        {
            _logger = logger;
            _billService = billService;
            _pymeService = pymeService;
            _billConverter = billConverter;
        }

        #endregion


        #region FindAll

        [HttpGet]
        public ActionResult<IEnumerable<BillDTO>> FindAll()
        {
            IEnumerable<Bill> bills = _billService.FindAll();

            IEnumerable<BillDTO> billDtos = bills.Select(x => _billConverter.FromEntity(x));

            return Ok(billDtos);
        }

        #endregion


        #region FindById

        [Authorize(Roles = RoleType.USER)]
        [HttpGet("{id}")]
        public ActionResult<BillDTO> FindById(int id)
        {
            Bill bill = _billService.FindById(id);

            if (bill == null)
            {
                return BadRequest();
            }

            BillDTO billDTO = _billConverter.FromEntity(bill);

            return billDTO;
        }

        #endregion


        #region Create

        //[Authorize(Roles = RoleType.USER)]
        [HttpPost]
        public ActionResult<BillDTO> Create(
            [FromBody] CreateBill createBill
        )
        {
            Pyme foundPyme = _pymeService.FindById(createBill.PymeId);

            if (foundPyme == null)
            {
                return NotFound();
            }
            
            Bill bill = _billConverter.FromCreateBill(createBill);

            _billService.Create(bill);

            return _billConverter.FromEntity(bill);
        }

        #endregion
    }
}