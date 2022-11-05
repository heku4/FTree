
using FTree.Models;

namespace FTree.Services.TreeNodeRepository;

public interface ITreeNodeRepository
{
    public Task WriteToRepository(TreeNode treeNode);
    public Task<TreeNode> GetFromRepository(int id);
    public Task UpdateInRepository(TreeNode treeNode);
    public Task DeleteFromRepository(int id);
}