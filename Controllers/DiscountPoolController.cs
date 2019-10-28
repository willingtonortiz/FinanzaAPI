using FinanzasBE.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FinanzasBE.Controllers
{
	[AllowAnonymous]
	[ApiController]
	[Route("api/[controller]")]
	public class DiscountPoolController : ControllerBase
	{
		private ILogger<DiscountPoolController> _logger;

		public DiscountPoolController(ILogger<DiscountPoolController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		public ActionResult Create([FromBody] DiscountPool discountPool)
		{
			// _logger.LogWarning(discountPool.Discounts.Count.ToString());

			// _logger.LogWarning(discountPool.Bank.ToString());
			// _logger.LogWarning(discountPool.Pyme.ToString());
			var json = JsonConvert.SerializeObject(discountPool, Formatting.Indented);
			_logger.LogWarning(json);

			return Ok();
		}
	}
}