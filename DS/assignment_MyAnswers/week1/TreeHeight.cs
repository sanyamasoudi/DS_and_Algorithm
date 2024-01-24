using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         long n = long.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
//         Tree.CreateTree(n, nums);
//         bool[] visited = new bool[n];

//         var result = Tree.TreeHeight(Tree.Root, visited);
//         Console.WriteLine(result);
//     }
// }
public static class Tree
{
    public static List<long>[] AllChildren;
    public static long Root;
    public static void CreateEmptyTree(long n)
    {
        AllChildren = new List<long>[n];
        for (var i = 0; i < n; i++)
        {
            AllChildren[i] = new List<long>();
        }
    }
    public static void AddEdge(long parent, long child)
    {
        AllChildren[parent].Add(child);
    }
    public static void CreateTree(long n, long[] nums)
    {
        CreateEmptyTree(n);
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != -1) AddEdge(nums[i], i);
            else Root = i;
        }
    }

    public static long TreeHeight(long x, bool[] visited)
    {

        Queue<long> queue = new Queue<long>();
        queue.Enqueue(x);
        long max = 0;

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            for (var l = 0; l < levelSize; l++)
            {
                var p = queue.Dequeue();
                visited[p] = true;

                foreach (var item in AllChildren[p])
                {
                    if (!visited[item])
                    {
                        queue.Enqueue(item);
                    }
                }
            }
            max++;
        }
        return max;
    }
    public static long TreeHeightVeryNaive(long x, bool[] visited)
    {
        visited[x] = true;
        long max = 0;
        if (AllChildren[x].Count == 0)
        {
            return 0;
        }
        foreach (var item in AllChildren[x])
        {
            if (!visited[item])
            {
                long height = 1 + TreeHeight(item, visited);
                max = Math.Max(height, max);
            }
        }
        return max;
    }
}