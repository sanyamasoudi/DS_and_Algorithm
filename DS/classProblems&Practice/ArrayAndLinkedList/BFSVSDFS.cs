// public class Program
// {
//     public static void Main(string[] args)
//     {
//         BFSVSDFS graph = new BFSVSDFS(6);
//         graph.createGraph();
//         graph.addEdge(0, 1); graph.addEdge(0, 2);
//         graph.addEdge(1, 3);
//         graph.addEdge(2, 4); graph.addEdge(2, 5);
//         // graph.DFSWithQueue(0);
//         graph.DFSWithStack(0);
//         // graph.DFSWithRecursion(0);
//     }
// }
public class BFSVSDFS
{
    public int V { get; private set; }
    public List<int>[] adj { get; private set; }
    public BFSVSDFS(int n)
    {
        V = n;
        adj = new List<int>[n];
    }
    public void createGraph()
    {
        for (var i = 0; i < V; i++)
        {
            adj[i] = new List<int>();
        }
    }
    public void addEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    public void DFSWithStack(int start)
    {
        bool[] visited = new bool[V];
        Stack<int> stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            int current = stack.Pop();
            Console.Write(current + " ");
            visited[current] = true;
            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    stack.Push(neighbor);
                }
            }
        }
    }





    public void DFSWithRecursion(int start)
    {
        bool[] visited = new bool[V];
        DFSTraverse(start, visited);
    }

    private void DFSTraverse(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int neighbor in adj[v])
        {
            if (!visited[neighbor])
            {
                DFSTraverse(neighbor, visited);
            }
        }
    }

    public void BFSWithQueue(int start)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            start = queue.Dequeue();
            Console.Write(start + " ");

            foreach (int neighbor in adj[start])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

}