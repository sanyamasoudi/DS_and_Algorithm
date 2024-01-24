using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

public static class BestSubSet
{
    public static int Compute(int[] nums)
    {
        int maxEndingHere = nums[0];
        int maxSoFar = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }
    public static int Compute3(int[] nums)
    {
        int[] dp = new int[nums.Length];
        int Bestsum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            
            Bestsum = Math.Max(nums[i], Bestsum + nums[i]);
            dp[i]=Bestsum;
        }
        return dp.Max();
    }
    public static int Compute4(int[] nums)
    {
        int[] dp = new int[nums.Length];
        for (var i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(Math.Max(nums[i] + dp[i - 1], nums[i]), 0);
        }
        return dp.Max();
    }
}

// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         var n = int.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = BestSubSet.Compute3(nums);
//         Console.WriteLine(result);
//     }
// }