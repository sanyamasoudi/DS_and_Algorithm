public class PartyPlaningAtWork
{
    public static List<TreeNode> ComputeMax(TreeNode tree)
    {
        List<TreeNode> NotChildNodesList = new()
        {
            tree
        };
        List<TreeNode> ChildNodesList = new();
        var NotChildNodes = FindHasNotChildNodes(tree, NotChildNodesList);
        var ChildNodes = FindHasChildNodes(tree, ChildNodesList);
        if (NotChildNodes.Count > ChildNodes.Count) return NotChildNodes.OrderBy(x=>x.id).ToList();
        else return ChildNodes.OrderBy(x=>x.id).ToList();
    }

    private static List<TreeNode> FindHasNotChildNodes(TreeNode tree, List<TreeNode> result)
    {
        if (tree.children.Count == 0)
        {
            result.Add(tree);
        }
        else
        {
            foreach (var item in tree.children)
            {
                FindHasNotChildNodes(item, result);
            }
        }
        return result;
    }
    private static List<TreeNode> FindHasChildNodes(TreeNode tree, List<TreeNode> result)
    {
        if (tree.children.Count != 0)
        {
            result.Add(tree);
        }
        else
        {
            foreach (var item in tree.children)
            {
                FindHasChildNodes(item, result);
            }
        }
        return result;
    }
}
public class TreeNode
{
    public int id { get; set; }
    public List<TreeNode> children { get; set; }
    public TreeNode(int Id)
    {
        this.id = Id;
        children = new List<TreeNode>();
    }
}