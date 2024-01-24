using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic;
public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var nums = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        int m = int.Parse(Console.ReadLine());

        // MaxSlidingWindow.max_sliding_window_naive(nums, m);
        // Console.WriteLine();
        MaxSlidingWindow.MaxBV2(nums, m);
    }
}
public static class MaxSlidingWindow
{
    public static void max_sliding_window_naive(int[] A, int w)
    {
        for (var i = 0; i < A.Length - w + 1; ++i)
        {
            int window_max = A[i];
            for (var j = i + 1; j < i + w; ++j)
                window_max = Math.Max(window_max, A[j]);

            Console.Write(window_max + " ");
        }

        return;
    }

    public static void MaxNaive(int[] A, int w)
    {
        LinkedList<int> li = new LinkedList<int>();

        for (var i = 0; i < w; i++)
        {
            li.AddLast(A[i]);
        }
        Console.Write(li.Max() + " ");
        for (var i = 1; i <= A.Length - w; ++i)
        {
            li.RemoveFirst();
            li.AddLast(A[i - 1 + w]);
            Console.Write(li.Max() + " ");
        }
    }

    // public static void MaxBV3(int[] nums, int w)
    // {
    //     int window = 0;
    //     LinkedList<int> li = new LinkedList<int>();
    //     for (var i = 0; i < w; i++)
    //     {
    //         li.AddLast(nums[i]);
    //     }
    //     Console.Write(li.Max()+" ");
    //     window++;
    //     for (var i = w; i < nums.Length; i++)
    //     {
    //         for (var k = 0; k < w; k++)
    //         {
    //             if (k==0)
    //             {
    //                 li.RemoveFirst();
    //             }
    //             while (li.Count > 0 && li.Last.Value <= nums[i])
    //             {
    //                 li.RemoveLast();
    //             }
    //             li.AddLast(nums[i]);
    //         }
    //         window++;
    //         Console.Write(li.First.Value+" ");
    //     }
    // }
public static void MaxBV2(int[] A, int w)
{
    if (A.Length == 1)
    {
        Console.WriteLine(A[0]);
    }
    else if (w == 1)
    {
        Console.WriteLine(String.Join(" ", A));
    }
    else
    {
        LinkedList<int> li = new LinkedList<int>();

        for (var i = 0; i < w; i++)
        {
            while (li.Count > 0 && A[i] > li.Last.Value)
            {
                li.RemoveLast();
            }
            li.AddLast(A[i]);
        }
        Console.Write(li.First.Value + " ");

        for (var i = 1; i <= A.Length - w; i++)
        {
            if (li.First.Value == A[i - 1])
            {
                li.RemoveFirst();
            }
            while (li.Count > 0 && A[i + w - 1] > li.Last.Value)
            {
                li.RemoveLast();
            }
            li.AddLast(A[i + w - 1]);
            Console.Write(li.First.Value + " ");
        }
    }
}
}