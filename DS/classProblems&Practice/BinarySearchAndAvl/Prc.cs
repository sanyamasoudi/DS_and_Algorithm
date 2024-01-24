using System.Diagnostics;
using System.Drawing;

public class PrcNode
{
    public int key;
    public int height;
    public PrcNode parent;
    PrcNode _left;
    public PrcNode left
    {
        get => _left;
        set
        {
            _left = value;
            if (value != null) value.parent = this;
        }
    }
    PrcNode _right;
    public PrcNode right
    {
        get => _right;
        set
        {
            _right = value;
            if (value != null) value.parent = this;
        }
    }
    public PrcNode(int k, int h = 1)
    {
        this.key = k;
        this.height = h;
    }
}
public class PrcTree
{
    public static void Main(string[] args)
    {
        var root = MakeTree();
        InitialHeightTree(root);
        // InitialHeightTree(root.Item1);
        // InitialHeightTree(root.Item2);
        // var Node = Find(7, root);
        // var N = Next(Node);
        // InsertBase(1, root);
        // DeleteBase(5, root);
        // RotateRight(root, ref root);
        // RotateLeft(root, ref root);
        // RebalanceRight(root, ref root);
        // AVLDelete(5, root);
        // var result = RangeSearch(4, 8, root);
        // Console.WriteLine(String.Join(" ", result.Select(i => i.key)));
        // var newRoot = MergeWithRoot(root.Item1, root.Item2, new PrcNode(8));
        // var newRoot = AVLTreeMerge(root.Item1, root.Item2);
        // root.Item1 = newRoot; root.Item2 = newRoot;
        // PrcNode root = new PrcNode(1);
        // AVLInsert(1, ref root);

        // AVLInsert(2, ref root);

        // AVLInsert(3, ref root);
        // AVLInsert(4, ref root);
        // AVLInsert(6, ref root);
        // AVLDelete(2, ref root);
        // AVLDelete(2, ref root);
        PrintElementInTree(root);
        Console.WriteLine();
        //PrintTree(root, 0);
    }
    public static List<PrcNode> RangeSearch(int x, int y, PrcNode root)
    {
        List<PrcNode> results = new List<PrcNode>();
        var N = Find(x, root);
        while (N.key <= y)
        {
            if (N.key >= x)
            {
                results.Add(N);
            }
            N = Next(N);
        }
        return results;
    }
    public static PrcNode Next(PrcNode n)
    {
        if (n.right != null)
        {
            return LeftDescendent(n.right);
        }
        else
        {
            return RightAncestor(n);
        }
    }

    private static PrcNode RightAncestor(PrcNode n)
    {
        while (n != null)
        {
            if (n.parent == null)
            {
                return null;
            }
            else if (n.parent.key > n.key)
            {
                return n.parent;
            }
            else
            {
                n = n.parent;
            }
        }
        return null;
        // if(n.parent.key>n.key)
        // {
        //     return n.parent;
        // }
        // else
        // {
        //     RightAncestor(n.parent);
        // }
    }

    private static PrcNode LeftDescendent(PrcNode n)
    {
        while (n.left != null)
        {
            n = n.left;
        }
        return n;
        // if (n.left == null)
        // {
        //     return n;
        // }
        // else
        // {
        //     return LeftDescendent(n.left);
        // }
    }

    public static PrcNode Find(int key, PrcNode root)
    {
        var tmp = root;
        while (tmp != null)
        {
            if (tmp.key == key)
            {
                return tmp;
            }
            else if (tmp.key < key)
            {
                if (tmp.right != null)
                {
                    tmp = tmp.right;
                }
                else
                {
                    return tmp;
                }
            }
            else
            {
                if (tmp.left != null)
                {
                    tmp = tmp.left;
                }
                else
                {
                    return tmp;
                }
            }
        }
        return null;
    }
    public static void AdjustHeight(PrcNode n)
    {
        n.height = 1 + Math.Max(GetHeight(n.right), GetHeight(n.left));
    }

