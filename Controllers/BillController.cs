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
	public class BillController : ControllerBase
	{
		private readonly IBillService _billService;
		private readonly IPymeService _pymeService;
		private readonly ILogger<BillController> _logger;

		public BillController(IBillService billService, IPymeService pymeService, ILogger<BillController> logger)
		{
			_billService = billService;
			_pymeService = pymeService;
			_logger = logger;
		}


		[Authorize(Roles = Role.User)]
		[Route("[action]/{id}")]
		[HttpGet]
		public ActionResult<IEnumerable<BillDTO>> FindByUserId(int id)
		{
			Pyme foundPyme = _pymeService.FindByUserId(id);

			if (foundPyme == null)
			{
				return BadRequest();
			}

			IEnumerable<Bill> bills = _billService.FindByPymeId(foundPyme.PymeId);

			IEnumerable<BillDTO> billDTOs = bills.Select(x => new BillDTO
			{
				BillId = x.BillId,
				BillType = x.BillType,
				Amount = x.Amount,
				Currency = x.Currency,
				DrawerRuc = x.DrawerRuc,
				DraweeRuc = x.DraweeRuc,
				StartDate = x.StartDate,
				EndDate = x.EndDate
			});

			return billDTOs.ToList();
		}


		[Authorize(Roles = Role.User)]
		[HttpGet("{id}")]
		public ActionResult<BillDTO> FindById(int id)
		{
			Bill bill = _billService.FindById(id);

			if (bill == null)
			{
				return BadRequest();
			}

			BillDTO billDTO = new BillDTO(bill);

			return billDTO;
		}


		[Authorize(Roles = Role.User)]
		[HttpPost]
		public ActionResult<BillDTO> Create([FromBody] BillDTO billDTO)
		{
			int userId = int.Parse(User.Identity.Name);
			_logger.LogWarning(userId.ToString());

			Pyme foundPyme = _pymeService.FindByUserId(userId);
			_logger.LogWarning(foundPyme.ToString());

			if (foundPyme == null)
			{
				return BadRequest();
			}

			Bill bill = new Bill
			{
				StartDate = billDTO.StartDate,
				EndDate = billDTO.EndDate,
				Currency = billDTO.Currency,
				Amount = billDTO.Amount,
				BillType = billDTO.BillType,
				DrawerRuc = billDTO.DrawerRuc,
				DraweeRuc = billDTO.DraweeRuc,
				PymeId = foundPyme.PymeId,
			};

			Bill createdBill = _billService.Create(bill);

			billDTO.BillId = createdBill.BillId;

			return billDTO;
		}
	}
}
