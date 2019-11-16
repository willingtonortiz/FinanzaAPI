using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
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
	public class PymesController : ControllerBase
	{
		#region Attributes

		private readonly ILogger<PymesController> _logger;
		private readonly IPymeService _pymeService;
		private readonly IBillService _billService;
		private readonly IDiscountPoolService _discountPoolService;

		private readonly PymeConverter _pymeConverter;
		private readonly BillConverter _billConverter;
		private readonly DiscountPoolConverter _discountPoolConverter;

		#endregion


		#region Constructor

		public PymesController(
			ILogger<PymesController> logger,
			IPymeService pymeService,
			IBillService billService,
			PymeConverter pymeConverter,
			BillConverter billConverter,
			IDiscountPoolService discountPoolService,
			DiscountPoolConverter discountPoolConverter
		)
		{
			_logger = logger;
			_pymeService = pymeService;
			_billService = billService;
			_pymeConverter = pymeConverter;
			_billConverter = billConverter;
			_discountPoolService = discountPoolService;
			_discountPoolConverter = discountPoolConverter;
		}

		#endregion


		#region FindAll

		[HttpGet]
		public ActionResult<IEnumerable<PymeDTO>> FindAll()
		{
			IEnumerable<Pyme> pymes = _pymeService.FindAll();

			IEnumerable<PymeDTO> pymeDtos = pymes.Select(x => _pymeConverter.FromEntity(x));

			return Ok(pymeDtos);
		}

		#endregion


		#region FindBillsByPymeId

		[AllowAnonymous]
		// [Authorize(Roles = Role.User)]
		[Route("{pymeId}/bills")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BillDTO>>> FindBillsByPymeIdAsync(
			[FromRoute] int pymeId
			)
		{
			Pyme foundPyme = _pymeService.FindById(pymeId);

			if (foundPyme == null)
			{
				return BadRequest();
			}

			IEnumerable<Bill> bills = await _billService.FindAllByPymeIdAsync(pymeId);

			return Ok(bills.Select(x => _billConverter.FromEntity(x)));
		}

		#endregion


		#region FindById

		[HttpGet("{pymeId}")]
		public ActionResult<PymeDTO> FindById(
			[FromRoute] int pymeId
		)
		{
			Pyme foundPyme = _pymeService.FindById(pymeId);

			if (foundPyme == null)
			{
				return NotFound("BILL_NOT_FOUND");
			}

			PymeDTO billDto = _pymeConverter.FromEntity(foundPyme);

			return Ok(billDto);
		}

		#endregion


		#region FindDiscountsPoolByPymeId

		[Route("{pymeId}/discountspool")]
		[HttpGet]
		public ActionResult<DiscountPoolDTO> FindDiscountsPoolByPymeId(
			[FromRoute] int pymeId
		)
		{
			Pyme foundPyme = _pymeService.FindById(pymeId);

			if (foundPyme == null)
			{
				return NotFound("PYME NOT FOUND");
			}

			IEnumerable<DiscountPool> discountsPool = _discountPoolService.FindAllByPymeId(pymeId);

			IEnumerable<DiscountPoolDTO> discountPoolDTOs = discountsPool.Select(x => _discountPoolConverter.FromEntity(x));

			return Ok(discountPoolDTOs);
		}

		#endregion
	}
}