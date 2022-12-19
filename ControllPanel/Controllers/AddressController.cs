using AutoMapper;
using ControllPanel.Data;
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
    public class AddressController : ControllerBase
    {
        private readonly IUnitofWork _Unitofwork;
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _Mapper;
      

        public AddressController(IUnitofWork uunitofwork, ILogger<AddressController> logger, IMapper Mapper)
        {
            _Unitofwork = uunitofwork;
            _logger = logger;
            _Mapper = Mapper;
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Updateaddress(int id, [FromBody] UpdateAdressDTO addressDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invailed POST attemp! {nameof(Updateaddress)}");
                return BadRequest("Internal Server Error, Please try agin later!");
            }
            try
            {
                var address = await _Unitofwork.Address.Get(q => q.Id == id);
                if (address == null)
                {
                    _logger.LogError($"Invailed POST attemp! {nameof(Updateaddress)}");
                    return BadRequest("Invalid Dtaa!");
                }
                _Mapper.Map(addressDTO, address);
                _Unitofwork.Address.Update(address);
                await _Unitofwork.Save();

                return NoContent(); // CreatedAtRoute("GetAddress", new { id = address.Id }, address);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Somtning Went Weong in the {nameof(Updateaddress)}");
                return Problem($"Somtning Went Weong in the {nameof(Updateaddress)}", statusCode: 500);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAddresses()
        {

            try
            {
                var Addreses = await _Unitofwork.Address.GetAll();
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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAddress(int id)
        {

            try
            {
                var Address = await _Unitofwork.Address.Get(q => q.Id ==id, new List<string> { "Accounts" });
                var result = _Mapper.Map<AddressDTO>(Address);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" Somthing Went Wrong in the {nameof(GetAddresses)}");
                return StatusCode(500, "Internal Server Error Please Try Again Lateer!");

            }
        }

        [HttpPost]
       // [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Createddress([FromBody] CreateAddressDTO createAddress)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invailed POST attemp! {nameof(Createddress)}");
                return StatusCode(500, "Internal Server Error, Please try agin later!");
            }
            try
            {
                var address = _Mapper.Map<Address>(createAddress);
                await _Unitofwork.Address.Insert(address);
                await _Unitofwork.Save();

                return Ok(address); // CreatedAtRoute("GetAddress", new { id = address.Id }, address);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Somtning Went Weong in the {nameof(Createddress)}");
                return Problem($"Somtning Went Weong in the {nameof(Createddress)}", statusCode: 500);
            }

        }
    }
}
