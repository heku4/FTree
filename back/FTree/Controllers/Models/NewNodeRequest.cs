using FTree.Models;

namespace FTree.Controllers.Models
{
    public class NewNodeRequest
    {
        public FamilyMember? FamilyMember { get; set; }

        public IEnumerable<int>? ParentIds { get; set; }

        public IEnumerable<int>? ChildrenIds { get; set; }
    }
}
