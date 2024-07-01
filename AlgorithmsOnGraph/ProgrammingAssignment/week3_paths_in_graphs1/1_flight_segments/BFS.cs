using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class BFS
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
            var edge = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        var A_And_B = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var result = FlightSegment(adjList, A_And_B);
        Console.WriteLine(result);
    }
    public static int FlightSegment(List<int>[] adjList, int[] A_And_B)
    {
        int[] dist = new int[adjList.Length];
        Array.Fill(dist, int.MaxValue);
        BFS_Explore(adjList, A_And_B[0], dist);
        return (dist[A_And_B[1]] == int.MaxValue) ? -1 : dist[A_And_B[1]];
    }

    private static void BFS_Explore(List<int>[] adjList, int A, int[] dist)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(A);
        dist[A] = 0;
        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            foreach (var neighbor in adjList[vertex])
            {
                if (dist[neighbor] == int.MaxValue)
                {
                    queue.Enqueue(neighbor);
                    dist[neighbor] = dist[vertex] + 1;
                }
            }
        }
    }
}