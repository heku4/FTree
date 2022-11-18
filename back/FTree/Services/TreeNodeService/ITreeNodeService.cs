using FTree.Models;

namespace FTree.Services.TreeNodeSerivce;

public interface ITreeNodeService
{
    public Task CreateNodeAsync(TreeNode node);

    public Task<TreeNode> GetNodeAsync(int id);

    public Task UpdateNodeAsync(TreeNode node, int id);

    public Task DeleteNodeAsync(int id);
}