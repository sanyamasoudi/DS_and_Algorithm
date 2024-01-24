public static class AVLTree
{
    // public static void Main(string[] args)
    // {
    //     AVLNode root = new AVLNode(4);
    //     AVLNode n1 = new AVLNode(3);
    //     AVLNode n2 = new AVLNode(2);
    //     AVLNode n3 = new AVLNode(5);
    //     AVLNode n4 = new AVLNode(1);
    //     AVLNode n5 = new AVLNode(6);
    //     AVLNode n6 = new AVLNode(7);
    //     root.left = n1; root.right = n3;
    //     n1.parent = root; n3.parent = root;
    //     n1.left = n2;
    //     n2.parent = n1;
    //     n3.left = n4; n3.right = n5;
    //     n4.parent = n3; n5.parent = n3;
    //     n5.right = n6;
    //     n6.parent = n5;
    //     InitialHeight(root);
    //     // var result2 = MakeTree(new int[] { 1, 4, 6, 7, 10, 13, 15 }, null);
    //     // var result = Height(n6);
    //     // Console.WriteLine(result);
    //     // AVLInsert(8, root);
    //     AVLDelete(n3, root);
    //     PrintTree(root, 5);
    // }

    private static void InitialHeight(AVLNode root)
    {
        if (root == null)
        {
            return;
        }
        InitialHeight(root.left);
        InitialHeight(root.right);
        AdjustHeight(root);
    }

    private static void PrintTree(AVLNode root, int spacecount)
    {
        if (root == null)
        {
            return;
        }
        PrintTree(root.right, spacecount + 10);
        for (var i = 0; i < spacecount; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(root.value);
        PrintTree(root.left, spacecount + 10);
    }
    public static void AVLDelete(AVLNode n, AVLNode root)
    {
        AVLNode M;
        if (n.right == null)
        {
            M = n.left;
        }
        else
        {
            M = Next(n);
        }
        Delete(n);
        PrintTree(root, 5);
        Rebalance(M.parent);
    }

    private static void Delete(AVLNode n)
    {
        if (n.right == null)
        {
            Replace(n, n.left);
        }
        else
        {
            var N = Next(n);
            var tmp = N;
            while (tmp != null)
            {
                if (tmp.left == null)
                {
                    tmp.left = n.left;
                    break;
                }
                tmp = tmp.left;
            }
            Replace(n, N);
            Replace(N, N.right);
        }
    }

    private static AVLNode Next(AVLNode n)
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

    private static AVLNode RightAncestor(AVLNode n)
    {
        if (n.parent == null)
        {
            return null;
        }
        else if (n.parent.value > n.value)
        {
            return n.parent;
        }
        else
        {
            return RightAncestor(n.parent);
        }
    }

    private static AVLNode LeftDescendant(AVLNode n)
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

    private static void Replace(AVLNode n, AVLNode m)
    {
        if (n.parent.right == n)
        {
            n.parent.right = m;
        }
        else
        {
            n.parent.left = m;
        }
    }

    public static void AVLInsert(int key, AVLNode root)
    {
        Insert(key, root);
        var N = Find(key, root);
        Rebalance(N);
    }

    private static void Rebalance(AVLNode n)
    {
        AdjustHeight(n);
        var balanceFactor = GetBalanceFactor(n);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(n.left) < 0)
            {
                n.left = RotateLeft(n.left);
            }
            n = RotateRight(n);
        }
        if (balanceFactor < -1)
        {
            if (GetBalanceFactor(n.right) > 0)
            {
                n.right = RotateRight(n.right);
            }
            n = RotateLeft(n);
        }

        if (n.parent != null)
        {
            Rebalance(n.parent);
        }
    }

    private static int GetHeight(AVLNode n)
    {
        if (n == null)
        {
            return 0;
        }
        return n.Height;
    }

    private static int GetBalanceFactor(AVLNode n)
    {
        return GetHeight(n.left) - GetHeight(n.right);
    }

    private static AVLNode RotateRight(AVLNode n)
    {
        var newRoot = n.left;
        n.left = newRoot.right;
        newRoot.right = n;
        AdjustHeight(n);
        AdjustHeight(newRoot);
        return newRoot;
    }

    private static AVLNode RotateLeft(AVLNode n)
    {
        var newRoot = n.right;
        n.right = newRoot.left;
        newRoot.left = n;
        AdjustHeight(n);
        AdjustHeight(newRoot);
        return newRoot;
    }

    private static void AdjustHeight(AVLNode n)
    {
        n.Height = 1 + Math.Max(GetHeight(n.left), GetHeight(n.right));
    }
    private static AVLNode Find(int key, AVLNode root)
    {
        if (root.value == key)
        {
            return root;
        }
        else if (root.value > key)
        {
            if (root.left != null)
                return Find(key, root.left);
            return root;
        }
        else if (root.value < key)
        {
            if (root.right != null)
                return Find(key, root.right);
            return root;
        }
        return null;
    }

    private static void Insert(int key, AVLNode root)
    {
        var N = Find(key, root);
        var newNode = new AVLNode(key);
        newNode.parent = N;
        if (N.value > newNode.value)
        {
            N.left = newNode;
        }
        else
        {
            N.right = newNode;
        }

    }
    public static int Height(AVLNode n)
    {
        if (n == null)
        {
            return 0;
        }
        return 1 + Math.Max(Height(n.left), Height(n.right));
    }
    public static AVLNode AVLTreeMergeWithRoot(AVLNode R1, AVLNode R2, AVLNode T)
    {
        if (Math.Abs(GetHeight(R1) - GetHeight(R2)) <= 1)
        {
            MergeWithRoot(R1, R2, T);
            T.Height = 1 + Math.Max(GetHeight(R1), GetHeight(R2));
            return T;
        }
        else if (GetHeight(R1) > GetHeight(R2))
        {
            var Rprin = AVLTreeMergeWithRoot(R1.right, R2, T);
            R1.right = Rprin;
            Rprin.parent = R1;
            Rebalance(R1);
            return T;
        }
        else
        {
            var Rprin = AVLTreeMergeWithRoot(R1, R2.left, T);
            R2.left = Rprin;
            Rprin.parent = R2;
            Rebalance(R2);
            return T;
        }
    }
    public static AVLNode Merge(AVLNode R1, AVLNode R2)
    {
        var T = Find(int.MaxValue, R1);
        Delete(T);
        MergeWithRoot(R1, R2, T);
        return T;
    }
    public static AVLNode MergeWithRoot(AVLNode R1, AVLNode R2, AVLNode T)
    {
        T.left = R1;
        T.right = R2;
        R1.parent = T;
        R2.parent = T;
        return T;
    }

}
public class AVLNode
{
    public AVLNode parent;
    public int value;
    public AVLNode left;
    public AVLNode right;
    public int Height;
    public AVLNode(int v)
    {
        this.parent = null;
        this.value = v;
        this.right = null;
        this.left = null;
        this.Height = 1;
    }
}