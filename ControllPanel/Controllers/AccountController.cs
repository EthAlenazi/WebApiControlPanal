using AutoMapper;
using ControllPanel.IRepository;
using ControllPanel.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitofWork _Unitofwork;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, ILogger<AccountController> logger, IUnitofWork Unitofwork)
        {
            _logger = logger;
            _mapper = mapper;
            _Unitofwork = Unitofwork;
                
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccounts()
        {

            try
            {
                var Accounts = await _Unitofwork.Account.GetAll();
               var results = _mapper.Map<IList<AccountDTO>>(Accounts);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthig want wrong in {nameof(GetAccounts)} ");
                return StatusCode(500, "Internal Server Error Please Try Again Later! "); 
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccount(int id)
        {

            try
            {
                var Account = await _Unitofwork.Account.Get( q=> q.Id==id ,new List<string> { "Addresses"});
                var results = _mapper.Map<AccountDTO>(Account);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somthig want wrong in {nameof(GetAccount)} ");
                return StatusCode(500, "Internal Server Error Please Try Again Later! ");
            }
        }

    }
}
