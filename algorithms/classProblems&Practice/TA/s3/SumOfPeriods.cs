using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

public static class SumOfPeriods
{
    public static int[] Compute(int[] nums, List<int[]> periods)
    {
        int[] sums = new int[nums.Length];
        int[] ans = new int[periods.Count];
        sums[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            sums[i] += sums[i - 1] + nums[i];
        }
        for (var i = 0; i < periods.Count; i++)
        {
            if (periods[i][1] == periods[i][0]) ans[i] = periods[i][1];
            else if (periods[i][0] - 2 < 0) ans[i] = sums[periods[i][1] - 1];
            else ans[i] = sums[periods[i][1] - 1] - sums[periods[i][0] - 2];
        }
        return ans;
    }
    public static int[] Compute2(int[] nums, List<int[]> periods)
    {
        int n = nums.Length;

        // Calculate the cumulative sum array
        int[] cumulativeSum = new int[n];
        cumulativeSum[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            cumulativeSum[i] = cumulativeSum[i - 1] + nums[i];
        }

        // Calculate the sums for the subarrays specified in periods
        int[] ans = new int[periods.Count];
        for (int i = 0; i < periods.Count; i++)
        {
            int left = periods[i][0] - 1; // adjust indices to 0-based
            int right = periods[i][1] - 1; // adjust indices to 0-based

            // Calculate the sum of the subarray using the precomputed cumulative sum array
            ans[i] = (left == 0) ? cumulativeSum[right] : cumulativeSum[right] - cumulativeSum[left - 1];
        }

        return ans;
    }
}
// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         var n = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         List<int[]> periodsList = new List<int[]>();
//         for (var i = 0; i < n[1]; i++)
//         {
//             var period = Console.ReadLine().Split().Select(int.Parse).ToArray();
//             periodsList.Add(period);

//         }
//         var result = SumOfPeriods.Compute2(nums, periodsList);
//         foreach (var element in result)
//         {
//             Console.WriteLine(element);
//         }
//     }
// }