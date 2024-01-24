using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class TreeTraversalBV
{
    static List<int> key = new List<int>();
    static List<int> left = new List<int>();
    static List<int> right = new List<int>();
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     for (var i = 0; i < n; i++)
    //     {
    //         var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //         key.Add(input[0]);
    //         left.Add(input[1]);
    //         right.Add(input[2]);
    //     }
    //     InOrder();
    //     PreOrder();
    //     PostOrder();
    // }
    private static void PostOrder()
    {
        List<int> postResult = new List<int>();
        Stack<int> stack = new Stack<int>();
        Dictionary<int,int> visited = new Dictionary<int,int>();
        stack.Push(0);
        visited.Add(0,0);
        while (stack.Count > 0)
        {
            var p = stack.Peek();
            if ((left[p] == -1 && right[p] == -1) ||
            (visited.ContainsKey(left[p]) && visited.ContainsKey(right[p]))
            || (visited.ContainsKey(left[p]) && right[p] == -1)
            || (left[p] == -1 && visited.ContainsKey(right[p])))
            {
                postResult.Add(key[p]);
                if (!visited.ContainsKey(p)) visited.Add(p,p);
                stack.Pop();
                if (stack.Count <= 0) break;
                p = stack.Peek();
            }
            if (!visited.ContainsKey(right[p]) && right[p] != -1)
            {
                stack.Push(right[p]);
                visited.Add(right[p],right[p]);
            }
            if (!visited.ContainsKey(left[p]) && left[p] != -1)
            {
                stack.Push(left[p]);
                visited.Add(left[p],left[p]);
            }
        }
        Console.WriteLine(String.Join(" ", postResult));
    }
    private static void PreOrder()
    {
        List<int> preResult = new List<int>();
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            var p = stack.Peek();
            if (p != -1)
            {
                preResult.Add(key[p]);
            }
            stack.Pop();
            if (right[p] != -1)
            {
                stack.Push(right[p]);
            }
            if (left[p] != -1)
            {
                stack.Push(left[p]);
            }
        }
        Console.WriteLine(String.Join(" ", preResult));
    }

    private static void InOrder()
    {
        List<int> InResult = new List<int>();
        Stack<int> stack = new Stack<int>();
        var curr = 0;
        while (true)
        {
            if (curr != -1)
            {
                stack.Push(curr);
                curr = left[curr];
            }
            else
            {
                if (stack.Count == 0)
                    break;
                curr = stack.Pop();
                InResult.Add(key[curr]);
                curr = right[curr];
            }
        }
        Console.WriteLine(String.Join(" ", InResult));
    }
}