
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         MPQ.Build(new int[]{1,2,3,4,5});
//         MPQ.PrintTree(MPQ.root,15);
//     }
// }
public class mpqNode
{
    public int value;
    public mpqNode left;
    public mpqNode right;
    public mpqNode(int n)
    {
        value = n;
        left = null;
        right = null;
    }
}
public static class MPQ
{
    public static mpqNode root;
    public static List<int> result;
    private static readonly int Count=10;

    static mpqNode createNode(int v)
    {
        mpqNode newNode = new mpqNode(v);
        return newNode;
    }
    public static void Build(int[] nums)
    {
        Array.Sort(nums);
        int mianeIndex = (nums.Length - 1) / 2;
        int miane = nums[mianeIndex];
        var newNode = createNode(miane);
        var newNodeLeft = createNode(nums[mianeIndex + 1]);
        var newNodeRight = createNode(nums[mianeIndex - 1]);
        newNode.left = newNodeLeft;
        newNode.right = newNodeRight;

        for (var i = mianeIndex - 1; i >= 1; i--)
        {
            var next = createNode(nums[i - 1]);
            newNodeLeft.left = next;
            newNodeLeft = next;
        }
        for (var i = mianeIndex + 1; i <= nums.Length-2; i++)
        {
            var next = createNode(nums[i + 1]);
            newNodeRight.right = next;
            newNodeRight = next;
        }
        root=newNode;
    }
    public static void PrintTree(mpqNode n, int space)
    {
        if (n == null)
        {
            return;
        }
        space += Count;
        PrintTree(n.left, space);
        Console.Write("\n");
        for (var i = Count; i < space; i++)
        {
            Console.Write(" ");
        }
        Console.Write(n.value + "\n");
        PrintTree(n.right, space);

    }
}