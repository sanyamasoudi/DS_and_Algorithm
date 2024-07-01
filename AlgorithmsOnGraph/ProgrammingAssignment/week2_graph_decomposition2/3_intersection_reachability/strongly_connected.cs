using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class Strongly_connected
{
    public static void Main(string[] args)
    {
        var VerticesAndEdges = Console.ReadLine().Split().Select(int.Parse).ToArray();

        List<int>[] adjList = new List<int>[VerticesAndEdges[0] + 1];
        InitialGraph(adjList);

        for (var i = 0; i < VerticesAndEdges[1]; i++)
        {
            var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
            adjList[edge[0]].Add(edge[1]);
        }
        var result = Compute_SCC(adjList);
        Console.WriteLine(result);
    }

    private static void InitialGraph(List<int>[] adjList)
    {
        for (var i = 0; i < adjList.Length; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public static int Compute_SCC(List<int>[] adjList)
    {
        int count = 0;
        var reversedGraph = ReverseGraph(adjList);
        var postOrderArr = ComputePostOrder(reversedGraph).ToArray().Reverse().ToArray();
        var visited = new bool[adjList.Length];
        foreach (var vertex in postOrderArr)
        {
            if (!visited[vertex])
            {
                Explore(vertex, adjList, visited, null, false);
                count++;
            }
        }
        return count;
    }

    private static List<int>[] ReverseGraph(List<int>[] adjList)
    {
        List<int>[] reverseGraph = new List<int>[adjList.Length];
        InitialGraph(reverseGraph);

        for (var i = 1; i < adjList.Length; i++)
        {
            for (var j = 0; j < adjList[i].Count; j++)
            {
                reverseGraph[adjList[i][j]].Add(i);
            }
        }
        return reverseGraph;
    }

    private static List<int> ComputePostOrder(List<int>[] adjList)
    {
        var visited = new bool[adjList.Length];
        var postOrderList = new List<int>();
        for (var i = 1; i < adjList.Length; i++)
        {
            if (!visited[i])
            {
                Explore(i, adjList, visited, postOrderList, true);
            }
        }
        return postOrderList;
    }

    private static void Explore(int i, List<int>[] adjList, bool[] visited, List<int> postOrderList, bool postOrderLicense)
    {
        visited[i] = true;
        foreach (var neighbor in adjList[i])
        {
            if (!visited[neighbor])
            {
                Explore(neighbor, adjList, visited, postOrderList, postOrderLicense);
            }
        }
        if (postOrderLicense == true) postOrderList.Add(i);
    }
}