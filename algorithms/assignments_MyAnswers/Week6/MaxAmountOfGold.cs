using System;
using System.Collections;
using System.Collections.Generic;
public static class MaxAmountOfGold
{
    public static int ComputeTebulation(int[] weights, int capacity)
    {
        int[,] dp = new int[weights.Length + 1, capacity + 1];
        for (var i = 0; i < weights.Length + 1; i++)
        {
            for (var w = 0; w < capacity + 1; w++)
            {
                if (w == 0 || i == 0)
                {
                    dp[i, w] = 0;
                }
                else if (w >= weights[i - 1])
                {
                    dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + weights[i - 1]);
                }
                else
                {
                    dp[i, w] = dp[i - 1, w];
                }
            }
        }
        for (var i = 0; i < weights.Length+1; i++)
        {
            for (var w = 0; w < capacity + 1; w++)
            {
                Console.Write(dp[i,w]+" ");
            }
            Console.WriteLine();
        }
        return dp[weights.Length, capacity];
    }

    public static int ComputeMemoization(int[] weights, int capacity, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(capacity))
        {
            return memo[capacity];
        }
        int maxValue = 0;
        for (var i = 0; i < weights.Length; i++)
        {
            if (capacity > weights[i])
                maxValue = Math.Max(ComputeMemoization(weights, capacity - weights[i], memo) + weights[i], maxValue);

        }
        memo[capacity] = maxValue;
        return maxValue;
    }

}

// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         int capacity = firstLine[0];
//         int[] weights = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = MaxAmountOfGold.ComputeTebulation(weights, capacity);
//         Console.WriteLine(result);
//     }
// }
