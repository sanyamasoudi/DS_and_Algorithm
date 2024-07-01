using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class ConnectedComponents
{
    static bool[] visited;
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
            adjList[edges[1]].Add(edges[0]);
        }
        var result = ComputeNumberOfComponents(adjList);
        Console.WriteLine(result);
    }
    public static int ComputeNumberOfComponents(List<int>[] adjList)
    {
        int count = 0;
        visited = new bool[adjList.Length];
        for (var i = 1; i < adjList.Length; i++)
        {
            if (!visited[i])
            {
                Explore(i, adjList);
                count++;
            }
        }
        return count;
    }

    private static void Explore(int i, List<int>[] adjList)
    {
        visited[i] = true;
        foreach (var neighbor in adjList[i])
        {
            if (!visited[neighbor])
            {
                Explore(neighbor, adjList);
            }
        }
    }
}