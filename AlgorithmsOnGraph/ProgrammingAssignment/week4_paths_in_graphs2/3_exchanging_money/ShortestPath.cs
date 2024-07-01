public class ShortestPath
{
    static string[] result;
    static List<int> NotReachable;
    static List<int> Infinitie;
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
        int s = int.Parse(Console.ReadLine());
        result = new string[VerticesAndEdges[0]];
        NotReachable = new List<int>();
        Infinitie=new List<int>();
        Array.Fill(result,"empty");
        ComputeShortestPath(s, adjList, VerticesAndEdges);
        Console.WriteLine(String.Join("\n", result));
    }

    private static void ComputeShortestPath(int s, List<int[]>[] adjList, int[] verticesAndEdges)
    {
        BFS(s, adjList, verticesAndEdges);
        NegativeCycle(adjList, verticesAndEdges);
    }

    private static void NegativeCycle(List<int[]>[] adjList, int[] verticesAndEdges)
    {
        for (var i = 1; i < verticesAndEdges[0] + 1; i++)
        {
            if (!NotReachable.Contains(i))
                BellManFord(i, adjList, verticesAndEdges);
        }
    }

    private static void BellManFord(int start, List<int[]>[] adjList, int[] verticesAndEdges)
    {
        int[] dist = new int[verticesAndEdges[0] + 1];
        int[] prev = new int[verticesAndEdges[0] + 1];
        Array.Fill(dist, int.MaxValue);
        dist[start] = 0;
        for (var i = 1; i < verticesAndEdges[0] + 1; i++)
        {
            foreach (var neighbor in adjList[i])
            {
                int j = neighbor[0];
                int weight = neighbor[1];

                if (dist[i] != int.MaxValue && dist[j] > dist[i] + weight)
                {
                    if (start == j) ConstructCycle(i, start, prev);
                    dist[j] = dist[i] + weight;
                    prev[j] = i;
                }
            }
        }

    }

    private static void ConstructCycle(int i, int start, int[] prev)
    {
        while (true)
        {
            if (!NotReachable.Contains(i) && !Infinitie.Contains(i))
            {
                Infinitie.Add(i);
                result[i - 1] = "-";
            }
            if (i == start)
            {
                break;
            }
            i = prev[i];
        }
    }

    private static void BFS(int s, List<int[]>[] adjList, int[] verticesAndEdges)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(s);
        bool[] visited = new bool[verticesAndEdges[0] + 1];
        while (queue.Count > 0)
        {
            var dequeued = queue.Dequeue();
            visited[dequeued] = true;
            foreach (var neighbor in adjList[dequeued])
            {
                if (!visited[neighbor[0]])
                    queue.Enqueue(neighbor[0]);
            }
        }

        for (var i = 1; i < visited.Length; i++)
        {
            if (!visited[i])
            {
                result[i - 1] = "*";
                NotReachable.Add(i);
            }
        }
    }
}