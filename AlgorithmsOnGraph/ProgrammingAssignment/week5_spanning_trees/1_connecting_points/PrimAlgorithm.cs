using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class PrimAlgorithm
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Vertex[] vertices = new Vertex[n];
        for (var i = 0; i < n; i++)
        {
            var vertex = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            vertices[i] = new Vertex(vertex[0], vertex[1], int.MaxValue);
        }
        double result = MinDistance(vertices, n);
        string formattedNumber = result.ToString("0.000000000");
        Console.WriteLine(formattedNumber);
    }

    private static double MinDistance(Vertex[] vertices, int n)
    {
        vertices[0].cost = 0;
        PriorityQueue pq = new PriorityQueue(vertices);
        while (pq.Queue.Count > 0)
        {
            var v = pq.ExtractMin();
            foreach (var item in vertices)
            {
                if (!Equal(item,v))
                {
                    if (pq.IsMemberOfPriorityQueue(item) && item.cost > Walk(v, item))
                    {
                        item.cost = Walk(v, item);
                        pq.ChangePriority(item, item.cost);
                    }
                }
            }
        }
        double sum = 0;
        foreach (var item in vertices)
        {
            sum += item.cost;
        }
        return sum;
    }

    private static bool Equal(Vertex item, Vertex v)
    {
        if(item.x==v.x && item.y==v.y) return true;
        else return false;
    }

    private static double Walk(Vertex v, Vertex item)
    {
        return Math.Sqrt(Math.Pow(v.x - item.x, 2) + Math.Pow(v.y - item.y, 2));
    }
}
public class PriorityQueue
{
    public List<Vertex> Queue;

    public PriorityQueue()
    {
        Queue = new List<Vertex>();
    }

    public PriorityQueue(Vertex[] vertices)
    {
        Queue = new List<Vertex>();
        foreach (var vertex in vertices)
        {
            Insert(vertex);
        }
    }
    public void Insert(Vertex vertex)
    {
        Queue.Add(vertex);
        BubbleUp(Queue.Count - 1);
    }
    public void Insert(int x, int y, double cost)
    {
        Vertex vertex = new Vertex(x, y, cost);
        Queue.Add(vertex);
        BubbleUp(Queue.Count - 1);
    }
    public bool IsMemberOfPriorityQueue(Vertex vertex)
    {
        foreach (var item in Queue)
        {
            if (item.x == vertex.x && item.y == vertex.y)
            {
                return true;
            }
        }
        return false;
    }
    public Vertex ExtractMin()
    {
        var min = Queue[0];
        Queue[0] = Queue[Queue.Count - 1];
        Queue.RemoveAt(Queue.Count - 1);
        BubbleDown(0);
        return min;
    }
    public void ChangePriority(Vertex vertex, double newCost)
    {
        var idx = Queue.FindIndex(e => e == vertex);
        if (idx == -1) return;

        var lastCost = Queue[idx].cost;
        Queue[idx].cost = newCost;
        if (lastCost < newCost)
        {
            BubbleDown(idx);
        }
        else
        {
            BubbleUp(idx);
        }
    }
    private void BubbleDown(int i)
    {
        int n = Queue.Count;
        while (i < n)
        {
            int leftIdx = i * 2 + 1;
            int rightIdx = i * 2 + 2;
            int minIdx = i;
            if (leftIdx < n && Queue[leftIdx].cost < Queue[minIdx].cost)
            {
                minIdx = leftIdx;
            }
            if (rightIdx < n && Queue[rightIdx].cost < Queue[minIdx].cost)
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
            if (Queue[parentIdx].cost < Queue[i].cost)
            {
                break;
            }
            Swap(i, parentIdx);
            i = parentIdx;
        }
    }

    private void Swap(int i, int j)
    {
        var tmp = Queue[i];
        Queue[i] = Queue[j];
        Queue[j] = tmp;
    }
}
public class Vertex
{
    public int x, y;
    public double cost;

    public Vertex(int x, int y, double cost)
    {
        this.x = x;
        this.y = y;
        this.cost = cost;
    }
    public Vertex(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}