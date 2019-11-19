using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class RecordsController : ControllerBase
    {
        #region Attributes

        private readonly ILogger<RecordsController> _logger;
        private readonly IRecordService _recordService;
        private readonly IUserService _userService;
        //private readonly BillConverter _billConverter;

        #endregion


        #region Constructor

        public RecordsController(
            ILogger<RecordsController> logger,
            IRecordService recordService,
            IUserService userService
            /*BillConverter billConverter*/
        )
        {
            _logger = logger;
            _recordService = recordService;
            _userService = userService;
            /*_billConverter = billConverter;*/
        }

        #endregion


        #region FindAll

        [HttpGet]
        public ActionResult<IEnumerable<Record>> FindAll()
        {
            IEnumerable<Record> records = _recordService.FindAll();

            //IEnumerable<BillDTO> recordDtos = records.Select(x => _billConverter.FromEntity(x));

            return Ok(records);
        }

        #endregion


        #region FindById

        [Authorize(Roles = RoleType.USER)]
        [HttpGet("{id}")]
        public ActionResult<Record> FindById(int id)
        {
            Record record = _recordService.FindById(id);

            if (record == null)
            {
                return BadRequest();
            }

            //BillDTO billDTO = _billConverter.FromEntity(bill);

            return record;
        }

        #endregion


        #region Create

        //[Authorize(Roles = RoleType.USER)]
        [HttpPost]
        public ActionResult<Record> Create(
            [FromBody] Record record
        )
        {
            _logger.LogInformation("Verificando usuario");
            User foundUser = _userService.FindById(record.UserId);

            if (foundUser == null)
            {
                return NotFound();
            }
            _logger.LogDebug("Usuario Verificado");
            //Bill bill = _billConverter.FromCreateBill(createBill);
            _logger.LogDebug("Guardandolo");
            _recordService.Save(record);

            //BillDTO billDto = _billConverter.FromEntity(bill);
            _logger.LogDebug("Retornado Record");       
            return Ok(record);
        }

        #endregion


       
    }
}