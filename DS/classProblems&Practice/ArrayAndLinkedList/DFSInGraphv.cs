


public static class Graph2
{
    private static List<int>[] CreateEmptyGraph(int n)
    {
        List<int>[] ArrOfNodes = new List<int>[n];
        for (var i = 0; i < n; i++)
        {
            ArrOfNodes[i] = new List<int>();
        }
        return ArrOfNodes;
    }
    public static List<int>[] FillGraph(int[,] graph, int n)
    {
        var emptyG = CreateEmptyGraph(n);
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                if (graph[i, j] == 1 && !emptyG[i].Contains(j))
                {
                    emptyG[i].Add(j);
                }
            }
        }
        return emptyG;
    }
}
public static class DFSInGraph
{
    public static void Traversal(int fromHere, List<int>[] mgraph, int n)
    {
        bool[] visited = new bool[n];
        DFS(fromHere, mgraph, visited);
    }
    private static void DFS(int k, List<int>[] mgraph, bool[] visited)
    {
        visited[k] = true;
        Console.Write(k + " ");
        foreach (var item in mgraph[k])
        {
            if (!visited[item])
            {
                DFS(item, mgraph, visited);
            }
        }
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         int[,] graph = new int[n, n];
//         for (var i = 0; i < n; i++)
//         {
//             var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
//             for (var j = 0; j < n; j++)
//             {
//                 graph[i, j] = input[j];
//             }
//         }
//         var mgraph = Graph2.FillGraph(graph, n);
//         DFSInGraph.Traversal(0, mgraph, n);
//     }
// }