using System;
using System.Collections.Generic;

public class Graph
{
    private int V;
    private List<int>[] adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[V];
        for (int i = 0; i < V; ++i)
        {
            adj[i] = new List<int>();
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }
    private void DFSUtil(int v, bool[] visited, List<int> preorder, List<int> inorder, List<int> postorder)
    {
        visited[v] = true;
        preorder.Add(v);


        if (adj[v].Count != 0 && !visited[adj[v][0]] ) DFSUtil(adj[v][0], visited, preorder, inorder, postorder);
        inorder.Add(v);
        if (adj[v].Count != 0 && !visited[adj[v][1]] ) DFSUtil(adj[v][1], visited, preorder, inorder, postorder);

        foreach (int n in adj[v])
        {
            if (!visited[n])
            {

                DFSUtil(n, visited, preorder, inorder, postorder);
            }
        }
        postorder.Add(v);

    }
    private void DFSUtil2(int v, bool[] visited, List<int> preorder, List<int> inorder, List<int> postorder)
    {
        visited[v] = true;
        preorder.Add(v);
        adj[v].Reverse();
        foreach (int n in adj[v])
        {
            if (!visited[n])
            {
                DFSUtil2(n, visited, preorder, inorder, postorder);
                // inorder.Add(n); not defined
            }
        }
        postorder.Add(v);

    }

    public void DFS(int v)
    {
        bool[] visited = new bool[V];
        List<int> preorder = new List<int>();
        List<int> inorder = new List<int>();
        List<int> postorder = new List<int>();

        DFSUtil(v, visited, preorder, inorder, postorder);

        Console.WriteLine("Preorder: " + string.Join(", ", preorder));
        Console.WriteLine("Inorder: " + string.Join(", ", inorder));
        Console.WriteLine("Postorder: " + string.Join(", ", postorder));
    }

}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Graph g = new Graph(7);

//         g.AddEdge(0, 1);
//         g.AddEdge(0, 2);
//         g.AddEdge(1, 3);
//         g.AddEdge(1, 4);
//         g.AddEdge(2, 5);
//         g.AddEdge(2, 6);


//         Console.WriteLine("Following is Depth First Traversal " + "(starting from vertex 2)");

//         g.DFS(0);
//     }
// }

