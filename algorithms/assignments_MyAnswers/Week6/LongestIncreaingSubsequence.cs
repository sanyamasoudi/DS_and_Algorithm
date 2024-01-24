using System;
using System.Linq;

public static class LongestIncreasingSubsequence
{
    public static int[] memo;

    public static int ComputeMemo(int[] arr, int i)
    {
        if (memo[i] != 0)
        {
            return memo[i];
        }

        memo[i] = 1; // Initialize the value to 1 as the minimum possible length of a subsequence is 1

        for (var j = 0; j < i; j++)
        {
            if (arr[j] < arr[i])
            {
                memo[i] = Math.Max(memo[i], ComputeMemo(arr, j) + 1);
            }
        }
        return memo[i];
    }

    public static void Main(string[] args)
    {
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int max = 0; // Change to 0 as the minimum length is 0 if the array is empty
        LongestIncreasingSubsequence.memo = new int[arr.Length];
        for (var i = 0; i < arr.Length; i++)
        {
            max = Math.Max(max, LongestIncreasingSubsequence.ComputeMemo(arr, i));
        }
        Console.WriteLine(max);
    }
}
