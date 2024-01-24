public class Bst_Application
{
    static Node root;
    // public static void Main(string[] args)
    // {
    //     Bst_Application bst = new Bst_Application();
    //     root = bst.MakeTree2(new string[] { "7", "2", "8", "1", "4", "N", "9", "N", "N", "3", "6", "N", "N", "N", "N", "5", "N" });
    //     bst.InitialHeightTree(root);
    //     bst.InitialSizeTree(root);
    //     // var f = bst.Find(4, root);
    //     // bst.Rebalance(f);
    //     // Console.WriteLine($"height:{f.height},size:{f.size}");
    //     // var x=bst.OrderStatistic(root,3);
    //     bst.PrintTree(root, 5);
    // }
    public Node OrderStatistic(Node root, int k)
    {
        var s = GetSize(root.left);
        if (k == s + 1)
        {
            return root;
        }
        else if (k < s + 1)
        {
            return OrderStatistic(root.left,k);
        }
        else
        {
            return OrderStatistic(root.right,k-s-1);
        }
    }
    public void Rebalance(Node x)
    {
        if (x == null) return;
        if (GetHeight(x.right) > GetHeight(x.left) + 1)
        {
            RebalanceLeft(x);
        }
        else if (GetHeight(x.right) + 1 < GetHeight(x.left))
        {
            RebalanceRight(x);
        }
        if (x.parent != null)
        {
            Rebalance(x.parent);
        }
    }

    private void RebalanceLeft(Node x)
    {
        var M = x.right;
        if (GetHeight(M.left) > GetHeight(M.right))
        {
            RotateRight(M);
        }
        RotateLeft(x);
    }

    private void RebalanceRight(Node x)
    {
        var M = x.left;
        if (GetHeight(M.left) < GetHeight(M.right))
        {
            RotateLeft(M);
        }
        RotateRight(x);
    }

    public void RotateLeft(Node x)
    {
        var P = x.parent;
        var Y = x.right;
        var B = Y.left;
        if (Y != null)
        {
            Y.parent = P;
            if (P != null)
            {
                if (x.value > P.value)
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
            x.right = B;
            AdjustHeight(Y); AdjustHeight(x);
            if (B != null)
            {
                B.parent = x;
                AdjustHeight(B);
            }
        }
        if (x == root)
        {
            root = Y;
        }
        ReComputeSize(x); ReComputeSize(Y);
    }
    public void RotateRight(Node x)
    {
        var P = x.parent;
        var Y = x.left;
        var B = Y.right;
        if (Y != null)
        {
            Y.parent = P;
            if (P != null)
            {
                if (x.value > P.value)
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
            x.left = B;
            AdjustHeight(Y); AdjustHeight(x);
            if (B != null)
            {
                B.parent = x;
                AdjustHeight(B);
            }
        }
        if (x == root)
        {
            root = Y;
        }
        ReComputeSize(x); ReComputeSize(Y);
    }
    public Node Find(int key, Node root)
    {
        var tmp = root;
        while (tmp != null)
        {
            if (key == tmp.value)
            {
                return tmp;
            }
            else if (key > tmp.value)
            {
                tmp = tmp.right;
            }
            else
            {
                tmp = tmp.left;
            }
        }
        return null;
    }
    private void InitialSizeTree(Node root)
    {
        if (root == null)
        {
            return;
        }
        InitialSizeTree(root.left);
        InitialSizeTree(root.right);
        ReComputeSize(root);
    }

    private void InitialHeightTree(Node root)
    {
        if (root == null)
        {
            return;
        }
        InitialHeightTree(root.left);
        InitialHeightTree(root.right);
        AdjustHeight(root);
    }

    private void PrintTree(Node root, int space)
    {
        if (root == null)
        {
            return;
        }
        PrintTree(root.right, space + 10);
        for (var i = 0; i < space; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(root.value);
        PrintTree(root.left, space + 10);
    }

    public Node MakeTree2(string[] arr)
    {
        Queue<Node> que = new Queue<Node>();
        Node root = new Node(int.Parse(arr[0]));
        que.Enqueue(root);
        int i = 0;
        while (que.Count > 0 && i < arr.Length)
        {
            var p = que.Peek();
            que.Dequeue();
            i++;
            if (i < arr.Length && arr[i] != "N")
            {
                Node left = new Node(int.Parse(arr[i]));
                left.parent = p;
                p.left = left;
                que.Enqueue(left);
            }
            i++;
            if (i < arr.Length && arr[i] != "N")
            {
                Node right = new Node(int.Parse(arr[i]));
                right.parent = p;
                p.right = right;
                que.Enqueue(right);
            }
        }
        return root;
    }
    public Node MakeTree()
    {
        Node root = new Node(9);
        Node n1 = new Node(6);
        Node n2 = new Node(2);
        Node n3 = new Node(1);
        Node n4 = new Node(4);
        Node n5 = new Node(1);
        Node n6 = new Node(1);
        Node n7 = new Node(2);
        Node n8 = new Node(1);
        root.left = n1; root.right = n2;
        n1.left = n3; n1.right = n4;
        n2.right = n5;
        n4.left = n6; n4.right = n7;
        n7.left = n8;
        return root;
    }
    public void ReComputeSize(Node n)
    {
        if (n == null) return;
        n.size = 1 + GetSize(n.right) + GetSize(n.left);
    }

    private int GetSize(Node n)
    {
        if (n == null)
        {
            return 0;
        }
        return n.size;
    }

    public void AdjustHeight(Node n)
    {
        if (n == null) return;
        n.height = 1 + Math.Max(GetHeight(n.right), GetHeight(n.left));
    }

    private int GetHeight(Node n)
    {
        if (n == null)
        {
            return 0;
        }
        return n.height;
    }
}
public class Node
{
    public Node(int v)
    {
        this.value = v;
        this.parent = null;
        this.right = null;
        this.left = null;
        this.size = 0;
        this.height = 0;
    }
    public int value;
    public Node parent;
    private Node _right;
    public Node right
    {
        get => _right;
        set
        {
            _right = value;
            if (value != null) value.parent = this;
        }
    }
    private Node _left;
    public Node left
    {
        get => _left;
        set
        {
            _left = value;
            if (value != null) value.parent = this;
        }
    }
    public int height;
    public int size;
}