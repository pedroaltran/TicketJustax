using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxRecovery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("HealthCheck: OK");
            return Ok();
        }
    }
}