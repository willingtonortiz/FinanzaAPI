using System.Collections.Generic;
using System.Linq;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.DTOs.Input;
using FinanzasBE.DTOs.Output;
using FinanzasBE.Entities;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class DiscountsPoolController : ControllerBase
	{
		#region Attributes

		private ILogger<DiscountsPoolController> _logger;
		private readonly IDiscountPoolService _discountPoolService;
		private readonly IDiscountService _discountService;
		private readonly DiscountPoolConverter _discountPoolConverter;
		private readonly CreateDiscountPoolConverter _createDiscountPoolConverter;
		private readonly DiscountPoolOutputConverter _discountPoolOutputConverter;

		#endregion


		#region Constructor

		public DiscountsPoolController(
			ILogger<DiscountsPoolController> logger,
			IDiscountPoolService discountPoolService,
			IDiscountService discountService,
			CreateDiscountPoolConverter createDiscountPoolConverter,
			DiscountPoolOutputConverter discountPoolOutputConverter,
			DiscountPoolConverter discountPoolConverter
		)
		{
			_logger = logger;
			_discountPoolService = discountPoolService;
			_discountService = discountService;
			_createDiscountPoolConverter = createDiscountPoolConverter;
			_discountPoolOutputConverter = discountPoolOutputConverter;
			_discountPoolConverter = discountPoolConverter;
		}

		#endregion


		#region FindAll

		[HttpGet]
		public ActionResult<IEnumerable<DiscountPoolOutput>> FindAll()
		{
			IEnumerable<DiscountPool> discountPools = _discountPoolService.FindAll();

			IEnumerable<DiscountPoolDTO> discountpooldtos = discountPools.Select(x => _discountPoolConverter.FromEntity(x));
			// return discountPools.Select(x => new DiscountPoolOutput
			// {
			// 	Id = x.DiscountPoolId,
			// 	DeliveredValue = x.DeliveredValue,
			// 	ReceivedValue = x.ReceivedValue,
			// 	DiscountDate = x.DiscountDate,
			// 	Tcea = x.TCEA,
			// 	PymeId = x.PymeId
			// }).ToList();

			return Ok(discountpooldtos);
		}

		#endregion


		#region Create

		[HttpPost]
		public ActionResult<DiscountPoolOutput> Create(
			[FromBody] CreateDiscountPool createDiscountPool
		)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			DiscountPool discountPool = _createDiscountPoolConverter.FromDto(createDiscountPool);

			// Todo: Validar que los campos ingresados sean correctos

			discountPool = _discountPoolService.CreateCompleteDiscountPool(discountPool);

			DiscountPoolOutput discountPoolOutput = _discountPoolOutputConverter.FromEntity(discountPool);

			return Ok(discountPoolOutput);
		}

		#endregion
	

		#region FindById
		
		[HttpGet("{discountPoolId}")]
		public ActionResult<IEnumerable<DiscountPoolOutput>> FindById(
			[FromRoute] int discountPoolId
		){
			DiscountPool discountPool = _discountPoolService.FindById(discountPoolId);

			if(discountPool == null){
				return NotFound("DISCOUNT POOL NOT FOUND");
			}

			DiscountPoolOutput discountPoolOutput = _discountPoolOutputConverter.FromEntity(discountPool);

			return Ok(discountPoolOutput);
		}

		#endregion
	}
}