using FTree.Models;

namespace FTree.Services.TreeNodeSerivce;

public interface ITreeNodeService
{
    public Task<TreeNode> CreateNode(TreeNode node);

    public Task<TreeNode> GetNode(string id);

    public Task<TreeNode> UpdateNode(TreeNode node, string id);

    public Task<bool> DeleteNode(string id);
}