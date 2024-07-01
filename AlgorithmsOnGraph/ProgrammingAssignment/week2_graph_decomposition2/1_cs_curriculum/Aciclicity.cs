using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Aciclicity
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
        }
        var result = DoesHaveCycle(adjList);
        Console.WriteLine(result);
    }
    public static int DoesHaveCycle(List<int>[] adjList)
    {
        for (var i = 1; i < adjList.Length; i++)
        {
            bool[] visited = new bool[adjList.Length];
            Explore(i, adjList, visited, i, out bool doesHaveCycle);
            if (doesHaveCycle) return 1;
        }
        return 0;
    }

    private static void Explore(int i, List<int>[] adjList, bool[] visited, int startValue, out bool doesHaveCycle)
    {
        visited[i]=true;
        doesHaveCycle = false;
        foreach (var neighbor in adjList[i])
        {
            if (neighbor == startValue)
            {
                doesHaveCycle = true;
                break;
            }
            else
            {
                if (!visited[neighbor])
                    Explore(neighbor, adjList,visited,startValue, out doesHaveCycle);
            }
        }
    }
}