using CoinApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoinApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ChangeController : ControllerBase 
    {
        private readonly ICoinService _coinService;
        private readonly ILogger<ChangeController> _logger;

        public ChangeController(ILogger<ChangeController> logger, ICoinService coinService) {
            _logger = logger;
            _coinService = coinService;
        }

        /// <summary>
        /// Get the amount of coins for a USD amount. Smallest amount
        /// of coins possible.
        /// </summary>
        /// <param name="amount">the amout in USD</param>
        /// <returns>a dictionary representing the amount of each
        /// coin that equals the USD amount</returns>
        [HttpGet(Name = "GetChange")]
        public async Task<IActionResult> Get(decimal amount) {
            try {
                if (amount <= 0) {
                    return BadRequest("Amount cannot be less than or equal to zero.");
                }

                var coinCount = _coinService.GetChange(amount);

                return Ok(coinCount);
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }
    }
}
