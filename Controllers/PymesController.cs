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
    public class PymesController : ControllerBase
    {
        private readonly IPymeService _pymeService;
        private readonly IBillService _billService;
        private readonly PymeConverter _pymeConverter;
        private readonly BillConverter _billConverter;

        public PymesController(
            IPymeService pymeService,
            IBillService billService,
            PymeConverter pymeConverter,
            BillConverter billConverter
        )
        {
            _pymeService = pymeService;
            _billService = billService;
            _pymeConverter = pymeConverter;
            _billConverter = billConverter;
        }


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
        public ActionResult<IEnumerable<BillDTO>> FindBillsByPymeId(int pymeId)
        {
            Pyme foundPyme = _pymeService.FindById(pymeId);

            if (foundPyme == null)
            {
                return BadRequest();
            }

            IEnumerable<Bill> bills = _billService.FindByPymeId(pymeId);

            return bills.Select(x => _billConverter.FromEntity(x)).ToList();
        }

        #endregion
    }
}