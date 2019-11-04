using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasBE.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly DiscountConverter _discountConverter;


        #region Constructor

        public DiscountsController(
            IDiscountService discountService,
            DiscountConverter discountConverter
        )
        {
            _discountService = discountService;
            _discountConverter = discountConverter;
        }

        #endregion


        #region FindAll

        [HttpGet]
        public ActionResult<IEnumerable<DiscountDTO>> FindAll()
        {
            IEnumerable<Discount> discounts = _discountService.FindAll();

            IEnumerable<DiscountDTO> discountDtos = discounts.Select(x => _discountConverter.FromEntity(x));

            return Ok(discountDtos);
        }

        #endregion
    }
}