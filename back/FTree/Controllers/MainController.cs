using FTree.Controllers.Models;
using FTree.Models;
using FTree.Services.TreeNodeRepository;
using FTree.Services.TreeNodeRepository.MongoService;
using Microsoft.AspNetCore.Mvc;

namespace FTree.Controllers
{
    [ApiController]
    [Route("node")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;
        private readonly ITreeNodeRepository _repository;

        public MainController(ILogger<MainController> logger,
            ITreeNodeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNode([FromBody] TreeNode request)
        {
            try
            {
                await _repository.WriteToRepository(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetNode(int id)
        {
            TreeNode treeNode;
            try
            {
               treeNode = await _repository.GetFromRepository(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(treeNode);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> UpdateNode(int id)
        {
            try
            {
                await _repository.DeleteFromRepository(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        
    }
}