    private static int GetHeight(PrcNode n)
    {
        if (n == null)
        {
            return 0;
        }
        else
        {
            return n.height;
        }
    }
    public static void InitialHeightTree(PrcNode root)
    {
        if (root == null)
        {
            return;
        }
        InitialHeightTree(root.left);
        InitialHeightTree(root.right);
        AdjustHeight(root);
    }
    public static PrcNode MakeTree()
    {
        // PrcNode root = new PrcNode(1);
        // PrcNode n1 = new PrcNode(6);
        // PrcNode n2 = new PrcNode(5);
        // PrcNode n3 = new PrcNode(3);
        // PrcNode n4 = new PrcNode(4);
        // root.right = n1;
        // n1.left = n2;
        // n2.left = n3;
        // n3.right = n4;
        /////////////////////////////////////////////
        // PrcNode root = new PrcNode(7);
        // PrcNode n1 = new PrcNode(9);
        // PrcNode n2 = new PrcNode(8);
        // PrcNode n3 = new PrcNode(10);
        // PrcNode n4 = new PrcNode(3);
        // PrcNode n5 = new PrcNode(2);
        // PrcNode n6 = new PrcNode(5);
        // PrcNode n7 = new PrcNode(4);
        // PrcNode n8 = new PrcNode(6);
        // root.left = n4; root.right = n1;
        // n1.left = n2; n1.right = n3;
        // n4.left = n5; n4.right = n6;
        // n6.left = n7; n6.right = n8;
        /////////////////////////////////////////////
        // PrcNode root = new PrcNode(4);
        // PrcNode n1 = new PrcNode(5);
        // PrcNode n2 = new PrcNode(2);
        // PrcNode n3 = new PrcNode(1);
        // PrcNode n4 = new PrcNode(3);
        // root.right = n1; root.left = n2;
        // n2.left = n3; n2.right = n4;
        /////////////////////////////////////////////
        // PrcNode root = new PrcNode(3);
        // PrcNode n1 = new PrcNode(2);
        // PrcNode n2 = new PrcNode(5);
        // PrcNode n3 = new PrcNode(1);
        // PrcNode n4 = new PrcNode(4);
        // PrcNode n5 = new PrcNode(7);
        // PrcNode n6 = new PrcNode(6);
        // PrcNode n7 = new PrcNode(8);


        // PrcNode root_2 = new PrcNode(9);
        // PrcNode n1_2 = new PrcNode(11);
        // PrcNode n2_2 = new PrcNode(10);

        // root.left = n1; root.right = n2;
        // n1.left = n3;
        // n2.left = n4; n2.right = n5;
        // n5.left = n6;

        // n5.right = n7;
        // root_2.right = n1_2;
        // n1_2.left = n2_2;

        // return (root, root_2);
        ///////////////////////////////////
        // PrcNode root = new PrcNode(4);
        // PrcNode n1 = new PrcNode(1);
        // PrcNode n2 = new PrcNode(6);
        // PrcNode n3 = new PrcNode(3);
        // root.left = n1; root.right = n2;
        // n1.right = n3;
        ///////////////////////////////////
        PrcNode root = new PrcNode(2);
        PrcNode n1 = new PrcNode(1);
        PrcNode n2 = new PrcNode(4);
        PrcNode n3 = new PrcNode(3);
        PrcNode n4 = new PrcNode(6);
        root.left = n1; root.right = n2;
        n2.left = n3; n2.right = n4;
        return root;
    }
    public static void PrintElementInTree(PrcNode root)
    {
        Console.ForegroundColor = System.ConsoleColor.Green;
        if (root == null)
        {
            return;
        }
        PrintElementInTree(root.left);
        Console.Write(root.key + " ");
        PrintElementInTree(root.right);
    }
    public static void PrintTree(PrcNode root, int spacecount)
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
        Console.WriteLine(root.key);
        PrintTree(root.left, spacecount + 10);
    }
    public static void DeleteBase(int key, PrcNode root)
    {
        var n = Find(key, root);
        if (n.key == key)
        {
            if (n.right == null)
            {
                Replace(n, n.left);
            }
            else
            {
                var m = Next(n);
                Replace(n, m);
                Replace(m, m.right);
            }
        }
    }

    private static void Replace(PrcNode n, PrcNode m)
    {
        if (n.parent == null)
        {
            n.key = m.key;
        }
        else if (n.parent.right == n)
        {
            n.parent.right = m;
        }
        else
        {
            n.parent.left = m;
        }
    }

    public static void InsertBase(int key, PrcNode root)
    {
        var newNode = new PrcNode(key);
        var p = Find(key, root);
        if (p.key != key)
        {
            newNode.parent = p;
            if (p.key < newNode.key)
            {
                p.right = newNode;
            }
            else
            {
                p.left = newNode;
            }
        }
    }
    public static void RotateRight(PrcNode x, ref PrcNode root)
    {
        var P = x.parent;
        var Y = x.left;
        var B = Y.right;
        if (Y != null)
        {
            Y.parent = P;
            if (P != null)
            {
                if (x.key > P.key)
                {
                    P.right = Y;
                }
                else
                {
                    P.left = Y;
                }
                AdjustHeight(P);
            }
            x.parent = Y; Y.right = x;
            if (B != null)
            {
                B.parent = x;
                AdjustHeight(B);
            }
            x.left = B;
            AdjustHeight(x); AdjustHeight(Y);
            if (x == root)
            {
                root = Y;
            }
        }
    }
    public static void RotateLeft(PrcNode x, ref PrcNode root)
    {
        var P = x.parent;
        var Y = x.right;
        var B = Y.left;
        if (Y != null)
        {
            Y.parent = P;
            if (P != null)
            {
                if (x.key > P.key)
                {
                    P.right = Y;
                }
                else
                {
                    P.left = Y;
                }
                AdjustHeight(P);
            }
            x.parent = Y; Y.left = x;
            if (B != null)
            {
                B.parent = x;
                AdjustHeight(B);
            }
            x.right = B;
            AdjustHeight(x); AdjustHeight(Y);
            if (x == root)
            {
                root = Y;
            }
        }
    }
    public static void AVLInsert(int key, ref PrcNode root)
    {
        InsertBase(key, root);
        var N = Find(key, root);
        Rebalance(N, ref root);
    }
    public static void AVLDelete(int key, ref PrcNode root)
    {
        var x = Find(key, root);
        PrcNode M;
        if (x.right == null)
        {
            M = x.left;
        }
        else
        {
            M = Next(x);
        }
        DeleteBase(key, root);
        if (M != null)
        {
            M = M.parent;
            Rebalance(M, ref root);
        }
        else
        {
            Rebalance(x.parent, ref root);
        }

    }
    private static void Rebalance(PrcNode n, ref PrcNode root)
    {
        if (GetHeight(n.left) > GetHeight(n.right) + 1)
        {
            RebalanceRight(n, ref root);
        }
        if (GetHeight(n.right) > GetHeight(n.left) + 1)
        {
            RebalanceLeft(n, ref root);
        }
        AdjustHeight(n);
        if (n.parent != null)
        {
            Rebalance(n.parent, ref root);
        }

    }

    private static void RebalanceLeft(PrcNode n, ref PrcNode root)
    {
        var M = n.right;
        if (GetHeight(M.left) > GetHeight(M.right))
        {
            RotateRight(M, ref root);
        }
        RotateLeft(n, ref root);

    }

    private static void RebalanceRight(PrcNode n, ref PrcNode root)
    {
        var M = n.left;
        if (GetHeight(M.left) < GetHeight(M.right))
        {
            RotateLeft(M, ref root);
        }
        RotateRight(n, ref root);
    }
    public static (PrcNode, PrcNode) AVLTreeSplit(PrcNode root, int x)
    {
        if (root == null)
        {
            return (null, null);
        }
        else if (x <= root.key)
        {
            (PrcNode R1, PrcNode R2) = AVLTreeSplit(root.left, x);
            var R3 = MergeWithRoot(R2, root.right, root);
            return (R1, R3);
        }
        else
        {
            (PrcNode R1, PrcNode R2) = AVLTreeSplit(root.right, x);
            var R3 = MergeWithRoot(root.left, R1, root);
            return (R3, R2);
        }
    }
    public static PrcNode AVLTreeMerge(PrcNode R1, PrcNode R2)
    {
        if (Math.Abs(GetHeight(R1) - GetHeight(R2)) <= 1)
        {
            var T = MergeBase(R1, R2);
            AdjustHeight(T);
            return T;
        }
        else if (GetHeight(R1) > GetHeight(R2))
        {
            var rPrin = AVLTreeMerge(R1.right, R2);
            R1.right = rPrin;
            rPrin.parent = R1;
            Rebalance(R1, ref R1);
            return R1;
        }
        else
        {
            var rPrin = AVLTreeMerge(R1, R2.left);
            R2.left = rPrin;
            rPrin.parent = R2;
            Rebalance(R2, ref R2);
            return R2;
        }
    }
    public static PrcNode MergeBase(PrcNode R1, PrcNode R2)
    {
        var T = Find(int.MaxValue, R1);
        AVLDelete(T.key, ref R1);
        T = MergeWithRoot(R1, R2, T);
        return T;
    }
    public static PrcNode MergeWithRoot(PrcNode R1, PrcNode R2, PrcNode T)
    {
        T.left = R1;
        T.right = R2;
        R1.parent = T;
        R2.parent = T;
        return T;
    }
}


