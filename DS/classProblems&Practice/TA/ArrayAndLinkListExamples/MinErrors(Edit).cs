// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         int[,] graph = new int[n, n];
//         for (var i = 0; i < n; i++)
//         {
//             var inputGraph = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
//             for (var j = 0; j < n; j++)
//             {
//                 graph[i, j] = inputGraph[j];
//             }
//             inputGraph = null;
//         }
//         int m = int.Parse(Console.ReadLine());
//         var bugs = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
//         int result = DFSInGraph.WichOneDelete(graph, n, bugs);
//         Console.WriteLine(result);
//     }
// }

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
    public static int WichOneDelete(int[,] graph, int n, int[] bugs)
    {
        Array.Sort(bugs);
        int min = int.MaxValue;
        int result = -1;
        foreach (var bg in bugs)
        {
            int count = CountOfInfectedAfterRemove(bg, graph, n, bugs);
            if (count < min)
            {
                min = count;
                result = bg;
            }
        }
        return result;
    }
    static bool[] visited;
    public static int CountOfInfectedAfterRemove(int itemDeleted, int[,] graph, int n, int[] bugs)
    {
        visited = new bool[n];
        foreach (var bug in bugs)
        {
            if (bug != itemDeleted)
            {
                visited[bug] = true;
            }
        }
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFS(i, Graph2.FillGraph(graph, n));
            }
        }
        int result = 0;
        foreach (var isInfected in visited)
        {
            if (isInfected == true)
            {
                result++;
            }
        }
        return result;
    }

    private static void DFS(int k, List<int>[] mgraph)
    {
        visited[k] = true;
        foreach (var item in mgraph[k])
        {
            if (!visited[item])
            {
                DFS(item, mgraph);
            }
        }
    }

}