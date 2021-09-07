using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly TransactionRepository repository;

        public TransactionController(ILogger<TransactionController> logger, IDistributedCache cache)
        {
            _logger = logger;
            repository = new(cache);
        }

        [HttpPost]
        [Route("starstore/buy")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewTransaction([FromBody] Transaction transaction)
        {
            try
            {
                var _createdTransaction = await repository.Create(transaction);

                return Ok(_createdTransaction);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to create the transaction.", exc);

                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
