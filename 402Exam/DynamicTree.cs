using System;
using System.Text;

internal class Program
{
    class Node
    {
        public int value;
        public Node Left;
        public Node Right;
        public Node() { }
    }
    static Node[] read_tree()
    {
        int n = int.Parse(Console.ReadLine());
        Node[] nodes = new Node[n];
        for (int i = 0; i < nodes.Length; i++)
            nodes[i] = new Node();
        for (int i = 0; i < n; i++)
        {
            var buffer = Console.ReadLine().Split().Select(int.Parse).ToList();
            int value = buffer[0];
            int leftChild = buffer[1];
            int rightChild = buffer[2];
            nodes[i].value = value;
            nodes[i].Left = leftChild > 0 ? nodes[leftChild] : null;
            nodes[i].Right = rightChild > 0 ? nodes[rightChild] : null;
        }
        return nodes;
    }

    // static void Main(string[] args)
    // {
    //     Node[] tree = read_tree();
    //     proccess(tree[0]);
    //     int queryCount = int.Parse(Console.ReadLine());
    //     StringBuilder stringBuilder = new StringBuilder();
    //     while (queryCount != 0)
    //     {
    //         int index = int.Parse(Console.ReadLine());
    //         stringBuilder.AppendLine(query(tree[index]).ToString());
    //         queryCount--;
    //     }
    //     Console.WriteLine(stringBuilder.ToString());
    // }

    // ===============================DO NOT CHANGE ABOVE============================
    // ==============================YOUR CODE BEGINS HERE===========================
    static Node last = null;
    static Node first = null;
    static void proccess(Node root)
    {
        InOrder(root);
        if (first != null) first.Left = last;
        if (last != null) last.Right = first;
    }

    private static void InOrder(Node root)
    {
        if (root == null)
        {
            return;
        }
        InOrder(root.Left);
        if (first == null) first = root;
        root.Left = last;
        if (last != null) last.Right = root;
        last = root;
        InOrder(root.Right);
    }

    static int query(Node node)
    {
        if (node == null) return 0;
        return node.Left.value + node.value + node.Right.value;
    }

}
