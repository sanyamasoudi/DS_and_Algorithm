using System;
using System.Linq;

public static class KnapsackDp
{
    //O(n.W) 
    public static int ComputeRepitition(int[] weights, int[] values, int capacity)
    {
        int[] dp = new int[capacity + 1];

        for (int i = 1; i < capacity + 1; i++)//caoacity=W
        {
            for (int j = 0; j < weights.Length; j++)//weights.Lenght=n
            {
                if (weights[j] <= i)
                {
                    dp[i] = Math.Max(dp[i], dp[i - weights[j]] + values[j]);
                }
            }
        }

        return dp[capacity];
    }
    //O(n.W)
    public static int ComputeWithOutRepitition(int[] weights, int[] values, int capacity)
    {
        int[,] dp = new int[weights.Length + 1, capacity + 1];

        for (int i = 0; i < weights.Length+1; i++)//weights.Lenght=n
        {
            for (int w = 0; w < capacity+1; w++)//caoacity=W
            {
                if (i == 0 || w == 0)
                    dp[i, w] = 0;
                else if (weights[i - 1] <= w)
                    dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                else
                    dp[i, w] = dp[i - 1, w];
            }
        }
        return dp[weights.Length, capacity];
    }
    //O(n.W) is pseudo polynomial, ... O(n*2^logW)
    static int KnapsackMemoizationWithRepetitionBase(int W, int[] weights, int[] values)
    {
        Dictionary<int, int> memo = new Dictionary<int, int>();
        return KnapsackMemoizationWithRepetition(W, weights, values, memo);
    }

    static int KnapsackMemoizationWithRepetition(int w, int[] weights, int[] values, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(w))
        {
            return memo[w];
        }

        int value = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (weights[i] <= w)
            {
                int val = KnapsackMemoizationWithRepetition(w - weights[i], weights, values, memo) + values[i];
                if (val > value)
                {
                    value = val;
                }
            }
        }

        memo[w] = value;
        return value;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int capacity = int.Parse(Console.ReadLine());
//         var weights = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var values = Console.ReadLine().Split().Select(int.Parse).ToArray();

//         if (weights.Length != values.Length)
//         {
//             Console.WriteLine("The number of weights must be equal to the number of values.");
//             return;
//         }

//         var result = KnapsackDp.ComputeWithOutRepitition(weights, values, capacity);
//         Console.WriteLine(result);
//     }
// }
