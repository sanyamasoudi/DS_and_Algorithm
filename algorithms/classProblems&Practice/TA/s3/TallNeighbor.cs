using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

public static class TallNeighbor
{
    public static int[] ComputeNaive(int[] nums)
    {
        int[] ans = new int[nums.Length];
        ans[nums.Length - 1] = -1;
        int ansIndex = nums.Length - 2;
        while (ansIndex >= 0)
        {
            int current = nums[ansIndex];
            for (var i = ansIndex + 1; i < nums.Length; i++)
            {
                if (nums[i] > current)
                {
                    ans[ansIndex] = i;
                    break;
                }
            }
            if (ans[ansIndex] == 0)
            {
                ans[ansIndex] = -1;
            }
            ansIndex--;
        }
        return ans;
    }
    public static int[] Compute2Naive(int[] nums)
    {
        int[] ans = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            var largestOne = nums.Where((_, index) => index > i).FirstOrDefault((ele) => ele > nums[i]);
            ans[i] = Array.IndexOf(nums, largestOne);
        }
        return ans;
    }
    public static int[] Compute3(int[] nums)
    {
        int[] ans = new int[nums.Length];
        Array.Fill(ans, -1);

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (stack.Count > 0 && nums[i] > nums[stack.Peek()])
            {
                int index = stack.Pop();
                ans[index] = i;
            }
            stack.Push(i);
        }

        return ans;
    }
    public static int[] Compute4(int[] nums)
    {
        int[] ans = new int[nums.Length];
        Array.Fill(ans, -1);

        List<int> list = new List<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            while (list.Count > 0 && nums[i] > nums[list[list.Count - 1]])
            {
                int index = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                ans[index] = i;
            }
            list.Add(i);
        }

        return ans;
    }
    public static int[] FindNextTaller(int[] heights)
    {
        int[] result = new int[heights.Length];
        Stack<int> stack = new Stack<int>();

        for (int i = heights.Length - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[i] >= heights[stack.Peek()])
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                result[i] = -1;
            }
            else
            {
                result[i] = stack.Peek() ;
            }

            stack.Push(i);
        }

        return result;
    }
}
// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         var n = int.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         // var result = TallNeighbor.Compute(nums);
//         var result2 = TallNeighbor.Compute4(nums);
//         // Console.WriteLine("res1:");
//         // Console.WriteLine(String.Join(" ", result));
//         // Console.WriteLine("res2:");
//         Console.WriteLine(String.Join(" ", result2));
//     }
// }

// public static class Program
// {
//     public static void Main(string[] args)
//     {
//         var n = int.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result2 = TallNeighbor.FindNextTaller(nums);
//         Console.WriteLine(String.Join(" ", result2));
//     }
// }