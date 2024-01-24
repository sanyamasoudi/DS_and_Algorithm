


public static class SMTreeNaive
{
    public static void Main(string[] args)
    {
        long count = 0;
        int n = int.Parse(Console.ReadLine());
        var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var mainTree = BuildTree(arr);
        Premutation(arr, 0, arr.Length - 1);
        foreach (var item in allPremutation)
        {
            var s = BuildTree(item);
            if (IsSimilarTree(mainTree, s))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    private static bool IsSimilarTree(Node mainTree, Node s)
    {
        if (mainTree == null && s == null)
        {
            return true;
        }
        if ((mainTree == null && s != null) || (mainTree != null && s == null))
        {
            return false;
        }
        if (mainTree.data != s.data)
        {
            return false;
        }
        return IsSimilarTree(mainTree.left, s.left) &&
        IsSimilarTree(mainTree.right, s.right);
    }
    public static List<int[]> allPremutation = new List<int[]>();
    private static void Premutation(int[] arr, int l, int r)
    {
        if (l == r)
        {
            allPremutation.Add((int[])arr.Clone());
        }
        for (int i = l; i <= r; i++)
        {
            swap(arr, l, i);
            Premutation(arr, l + 1, r);
            swap(arr, l, i);
        }
    }

    private static void swap(int[] arr, int l, int i)
    {
        var tmp = arr[l];
        arr[l] = arr[i];
        arr[i] = tmp;
    }

    public static Node BuildTree(int[] arr)
    {
        var root = new Node(arr[0]);
        for (var i = 0; i < arr.Length; i++)
        {
            Insert(root, arr[i]);
        }
        return root;
    }

    private static void Insert(Node root, int v)
    {
        var p = Find(root, v);
        var newNode = new Node(v);
        if (p.data != v)
        {
            if (p.data < v)
            {
                p.right = newNode;
            }
            else
            {
                p.left = newNode;
            }
        }
    }

    private static Node Find(Node root, int v)
    {
        if (root.data == v)
        {
            return root;
        }
        else if (root.data > v)
        {
            if (root.left != null)
                return Find(root.left, v);
            else
                return root;
        }
        else
        {
            if (root.right != null)
                return Find(root.right, v);
            else
                return root;
        }
    }
}
public class Node
{
    public int data;
    public Node left;
    public Node right;
    public Node(int d)
    {
        this.data = d;
        left = right = null;
    }
}