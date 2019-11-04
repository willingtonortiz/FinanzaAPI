using System;
using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Converters;
using FinanzasBE.DTOs.Input;
using FinanzasBE.DTOs.Output;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FinanzasBE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsPoolController : ControllerBase
    {
        private ILogger<DiscountsPoolController> _logger;
        private readonly IDiscountPoolService _discountPoolService;
        private readonly IDiscountService _discountService;
        private readonly CreateDiscountPoolConverter _createDiscountPoolConverter;
        private readonly DiscountPoolOutputConverter _discountPoolOutputConverter;


        #region Constructor

        public DiscountsPoolController(
            ILogger<DiscountsPoolController> logger,
            IDiscountPoolService discountPoolService,
            IDiscountService discountService,
            CreateDiscountPoolConverter createDiscountPoolConverter,
            DiscountPoolOutputConverter discountPoolOutputConverter
        )
        {
            _logger = logger;
            _discountPoolService = discountPoolService;
            _discountService = discountService;
            _createDiscountPoolConverter = createDiscountPoolConverter;
            _discountPoolOutputConverter = discountPoolOutputConverter;
        }

        #endregion


        #region FindAll

        [HttpGet]
        public ActionResult<IEnumerable<DiscountPoolOutput>> FindAll()
        {
            IEnumerable<DiscountPool> discountPools = _discountPoolService.FindAll();

            return discountPools.Select(x => new DiscountPoolOutput
            {
                Id = x.DiscountPoolId,
                DeliveredValue = x.DeliveredValue,
                ReceivedValue = x.ReceivedValue,
                DiscountDate = x.DiscountDate,
                Tcea = x.TCEA,
                PymeId = x.PymeId
            }).ToList();
        }

        #endregion


        #region Create

        [HttpPost]
        public ActionResult<DiscountPoolOutput> Create(
            [FromBody] CreateDiscountPool createDiscountPool
        )
        {
            if (!ModelState.IsValid) return BadRequest();

            DiscountPool discountPool = _createDiscountPoolConverter.FromDto(createDiscountPool);

            discountPool = _discountPoolService.CreateCompleteDiscountPool(discountPool);

            DiscountPoolOutput discountPoolOutput = _discountPoolOutputConverter.FromEntity(discountPool);

            return Ok(discountPoolOutput);
        }

        #endregion
    }
}