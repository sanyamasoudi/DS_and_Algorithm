public class NodeTree
{
    public int Key;
    public NodeTree left;
    public NodeTree right;
}
public class NodeTree2
{
    public int Key;
    public NodeTree2 prev;
    public NodeTree2 left;
    public NodeTree2 right;
}
public class BinaryTree
{
    public NodeTree MakeNode(int k)
    {
        NodeTree newNode = new NodeTree()
        {
            Key = k,
            left = null,
            right = null
        };
        return newNode;
    }
    static int makeIndex = 1;
    private readonly int Count = 10;

    public NodeTree CreateTree(NodeTree n, int height)
    {
        var right = MakeNode(makeIndex);
        makeIndex++;
        var left = MakeNode(makeIndex);
        makeIndex++;

        n.left = left;
        n.right = right;
        height--;
        if (height > 0)
        {
            CreateTree(left, height);
            CreateTree(right, height);
        }

        return n;
    }
    public void PrintTree(NodeTree n, int space)
    {
        if (n == null)
        {
            return;
        }
        PrintTree(n.left, space+Count);

        for (var i = 0; i < space; i++)
        {
            Console.Write(" ");
        }
        Console.Write(n.Key + "\n");
        PrintTree(n.right, space+Count);

    }
    public void InOrderTraversal(NodeTree n)
    {
        if (n == null)
        {
            return;
        }
        InOrderTraversal(n.left);
        Console.WriteLine(n.Key);
        InOrderTraversal(n.right);
    }
    public void PreOrderTraversal(NodeTree n)
    {
        if (n == null)
        {
            return;
        }
        Console.WriteLine(n.Key);
        PreOrderTraversal(n.left);
        PreOrderTraversal(n.right);
    }
    public void PostOrderTraversal(NodeTree n)
    {
        if (n == null)
        {
            return;
        }
        PostOrderTraversal(n.left);
        PostOrderTraversal(n.right);
        Console.WriteLine(n.Key);
    }
    public void LevelTraversalBFS(NodeTree n)
    {
        if (n == null)
        {
            return;
        }
        Queue<NodeTree> queue = new Queue<NodeTree>();
        queue.Enqueue(n);
        while (queue.Count != 0)
        {
            var q = queue.Dequeue();
            Console.Write(q.Key+" ");
            if (q.left != null)
            {
                queue.Enqueue(q.left);
            }
            if (q.right != null)
            {
                queue.Enqueue(q.right);
            }
        }
    }
    // public NodeTree2 FindRootDP(NodeTree2 node)
    // {
    //     var p=node;
    //     while(p!=null)
    //     {
    //         p=p.prev;
    //         if(p.prev==null)
    //         {
    //             return p;
    //         }
    //     }
    //     return null;
    // }
    // public NodeTree2 FindRootNaive(NodeTree2 node)
    // {
    //     if(node.prev==null)
    //     {
    //         return node;
    //     }
    //     return FindRootNaive(node.prev);
    // }
    void PerformToAll(NodeTree root)
    {
        if (root != null)
        {
            Perform(root);
            PerformToAll(root.left);
            PerformToAll(root.right);
        }
    }
    private void Perform(NodeTree root)
    {
        root.Key += 2;
    }

    public int GetHeightNaive(NodeTree root)
    {
        if (root == null)
        {
            return 0;
        }
        return 1 + Math.Max(GetHeightNaive(root.left), GetHeightNaive(root.right));
    }

    public int GetSizeNaive(NodeTree root)
    {
        if (root == null)
        {
            return 0;
        }
        return 1 + GetSizeNaive(root.left) + GetSizeNaive(root.right);
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         BinaryTree bt = new BinaryTree();
//         var root = bt.MakeNode(0);
//         int h = 3;
//         var tree = bt.CreateTree(root, h - 1);
//         // bt.PrintTree(tree, 0);
//         // bt.InOrderTraversal(tree);
//         // bt.PreOrderTraversal(tree);
//         // bt.PostOrderTraversal(tree);
//         // bt.LevelTraversalBFS(tree);
//         bt.PrintTree(root,10);
//     }
// }