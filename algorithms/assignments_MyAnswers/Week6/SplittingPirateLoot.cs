public static class SplittingPirateLoot
{
    public static int ComputeRepitition(int[] weights, int capacity)
    {
        int[] dp = new int[capacity + 1];

        for (int i = 1; i < capacity + 1; i++)
        {
            for (int j = 0; j < weights.Length; j++)
            {
                if (weights[j] <= i)
                {
                    dp[i] = Math.Max(dp[i], dp[i - weights[j]] + weights[j]);
                }
            }
        }
        for (var i = 0; i < capacity + 1; i++)
        {
            Console.Write(dp[i] + " ");
        }
        return dp[capacity];
    }


    public static List<int> ComputeSubsetSums(int[] arr)
    {
        List<int> subsetSums = new List<int>();

        int n = arr.Length;
        int totalSum = 0;

        // Calculate the total sum of all elements in the array
        for (int i = 0; i < n; i++)
        {
            totalSum += arr[i];
        }

        // Create a boolean array to track sums that are achievable
        bool[] possibleSums = new bool[totalSum + 1];
        possibleSums[0] = true;

        for (int i = 0; i < n; i++)
        {
            for (int j = totalSum; j >= arr[i]; j--)
            {
                // Check if sum j - arr[i] is possible
                if (possibleSums[j - arr[i]])
                {
                    possibleSums[j] = true;
                }
            }
        }

        // Adding all possible sums to the result list
        for (int i = 0; i <= totalSum; i++)
        {
            if (possibleSums[i])
            {
                subsetSums.Add(i);
            }
        }

        return subsetSums;
    }

    // public static int Compute(int[] numbers)
    // {
    //     int n = numbers.Length;

    //     int[,] m = new int[n + 1, n + 1];
    //     int[,] M = new int[n + 1, n + 1];

    //     for (var i = 1; i <= n; i++)
    //     {
    //         M[i, i] = numbers[i - 1];
    //         m[i, i] = numbers[i - 1];
    //     }

    //     for (var s = 1; s <= n - 1; s++)
    //     {
    //         for (var i = 1; i <= n - s; i++)
    //         {
    //             int j = i + s;
    //             MinAndMax(i, j, m, M);
    //         }
    //     }
    //     Console.WriteLine("minMatrix:");
    //     for (var i = 0; i < n + 1; i++)
    //     {
    //         for (var j = 0; j < n + 1; j++)
    //         {
    //             Console.Write(m[i, j] + " ");
    //         }
    //         Console.WriteLine();
    //     }
    //     Console.WriteLine("maxMatrix:");
    //     for (var i = 0; i < n + 1; i++)
    //     {
    //         for (var j = 0; j < n + 1; j++)
    //         {
    //             Console.Write(M[i, j] + " ");
    //         }
    //         Console.WriteLine();
    //     }
    //     return M[1, n];
    // }

    // public static void MinAndMax(int i, int j, int[,] m, int[,] M)
    // {
    //     int min = int.MaxValue;
    //     int max = int.MinValue;

    //     for (var k = i; k <= j - 1; k++)
    //     {
    //         int a = PerformOp(M[i, k], '+', M[k + 1, j]);
    //         int b = PerformOp(M[i, k], '+', m[k + 1, j]);
    //         int c = PerformOp(m[i, k], '+', M[k + 1, j]);
    //         int d = PerformOp(m[i, k], '+', m[k + 1, j]);

    //         min = Math.Min(min, Math.Min(Math.Min(a, b), Math.Min(c, d)));
    //         max = Math.Max(max, Math.Max(Math.Max(a, b), Math.Max(c, d)));
    //     }
    //     M[i, j] = max;
    //     m[i, j] = min;
    // }

    // private static int PerformOp(int v1, char op, int v2) => v1 + v2;


}
// public class Program
// {
//     // public static void Main()
//     // {
//     //     var expression = Console.ReadLine().Split().Select(int.Parse).ToArray();
//     //     int result = SplittingPirateLoot.Compute(expression);
//     //     Console.WriteLine(result);
//     // }
//     public static void Main()
//     {
//         var expression = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         int result = SplittingPirateLoot.ComputeRepitition(expression, expression.Length);
//         Console.WriteLine(result);
//     }
// }