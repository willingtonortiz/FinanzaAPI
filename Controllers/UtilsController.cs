using System;
using FinanzasBE.DTOs;
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
    public class UtilsController : ControllerBase
    {
        private readonly ILogger<UtilsController> _logger;
        private readonly IPymeService _pymeService;
        private readonly IUserService _userService;
        private readonly IBillService _billService;
        private readonly ICostService _costService;
        private readonly IDiscountService _discountService;
        private readonly IDiscountPoolService _discountPoolService;


        #region Constructor

        public UtilsController(
            ILogger<UtilsController> logger,
            IPymeService pymeService,
            IUserService userService,
            IBillService billService,
            ICostService costService,
            IDiscountService discountService,
            IDiscountPoolService discountPoolService
        )
        {
            _logger = logger;
            _pymeService = pymeService;
            _userService = userService;
            _billService = billService;
            _costService = costService;
            _discountService = discountService;
            _discountPoolService = discountPoolService;
        }

        #endregion


        [AllowAnonymous]
        [Route("billtcea")]
        public ActionResult<double> BillTcea([FromBody] BillTceaData data)
        {
            double tcea = Math.Pow(data.DeliveredValue / data.ReceivedValue, 360.0 / data.DiscountDays) - 1;

            return Ok(new {value = tcea});
        }


        #region CreateData

        [HttpGet("create")]
        public ActionResult<string> CreateData()
        {
            User user1 = new User
            {
                Username = "20123456789",
                Password = "20123456789",
                Role = "USER",
            };
            _userService.Save(user1);

            Pyme pyme1 = new Pyme
            {
                Address = "address_1",
                Ruc = "20123456789",
                BusinessName = "business_name_1",
                UserId = user1.UserId
            };
            _pymeService.Save(pyme1);

            Bill bill1 = new Bill
            {
                Amount = 10000.0,
                CurrencyCode = CurrencyCode.PEN,
                Type = BillType.TO_CHARGE,
                Status = BillStatus.VALID,
                StartDate = new DateTime(2019, 11, 1),
                EndDate = new DateTime(2019, 11, 30),
                DrawerRuc = "20123456789",
                DraweeRuc = "20123456789",
                Pyme = pyme1
            };
            Bill bill2 = new Bill
            {
                Amount = 10000.0,
                CurrencyCode = CurrencyCode.PEN,
                Type = BillType.TO_CHARGE,
                Status = BillStatus.VALID,
                StartDate = new DateTime(2019, 11, 1),
                EndDate = new DateTime(2019, 11, 30),
                DrawerRuc = "20123456789",
                DraweeRuc = "20123456789",
                Pyme = pyme1
            };
            Bill bill3 = new Bill
            {
                Amount = 10000.0,
                CurrencyCode = CurrencyCode.PEN,
                Type = BillType.TO_CHARGE,
                Status = BillStatus.VALID,
                StartDate = new DateTime(2019, 11, 1),
                EndDate = new DateTime(2019, 11, 30),
                DrawerRuc = "20123456789",
                DraweeRuc = "20123456789",
                Pyme = pyme1
            };
            _billService.Create(bill1);
            _billService.Create(bill2);
            _billService.Create(bill3);

            return Ok("Datos cargados");
        }

        #endregion


        #region DeleteData

        [HttpGet("delete")]
        public ActionResult<string> DeleteData()
        {
            _costService.DeleteAll();
            _discountService.DeleteAll();
            _discountPoolService.DeleteAll();
            _billService.DeleteAll();
            _pymeService.DeleteAll();
            _userService.DeleteAll();
            return Ok("Datos eliminados");
        }

        #endregion
    }
}