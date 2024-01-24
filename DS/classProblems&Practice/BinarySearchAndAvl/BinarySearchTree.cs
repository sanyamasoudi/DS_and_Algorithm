
public class Node
{
    public Node parent;
    public int value;
    public Node left;
    public Node right;
    public Node(int v)
    {
        this.parent = null;
        this.value = v;
        this.right = null;
        this.left = null;
    }
}
public class BinarySearchTree
{
    // public static void Main(string[] args)
    // {
    //     Node root = new Node(7);
    //     Node n1 = new Node(4);
    //     Node n2 = new Node(13);
    //     Node n3 = new Node(1);
    //     Node n4 = new Node(6);
    //     Node n5 = new Node(10);
    //     Node n6 = new Node(15);
    //     root.right = n2; root.left = n1;
    //     n1.right = n4; n1.left = n3; n1.parent = root;
    //     n2.right = n6; n2.left = n5; n2.parent = root;
    //     n3.parent = n1; n4.parent = n1;
    //     n5.parent = n2; n6.parent = n2;
    //     //var result = Find(2, root);
    //     // var result3 = FindModification(5, root);
    //     // Console.WriteLine(result3 != null ? "True" : "False");
    //     // var result2 = MakeTree(new int[] { 1, 4, 6, 7, 10, 13, 15 }, null);
    //     //Console.WriteLine(result2.value);
    //     // var result = NextLargest(n6);
    //     // var r = RangeSearch(5, 12, root);
    //     // Console.WriteLine(String.Join(" ", r));
    //     // Insert(5, root);
    //     // Delete(n2);
    //     RotateRight(n2);
    //     PrintTree(root, 5);
    // }
    public static void PrintTree(Node root, int spacecount)
    {
        if (root == null)
        {
            return;
        }
        PrintTree(root.left, spacecount + 10);
        for (var i = 0; i < spacecount; i++)
        {
            Console.Write(" ");
        }
        Console.Write(root.value + "\n");
        PrintTree(root.right, spacecount + 10);
    }
    public static Node MakeTree(int[] arr, Node parent)
    {
        if (arr.Length != 0)
        {
            int IdxRoot = arr.Length / 2;
            Node root = new Node(arr[IdxRoot]);
            root.parent = parent;
            root.left = MakeTree(arr.Where((_, i) => i < IdxRoot).ToArray(), root);
            root.right = MakeTree(arr.Where((_, i) => i > IdxRoot).ToArray(), root);
            return root;
        }
        return null;
    }
    // O(depth tree) .. O(log n)
    public static Node Find(int key, Node n)
    {
        // if (n == null)
        // {
        //     return null;
        // }
        // else if (n.value == key)
        // {
        //     return n;
        // }
        // else if (n.value > key)
        // {
        //     return Find(key, n.left);
        // }
        // else if (n.value < key)
        // {
        //     return Find(key, n.right);
        // }
        // return null;
        while (n != null)
        {
            if (n.value == key)
            {
                return n;
            }
            else if (n.value > key)
            {
                n = n.left;
            }
            else if (n.value < key)
            {
                n = n.right;
            }
        }
        return null;
    }
    public static Node FindModification(int key, Node n)
    {
        if (n.value == key)
        {
            return n;
        }
        else if (n.value > key)
        {
            if (n.left != null)
            {
                return FindModification(key, n.left);
            }
            else
            {
                return n;
            }
        }
        else if (n.value < key)
        {
            if (n.right != null)
            {
                return FindModification(key, n.right);
            }
            else
            {
                return n;
            }
        }
        return null;
    }
    public static Node NextLargest(Node n)
    {
        if (n.right != null)
        {
            return LeftDescendant(n.right);
        }
        else
        {
            return RightAncestor(n);
        }
    }

    private static Node RightAncestor(Node n)
    {
        if (n.parent == null)
        {
            return null;
        }
        else if (n.value < n.parent.value)
        {
            return n.parent;
        }
        else
        {
            return RightAncestor(n.parent);
        }
    }

    private static Node LeftDescendant(Node n)
    {
        if (n.left == null)
        {
            return n;
        }
        else
        {
            return LeftDescendant(n.left);
        }
    }
    public static List<Node> RangeSearch(int x, int y, Node R)
    {
        List<Node> results = new List<Node>();
        var N = FindModification(x, R);
        while (N.value <= y)
        {
            if (N.value >= x)
            {
                results.Add(N);
            }
            N = NextLargest(N);
        }
        return results;
    }
    public static void Insert(int key, Node root)
    {
        Node newNode = new Node(key);
        var p = FindModification(key, root);
        newNode.parent = p;
        if (p.value < key)
        {
            p.right = newNode;
        }
        else
        {
            p.left = newNode;
        }
    }
    public static void Delete(Node n)
    {
        if (n.right == null)
        {
            ReplaceTwoNode(n, n.left);
        }
        else
        {
            var x = NextLargest(n);
            var tmp = x;
            while (tmp != null)
            {
                if (tmp.left == null)
                {
                    tmp.left = n.left;
                    break;
                }
                tmp = tmp.left;
            }
            ReplaceTwoNode(n, x);
            ReplaceTwoNode(x, x.right);
        }
    }
    private static void ReplaceTwoNode(Node m, Node n)
    {
        if (m.parent.right == m)
        {
            m.parent.right = n;
        }
        else
        {
            m.parent.left = n;
        }
    }
    public static void RotateRight(Node x)
    {
        var P = x.parent;
        var Y = x.left;
        var B = Y.right;
        Y.parent = P;
        if (x.value > P.value)
        {
            P.right = Y;
        }
        else
        {
            P.left = Y;
        }
        x.parent = Y; Y.right = x;
        B.parent = x; x.left = B;
    }
}