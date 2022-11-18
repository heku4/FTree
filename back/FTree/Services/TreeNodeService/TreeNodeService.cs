using FTree.Models;
using FTree.Services.TreeNodeRepository;
using FTree.Services.TreeNodeSerivce;

public class TreeNodeSerivce : ITreeNodeService
{
    private ITreeNodeRepository _nodeRepository;


    public TreeNodeSerivce(ITreeNodeRepository treeNodeRepository)
    {
        _nodeRepository = treeNodeRepository;
    }

    public async Task CreateNodeAsync(TreeNode node)
    {
        await _nodeRepository.WriteToRepository(node);
    }

    public async Task DeleteNodeAsync(int id)
    {
        await _nodeRepository.DeleteFromRepository(id);
    }

    public async Task<TreeNode> GetNodeAsync(int id)
    {
        var node = await _nodeRepository.GetFromRepository(id);
        return node;
    }

    public async Task UpdateNodeAsync(TreeNode node, int id)
    {
        await _nodeRepository.UpdateInRepository(node);
    }
}
