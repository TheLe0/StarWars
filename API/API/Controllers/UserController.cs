using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserRepository repository;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            repository = new();
        }


        [HttpPost]
        [Route("starstore/user/create")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] User user)
        {
            string _token = string.Empty;
            try
            {
                _token = repository.Create(user.Username, user.Password);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to create the user {user.Username}.", exc);
            }

            return Ok(_token);
        }

        [HttpPost]
        [Route("starstore/user/auth")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] User user)
        {
            string _token = string.Empty;
            try
            {
                _token = repository.Login(user.Username, user.Password);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to authenticate the user {user.Username}.", exc);
            }

            return Ok(_token);
        }
    }
}
