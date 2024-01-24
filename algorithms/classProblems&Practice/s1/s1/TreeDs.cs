//binary search and recursive 
public class Tree
{
    public Tree right,left;
    public int val;
    public Tree(int Val=0,Tree Right=null,Tree Left=null)
    {
        this.val=Val;
        this.left=Left;
        this.right=Right;
    }
    public int CalculateTreeHeight(Tree tree)
    {
        if (tree.val== 0)
        {
            return 0;
        }
        int leftHeight=CalculateTreeHeight(tree.left);
        int rightHeight=CalculateTreeHeight(tree.right);
        return Math.Max(leftHeight,rightHeight)+1;
    }
}