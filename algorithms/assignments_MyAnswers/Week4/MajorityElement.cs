using System;
using System.Linq;
using System.Collections.Generic;

public static class MajorityElement
{
    // O(n^2)
    public static int GetMajorityElementNaive(int[] arr)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            int currentElement = arr[i];
            int count = 0;
            for (var j = 0; j < arr.Length; j++)
            {
                if (arr[j] == currentElement) count++;
            }
            if (count > arr.Length / 2) return 1;
        }
        return 0;
    }
    // O(nlogn)
    // public static int GetMajorityElementEfficent(int[] a, int left, int right)
    // {
    //     Array.Sort(a);
    //     if (left == right) return -1;
    //     if (left + 1 == right) return a[left];
    //     int mid = left + (right - left) / 2;
    //     int leftMajority = GetMajorityElementEfficent(a, left, mid - 1);
    //     int rightMajority = GetMajorityElementEfficent(a, mid + 1, right);
    //     int leftCount = Count(leftMajority, a);
    //     int rightCount = Count(rightMajority, a);
    //     if (leftCount > a.Length / 2 || rightCount > a.Length / 2)
    //     {
    //         return 1;
    //     }
    //     else return 0;
    // }


    // T(n)= 2T(n/2) + O(n)
    // O(nlogn)
    public static int GetMajorityElementEfficent(int[] a, int left, int right)
    {
        if (left == right) return a[left];
        int mid = left + (right - left) / 2;
        int leftMajority = GetMajorityElementEfficent(a, left, mid);
        int rightMajority = GetMajorityElementEfficent(a, mid + 1, right);
        if (leftMajority == rightMajority) return leftMajority;
        int leftCount = Count(leftMajority, a, left, right);
        int rightCount = Count(rightMajority, a, left, right);
        if (leftCount > (right - left + 1) / 2) return leftMajority;
        if (rightCount > (right - left + 1) / 2) return rightMajority;
        return -1;
    }

    private static int Count(int Majority, int[] a, int left, int right)
    {
        int c = 0;
        for (var i = left; i <= right; i++)
        {
            if (a[i] == Majority) c++;
        }
        return c;
    }
    // O(n)
    public static int GetMajorityElementEfficentOnMore(int[] a)
    {
        Array.Sort(a);
        int half=a.Length/2;
        for (var i = 0; i < a.Length; i++)
        {
            if (i+half<a.Length)
            {
                if(a[i+half]==a[i]) return 1;
            }
        }
        return 0;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = MajorityElement.GetMajorityElementEfficent(nums, 0, nums.Length - 1);
//         if (result == -1)
//             Console.WriteLine(0);
//         else
//             Console.WriteLine(1);
//     }
// }