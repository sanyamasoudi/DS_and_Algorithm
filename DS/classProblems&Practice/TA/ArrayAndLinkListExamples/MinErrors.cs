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
//         int result = Tree.WichOneDelete(graph, n, bugs);
//         Console.WriteLine(result);
//     }
// }
public static class Tree
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
    public static int CountOfInfectedAfterRemove(int itemDeleted, int[,] graph, int n, int[] bugs)
    {
        Queue<int> queue = new Queue<int>();
        bool[] chekedN = new bool[n];
        foreach (var item in bugs)
        {
            if (item != itemDeleted)
            {
                queue.Enqueue(item);
                chekedN[item] = true;
            }
        }
        while (queue.Count > 0)
        {
            var p = queue.Dequeue();
            for (var i = 0; i < n; i++)
            {
                if (graph[p, i] == 1 && !chekedN[i])
                {
                    queue.Enqueue(i);
                    chekedN[i] = true;
                }

            }
        }
        int result = 0;
        foreach (var isInfected in chekedN)
        {
            if (isInfected == true)
            {
                result++;
            }
        }
        return result;
    }
}