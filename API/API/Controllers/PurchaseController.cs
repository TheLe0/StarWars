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
    public class PurchaseController : Controller
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly PurchaseRepository repository;

        public PurchaseController(ILogger<PurchaseController> logger, IDistributedCache cache)
        {
            _logger = logger;
            repository = new(cache);
        }

        [HttpGet]
        [Route("starstore/history")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPurchases()
        {
            try
            {
                return Ok(await repository.List(Guid.Empty));
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to retrive all the purchases", exc);

                return StatusCode(500, "Internal server error!");
            }
        }

        [HttpGet]
        [Route("starstore/history/{clientId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllPurchasesByClient(Guid clientId)
        {
            try
            {
                return Ok(await repository.List(clientId));
            }
            catch (Exception exc)
            {
                _logger.LogError($"Unable to retrive all the purchases of the client {clientId}", exc);

                return StatusCode(500, "Internal server error!");
            }
        }
    }
}
