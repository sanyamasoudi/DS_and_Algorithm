using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
public static class Maze
{
    public static void Main(string[] args)
    {
        var VerticesAndEdges = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        List<int>[] adjList = new List<int>[VerticesAndEdges[0] + 1];
        for (var i = 0; i < adjList.Length; i++)
        {
            adjList[i]=new List<int>();
        }

        for (var i = 0; i < VerticesAndEdges[1]; i++)
        {
            var edge = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        var UandV = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var result = IsFindExit(UandV[0], UandV[1], adjList);
        Console.WriteLine(result);
    }
    public static int IsFindExit(int u, int v, List<int>[] adjList)
    {
        bool[] visited = new bool[adjList.Length];
        Explore(u, adjList, visited);
        if (visited[v]) return 1;
        else return 0;
    }

    private static void Explore(int u, List<int>[] adjList, bool[] visited)
    {
        visited[u] = true;
        foreach (var neighbor in adjList[u])
        {
            if (!visited[neighbor])
                Explore(neighbor, adjList, visited);
        }
    }
}