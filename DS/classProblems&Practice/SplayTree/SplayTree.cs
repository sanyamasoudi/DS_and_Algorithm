public class SplayTree
{
    static SplayNode root;
    public static void Main(string[] args)
    {
        SplayTree tree = new SplayTree();
        root = new SplayNode(5);
        SplayNode n1 = new SplayNode(1);
        SplayNode n2 = new SplayNode(2);
        SplayNode n3 = new SplayNode(3);
        SplayNode n4 = new SplayNode(4);
        root.left = n1; n1.right = n2; n2.right = n3; n3.right = n4;
        // root = tree.Splay(root, 4);
        // root = tree.ZagZag(n4);
        // root = tree.ZigZag(n4);
        root = tree.Spllay(n4);
        tree.PrintTree(root, 5);
    }
    public SplayNode STMerge(SplayNode R1,SplayNode R2)
    {
        var N=Find(int.MaxValue,R1);
        Spllay(N);
        N.right=R2;
        return N;
    }
    public (SplayNode left, SplayNode right) STSplit(int x,SplayNode root)
    {
        var N=Find(x,root);
        Spllay(N);
        return (N.left,N.right);
    }
    public void STDelete(int key, SplayNode root)
    {
        var dNode = Find(key, root);
        Spllay(Next(dNode));
        Spllay(dNode);
        Delete(dNode);
    }

    private void Delete(SplayNode dNode)
    {
        if (dNode.right == null)
        {
            Replace(dNode, dNode.left);
        }
        else
        {
            var p = Next(dNode);
            Replace(dNode, p);
            Replace(p, p.right);
        }
    }

    private void Replace(SplayNode x, SplayNode y)
    {
        if (x.parent == null)
        {
            x.data = y.data;
        }
        else if (x.parent.right == x)
        {
            x.parent.right = y;
        }
        else
        {
            x.parent.left = y;
        }
    }

    public SplayNode STFind(int key, SplayNode root)
    {
        var N = Find(key, root);
        Spllay(N);
        return N;
    }
    public void STInsert(int key, SplayNode root)
    {
        Insert(key, root);
        var N = Find(key, root);
        Spllay(N);
    }

    private void Insert(int key, SplayNode root)
    {
        var p = Find(key, root);
        var newNode = new SplayNode(key);
        if (p.data < newNode.data)
        {
            p.right = newNode;
        }
        else
        {
            p.left = newNode;
        }
    }
    public SplayNode Next(SplayNode n)
    {
        if (n.right != null)
        {
            return LeftDescendent(n.right);
        }
        else
        {
            return RightAnscestor(n);
        }
    }

    private SplayNode RightAnscestor(SplayNode n)
    {
        while (n != null)
        {
            if (n.parent.data > n.data)
            {
                return n;
            }
            n = n.parent;
        }
        return null;
    }

    private SplayNode LeftDescendent(SplayNode n)
    {
        while (n.left != null)
        {
            n = n.left;
        }
        return n;
    }

    private SplayNode Find(int key, SplayNode root)
    {
        while (root != null)
        {
            if (root.data == key)
            {
                return root;
            }
            else if (root.data < key)
            {
                if (root.right != null)
                {
                    root = root.right;
                }
                else
                {
                    return root;
                }
            }
            else
            {
                if (root.left != null)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }
        }
        return null;
    }

    public SplayNode Spllay(SplayNode x)
    {
        if (x.parent == null)
        {
            return x;
        }
        ProperCase(x);
        if (x != null)
        {
            Spllay(x);
        }
        return x;
    }

    private SplayNode ProperCase(SplayNode x)
    {
        if (x.parent != null && x.parent.parent != null)
        {
            if (x.parent.data < x.data)
            {
                if (x.parent.parent.data > x.parent.data)
                {
                    return ZagZig(x);
                }
                else
                {
                    return ZagZag(x);
                }
            }
            else
            {
                if (x.parent.parent.data < x.parent.data)
                {
                    return ZigZag(x);
                }
                else
                {
                    return ZigZig(x);
                }
            }
        }
        else if (x.parent != null && x.parent.parent == null)
        {
            if (x.parent.data < x.data)
            {
                return Zag(x);
            }
            else
            {
                return Zig(x);
            }
        }
        else
        {
            return root;
        }
    }
    public SplayNode ZigZag(SplayNode x)
    {
        Zig(x.parent);
        var result = Zag(x.parent);
        return result;
    }
    public SplayNode ZagZig(SplayNode x)
    {
        Zag(x.parent);
        var result = Zig(x.parent);
        return result;
    }
    public SplayNode ZigZig(SplayNode x)
    {
        Zig(x.parent.parent);
        var result = Zig(x.parent);
        return result;
    }
    public SplayNode ZagZag(SplayNode x)
    {
        Zag(x.parent.parent);
        var result = Zag(x.parent);
        return result;
    }
    public SplayNode Zig(SplayNode x)
    {
        var P = x.parent;
        var Y = x.left;
        if (Y != null)
        {
            var B = Y.right;
            Y.parent = P;
            if (P != null)
            {
                if (x.data > P.data)
                {
                    P.right = Y;
                }
                else
                {
                    P.left = Y;
                }
            }
            x.parent = Y;
            Y.right = x;
            if (B != null) B.parent = x;
            x.left = B;
            return Y;
        }
        return null;
    }
    public SplayNode Zag(SplayNode x)
    {
        var P = x.parent;
        var Y = x.right;
        if (Y != null)
        {
            var B = Y.left;
            Y.parent = P;
            if (P != null)
            {
                if (x.data > P.data)
                {
                    P.right = Y;
                }
                else
                {
                    P.left = Y;
                }
            }
            x.parent = Y;
            Y.left = x;
            if (B != null) B.parent = x;
            x.right = B;
            return Y;
        }
        return null;
    }
    public SplayNode ZigRightRotate(SplayNode x)
    {
        var Y = x.left;
        x.left = Y.right;
        Y.right = x;
        return Y;
    }
    public SplayNode ZigLeftRotate(SplayNode x)
    {
        var Y = x.right;
        x.right = Y.left;
        Y.left = x;
        return Y;
    }
    public SplayNode Splay(SplayNode root, int key)
    {
        if (root == null || root.data == key) return root;
        if (root.data > key)
        {
            if (root.left == null)
            {
                return root;
            }
            if (root.left.data > key)
            {
                root.left.left = Splay(root.left.left, key);
                root = ZigRightRotate(root);
            }
            else if (root.left.data < key)
            {
                root.left.right = Splay(root.left.right, key);
                if (root.left.right != null)
                {
                    root.left = ZigLeftRotate(root.left);
                }
            }
            return (root.left == null) ? root : ZigRightRotate(root);
        }
        else
        {
            if (root.right == null)
            {
                return root;
            }

            if (root.right.data > key)
            {
                root.right.left = Splay(root.right.left, key);
                if (root.right.left != null)
                {
                    root.right = ZigRightRotate(root.right);
                }
            }
            else if (root.right.data < key)
            {
                root.right.right = Splay(root.right.right, key);
                root = ZigLeftRotate(root);
            }
            return (root.right == null) ? root : ZigLeftRotate(root);
        }
    }

    public void PrintTree(SplayNode root, int space)
    {
        if (root == null) return;
        PrintTree(root.right, space + 10);
        for (var i = 0; i < space; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(root.data);
        PrintTree(root.left, space + 10);
    }
}
public class SplayNode
{
    public int data;
    SplayNode _left;
    public SplayNode left
    {
        get => _left;
        set
        {
            _left = value;
            if (value != null) value.parent = this;
        }
    }
    SplayNode _right;
    public SplayNode right
    {
        get => _right;
        set
        {
            _right = value;
            if (value != null) value.parent = this;
        }
    }
    public SplayNode parent;
    public SplayNode(int v)
    {
        this.data = v;
        this.right = this.left = null;
    }
}