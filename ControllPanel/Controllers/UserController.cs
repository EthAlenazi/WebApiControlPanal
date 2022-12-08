using AutoMapper;
using ControllPanel.Data;
using ControllPanel.IRepository;
using ControllPanel.Model;
using ControllPanel.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public UserController(IMapper mapper, 
            ILogger<AccountController> logger,
            UserManager<ApiUser> userManager,
             IAuthManager authManager)
        {
            _logger = logger;
            _mapper = mapper;   
            _userManager = userManager;
            _authManager = authManager;

        }

        [HttpPost]
        [Route("Register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            _logger.LogInformation($"Registeration Attemp for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = _mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRolesAsync(user,userDTO.Roles);
                return Accepted();
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Somtning Went Weong in the {nameof(Register)}");
                return Problem($"Somtning Went Weong in the {nameof(Register)}", statusCode: 500);
            }

        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDTO)
        {
            _logger.LogInformation($"Login Attemp for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {               
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized(userDTO);
                }
                return Accepted(new  {Token = await _authManager.CreateToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somtning Went Weong in the {nameof(Login)}");
                return Problem($"Somtning Went Weong in the {nameof(Login)}", statusCode: 500);
            }

        }
    }
}
