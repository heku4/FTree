using FTree.Controllers.Models;
using FTree.Models;
using FTree.Services.TreeNodeRepository;
using FTree.Services.TreeNodeRepository.MongoService;
using FTree.Services.TreeNodeSerivce;
using Microsoft.AspNetCore.Mvc;

namespace FTree.Controllers
{
    [ApiController]
    [Route("node")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;
        private readonly ITreeNodeService _treeNodeService;

        public MainController(ILogger<MainController> logger,
            ITreeNodeService treeNodeService)
        {
            _logger = logger;
            _treeNodeService = treeNodeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNode([FromBody] TreeNode request)
        {
            try
            {
                await _treeNodeService.CreateNodeAsync(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNode(int id)
        {
            TreeNode treeNode;
            try
            {
               treeNode = await _treeNodeService.GetNodeAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            return Ok(treeNode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateNode(int id)
        {
            try
            {
                await _treeNodeService.DeleteNodeAsync(id);
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