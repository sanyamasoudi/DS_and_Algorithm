using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class NegativeCycle
{
    public static void Main(string[] args)
    {
        var VerticesAndEdges = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        List<int[]>[] adjList = new List<int[]>[VerticesAndEdges[0] + 1];
        for (var i = 0; i < adjList.Length; i++)
        {
            adjList[i] = new List<int[]>();
        }

        for (var i = 0; i < VerticesAndEdges[1]; i++)
        {
            var EdgeWithWeight = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            adjList[EdgeWithWeight[0]].Add(new int[] { EdgeWithWeight[1], EdgeWithWeight[2] });
        }
        var result = HaveNagativeCycle(adjList, VerticesAndEdges);
        Console.WriteLine(result);

    }
    public static int HaveNagativeCycle(List<int[]>[] adjList, int[] verticesAndEdges)
    {
        for (var i = 1; i < verticesAndEdges[0] + 1; i++)
        {
            var status = BellManFord(i, adjList, verticesAndEdges);
            if (status == 1) return 1;
            else continue;
        }
        return 0;
    }

    private static int BellManFord(int start, List<int[]>[] adjList, int[] verticesAndEdges)
    {
        int[] dist = new int[verticesAndEdges[0] + 1];
        int[] prev = new int[verticesAndEdges[0] + 1];
        Array.Fill(dist, int.MaxValue);
        dist[start] = 0;
        for (var i = 1; i < verticesAndEdges[0] + 1; i++)
        {
            foreach (var neighbor in adjList[i])
            {
                var status = Relax(start, i, neighbor, dist, prev);
                if (status == 1) return 1;
                else continue;
            }
        }
        return 0;
    }

    private static int Relax(int start, int i, int[] neighbor, int[] dist, int[] prev)
    {
        int j = neighbor[0];
        int weight = neighbor[1];
        if (dist[i]!=int.MaxValue && dist[j] > dist[i] + weight)
        {
            if (j == start) return 1;
            dist[j] = dist[i] + weight;
            prev[j] = i;
        }
        return 0;
    }
}