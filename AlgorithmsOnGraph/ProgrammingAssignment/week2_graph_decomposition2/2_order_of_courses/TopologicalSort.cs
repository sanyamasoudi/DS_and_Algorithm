using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class TopologicalSort
{
    public static void Main(string[] args)
    {
        var VerticesAndEdges = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        List<int>[] adjList = new List<int>[VerticesAndEdges[0] + 1];
        for (var i = 0; i < adjList.Length; i++)
        {
            adjList[i] = new List<int>();
        }

        for (var i = 0; i < VerticesAndEdges[1]; i++)
        {
            var edges = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            adjList[edges[0]].Add(edges[1]);
        }
        var sortArr = TopoSort(adjList).Reverse().ToArray();
        Console.WriteLine(String.Join(" ", sortArr));
    }
    public static int[] TopoSort(List<int>[] adjList)
    {
        bool[] visited = new bool[adjList.Length];
        List<int> postOrders=new List<int>();
        for (var i = 1; i < adjList.Length; i++)
        {
            if (!visited[i]) Explore(i, adjList, visited, postOrders);
        }
        return postOrders.ToArray();
        
    }

    private static void Explore(int i, List<int>[] neighbors, bool[] visited, List<int> postOrders)
    {
        visited[i] = true;
        foreach (var neighbor in neighbors[i])
        {
            if (!visited[neighbor]) Explore(neighbor, neighbors, visited,postOrders);
        }
        postOrders.Add(i);
    }
}