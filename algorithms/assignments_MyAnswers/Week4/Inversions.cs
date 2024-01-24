using System;
using System.Linq;
using System.Collections.Generic;
public static class Inversions
{
    public static long GetNumberOfInversionsNaive(int[] a)
    {
        long numberOfInversions = 0;
        for (var i = 0; i < a.Length; i++)
        {
            for (var j = i + 1; j < a.Length; j++)
            {
                if (a[j] < a[i])
                {
                    numberOfInversions++;
                }
            }
        }
        return numberOfInversions;
    }

    public static int count = 0;
    public static int[] MergeSort(this int[] arr)
    {
        if (arr.Length == 1) return arr;
        int m = arr.Length / 2;
        var B = MergeSort(arr.Take(m).ToArray()); // <m
        var C = MergeSort(arr.Skip(m).ToArray()); // m<=
        count += Merge(B, C).Item2;
        arr = Merge(B, C).Item1;
        return arr;
    }
    private static (int[], int) Merge(int[] b, int[] c)
    {
        int count = 0;
        var result = new List<int>();
        int i = 0, j = 0;
        while (i < b.Length && j < c.Length)
        {
            if (b[i] <= c[j])
            {
                result.Add(b[i]);
                i++;
            }
            else
            {
                result.Add(c[j]);
                count += b.Length - i;
                j++;
            }
        }
        while (i < b.Length)
        {
            result.Add(b[i]);
            i++;
        }
        while (j < c.Length)
        {
            result.Add(c[j]);
            j++;
        }
        return (result.ToArray(), count);
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var nums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = Inversions.MergeSort(nums1);
//         Console.WriteLine(Inversions.count);
//     }
// }