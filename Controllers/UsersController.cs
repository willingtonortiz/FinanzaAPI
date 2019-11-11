using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanzasBE.Converters;
using FinanzasBE.DTOs;
using FinanzasBE.Entities;
using FinanzasBE.Enums;
using FinanzasBE.Helpers;
using FinanzasBE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanzasBE.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IPymeService _pymeService;
        private readonly IBillService _billService;
        private readonly BillConverter _billConverter;

        public UsersController(
            ILogger<UsersController> logger,
            IUserService userService,
            IPymeService pymeService,
            IBillService billService,
            BillConverter billConverter
        )
        {
            _logger = logger;
            _userService = userService;
            _pymeService = pymeService;
            _billService = billService;
            _billConverter = billConverter;
        }


        #region FindAll

        // [Authorize(Roles = Role.Admin)]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<User>> FindAll()
        {
            IEnumerable<User> users = _userService.FindAll();
            return Ok(users);
        }

        #endregion


        #region FindById

        [HttpGet("{id}")]
        public ActionResult FindById(int id)
        {
            User user = _userService.FindById(id);

            if (user == null)
            {
                return NotFound();
            }

            long currentUserId = long.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(RoleType.ADMIN))
            {
                return Forbid();
            }

            return Ok(user);
        }

        #endregion


        #region FindBillsByUserId

        [AllowAnonymous]
        [HttpGet("{userId}/bills")]
        public async Task<ActionResult<IEnumerable<BillDTO>>> FindBillsByUserId(
            [FromRoute] int userId
        )
        {
            User foundUser = _userService.FindById(userId);

            if (foundUser == null)
            {
                return BadRequest();
            }

            IEnumerable<Bill> bills = await _billService.FindAllByPymeIdAsync(userId);

            return Ok(bills.Select(x => _billConverter.FromEntity(x)));
        }

        #endregion
    }
}