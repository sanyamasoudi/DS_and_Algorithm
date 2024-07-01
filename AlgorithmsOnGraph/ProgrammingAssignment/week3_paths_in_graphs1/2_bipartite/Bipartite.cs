using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class Bipartite
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
        int result = Is_Bipartite(adjList);
        Console.WriteLine(result);
    }
    public static int Is_Bipartite(List<int>[] adjList)
    {
        string colorId = "black";
        string[] Color = new string[adjList.Length];
        bool[] visited = new bool[adjList.Length];

        Queue<int> queue = new Queue<int>();
        var started = FindStartedVertex(adjList);

        queue.Enqueue(started);
        visited[started] = true;
        Color[started] = colorId;

        while (queue.Count > 0)
        {
            int QC = queue.Count;
            colorId = ChangeColorId(colorId);
            for (int i = 0; i < QC; i++)
            {
                var dequeued = queue.Dequeue();

                foreach (var neighbor in adjList[dequeued])
                {
                    if (Color[neighbor] == Color[dequeued]) return 0;
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        Color[neighbor] = colorId;
                        visited[neighbor] = true;
                    }

                }
            }
        }
        return 1;
    }

    private static int FindStartedVertex(List<int>[] adjList)
    {
        int maxIndex = -1;
        int maxValue = int.MinValue;
        for (var i = 1; i < adjList.Length; i++)
        {
            if (maxValue < adjList[i].Count)
            {
                maxValue = adjList[i].Count;
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    private static string ChangeColorId(string colorId)
    {
        if (colorId == "black") return "white";
        else return "black";
    }
}