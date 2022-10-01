using FTree.Services.MongoService;
using Microsoft.AspNetCore.Mvc;

namespace FTree.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;
        private readonly MongoService _mongoService;

        public MainController(ILogger<MainController> logger,
            MongoService mongoService)
        {
            _logger = logger;
            _mongoService = mongoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var conStatus = _mongoService.CheckConnection();
                if (!conStatus)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Err:{ex.Message}");
            }

            return Ok();
        }
    }
}