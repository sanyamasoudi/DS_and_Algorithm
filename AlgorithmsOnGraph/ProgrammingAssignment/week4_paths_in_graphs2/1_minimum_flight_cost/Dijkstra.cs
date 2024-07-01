using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Dijkstra
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
        var UandV = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        int result = ShortestPath(adjList, VerticesAndEdges, UandV);
        Console.WriteLine(result);
    }
    public static int ShortestPath(List<int[]>[] adjList, int[] verticesAndEdges, int[] uandV)
    {
        int[] dist = new int[verticesAndEdges[0] + 1];
        int[] prev = new int[verticesAndEdges[0] + 1];
        Array.Fill(dist, int.MaxValue);

        PriorityQueue priorityQueue = new PriorityQueue();
        for (var i = 1; i <= verticesAndEdges[0]; i++)
        {
            if (i == uandV[0]) priorityQueue.Insert(uandV[0], 0);
            else priorityQueue.Insert(i, int.MaxValue);
        }
        while (priorityQueue.Count > 0)
        {
            var v = priorityQueue.ExtractMin();
            foreach (var neighbor in adjList[v.data])
            {
                int weight = neighbor[1];
                int u = neighbor[0];
                if (v.dist!=int.MaxValue && dist[u] > v.dist + weight)
                {
                    dist[u] = v.dist + weight;
                    prev[u] = v.data;
                    priorityQueue.ChangePriority(u, dist[u]);
                }
            }
        }
        return dist[uandV[1]] == int.MaxValue ? -1 : dist[uandV[1]];
    }
}
public class PriorityQueue
{
    List<Node> queue;
    public int Count { get => queue.Count; }
    public PriorityQueue()
    {
        queue = new List<Node>();
    }
    public void Insert(int data, int dist)
    {
        var newNode = new Node(data, dist);
        queue.Add(newNode);
        BubbleUp(queue.Count - 1);
    }
    public Node ExtractMin()
    {
        var min = queue[0];
        queue[0] = queue[queue.Count - 1];
        queue.RemoveAt(queue.Count - 1);
        BubbleDown(0);
        return min;
    }

    private void BubbleDown(int i)
    {
        int n = queue.Count;
        while (i < n)
        {
            int leftIdx = i * 2 + 1;
            int rightIdx = i * 2 + 2;
            int minIdx = i;
            if (leftIdx < n && queue[leftIdx].dist < queue[minIdx].dist)
            {
                minIdx = leftIdx;
            }
            if (rightIdx < n && queue[rightIdx].dist < queue[minIdx].dist)
            {
                minIdx = rightIdx;
            }
            if (minIdx == i)
            {
                break;
            }
            Swap(i, minIdx);
            i = minIdx;
        }
    }

    private void BubbleUp(int i)
    {
        while (i > 0)
        {
            int parentIdx = (i - 1) / 2;
            if (queue[parentIdx].dist < queue[i].dist)
            {
                break;
            }
            Swap(i, parentIdx);
            i = parentIdx;
        }
    }

    private void Swap(int i, int j)
    {
        var tmp = queue[i];
        queue[i] = queue[j];
        queue[j] = tmp;
    }

    public void ChangePriority(int dta, int newDist)
    {
        var idx = queue.FindIndex(e => e.data == dta);
        if (idx == -1) return;

        var lastDist = queue[idx].dist;
        queue[idx].dist = newDist;
        if (lastDist < newDist)
        {
            BubbleDown(idx);
        }
        else
        {
            BubbleUp(idx);
        }
    }
}

public class Node
{
    public int dist;
    public int data;
    public Node(int data, int dist)
    {
        this.dist = dist;
        this.data = data;
    }
}