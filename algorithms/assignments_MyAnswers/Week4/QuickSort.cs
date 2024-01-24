using System;
using System.Linq;
using System.Collections.Generic;
public static class QuickSort
{
    public static int[] QuickSort3(this int[] arr, int l, int r)
    {
        if (l >= r) return arr;
        var (m1, m2) = Partition4(arr, l, r);
        QuickSort3(arr, l, m1 - 1);
        QuickSort3(arr, m2 + 1, r);
        return arr;
    }

    // private static (int m1, int m2) Partition3(int[] arr, int l, int r)
    // {
    //     int x = arr[l];
    //     int j2 = l;
    //     int c = 0;
    //     int j1;
    //     for (var i = l + 1; i <= r; i++)
    //     {
    //         if (arr[i] <= x)
    //         {
    //             j2++;
    //             arr = Swap(j2, i, arr);
    //         }
    //         if (arr[i] == x)
    //         {
    //             c++;
    //         }
    //     }
    //     j1 = j2 - c;
    //     arr = Swap(l, j1, arr);
    //     return (j1, j2);
    // }
    private static (int m1, int m2) Partition4(int[] arr, int l, int r)
    {
        int value = arr[l];
        int i = l;
        while (i <= r)
        {
            if (arr[i] == value)
            {
                i++;
            }
            else if (arr[i] < value)
            {
                Swap(l,i,arr);
                i++;
                l++;
            }
            else
            {
                Swap(r,i,arr);
                r--;
            }
        }
        return (l,r); 
    }

    private static int[] Swap(int v1, int v2, int[] arr)
    {
        var v3 = arr[v1];
        arr[v1] = arr[v2];
        arr[v2] = v3;
        return arr;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = QuickSort.QuickSort3(nums, 0, nums.Length - 1);
//         Console.WriteLine(String.Join(" ", result));
//     }
// }