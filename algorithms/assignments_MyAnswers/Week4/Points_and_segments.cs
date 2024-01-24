using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
public static class Points_and_segments
{
    public static int[] CountSegments(Node[] allNodes, int n)
    {
        Array.Sort(allNodes, AllNodesComparer);
        int count = 0;
        var result = new int[n];
        for (var i = 0; i < allNodes.Length; i++)
        {
            if (allNodes[i].Type == "s") count++;
            else if (allNodes[i].Type == "e") count--;
            else
            {
                result[allNodes[i].Index] = count;
            }
        }
        return result;
    }

    private static int AllNodesComparer(Node x, Node y)
    {
        int compareX = x .X.CompareTo(y.X);
        if (compareX == 0)
        {
            if (x.Type == "s" && y.Type != "s")
            {
                return -1;
            }
            if (x.Type != "s" && y.Type == "s")
            {
                return 1;
            }
            if (x.Type == "e" && y.Type != "e")
            {
                return 1;
            }
            if (x.Type != "e" && y.Type == "e")
            {
                return -1;
            }
        }
        return compareX;
    }
}
public class Node
{
    public string Type;
    public int X;
    public int Index;
    public Node(string type, int x, int index)
    {
        this.Type = type;
        this.X = x;
        this.Index = index;
    }
    public Node(string type, int x)
    {
        this.Type = type;
        this.X = x;
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         int s = firstLine[0];
//         int p = firstLine[1];
//         List<Node> AllNodes = new List<Node>();
//         for (var i = 0; i < s; i++)
//         {
//             var segments = Console.ReadLine().Split().Select(int.Parse).ToList();
//             AllNodes.Add(new Node("s", segments[0]));
//             AllNodes.Add(new Node("e", segments[1]));
//         }
//         var points = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         for (var i = 0; i < points.Length; i++)
//         {
//             AllNodes.Add(new Node("p", points[i], i));
//         }
//         var result = Points_and_segments.CountSegments(AllNodes.ToArray(), points.Length);
//         Console.WriteLine(String.Join(" ", result));
//     }
// }