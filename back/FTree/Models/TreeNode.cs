namespace FTree.Models
{
    public class TreeNode
    {
        public int Id { get; set; }

        public FamilyMember FamilyMember { get; set; } = new FamilyMember();

        public IEnumerable<int>? Parents { get; set; }

        public IEnumerable<int>? Children { get; set; } 
    }
}
