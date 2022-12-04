using AutoMapper;
using ControllPanel.IRepository;
using ControllPanel.Model;
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
    public class AddressController : ControllerBase
    {
        private readonly IUnitofWork _uunitofwork;
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _Mapper;

        public AddressController(IUnitofWork uunitofwork, ILogger<AddressController> logger, IMapper Mapper)
        {
            _uunitofwork = uunitofwork;
            _logger = logger;
            _Mapper = Mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAddresses()
        {

            try
            {
                var Addreses = await _uunitofwork.Address.GetAll();
                var result = _Mapper.Map<IList<AddressDTO>>(Addreses);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Somthing Went Wrong in the {nameof(GetAddresses)}");
                return StatusCode(500, "Internal Server Error Please Try Again Lateer!");

            }
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAddress(int id)
        {

            try
            {
                var Address = await _uunitofwork.Address.Get(q => q.Id ==id, new List<string> { "Accounts" });
                var result = _Mapper.Map<AddressDTO>(Address);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Somthing Went Wrong in the {nameof(GetAddresses)}");
                return StatusCode(500, "Internal Server Error Please Try Again Lateer!");

            }
        }
    }
}
