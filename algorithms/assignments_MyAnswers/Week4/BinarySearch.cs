using System;
using System.Linq;
using System.Collections.Generic;

public static class BinarySearch
{
    // nLog(n)
    public static int[] SearchInTwoArr(int[] mNum, int[] nNum)
    {
        var result = new List<int>();
        Array.Sort(mNum);
        for (var i = 0; i < nNum.Length; i++)
        {
            var r = ComputeSearch(mNum, nNum[i]);
            result.Add(r);
        }
        return result.ToArray();
    }

    public static int ComputeSearch(int[] arr, int q)
    {
        int left = 0; int right = arr.Length - 1;
        int min;
        while (left <= right)
        {
            min = left + (right - left) / 2;
            if (q == arr[min])
            {
                return min;
            }
            else if (q > arr[min])
            {
                left = min + 1;
            }
            else
            {
                right = min - 1;
            }
        }
        return -1;
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         int m = int.Parse(Console.ReadLine());
//         var mNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         int n = int.Parse(Console.ReadLine());
//         var nNum = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = BinarySearch.SearchInTwoArr(mNum, nNum);
//         Console.WriteLine(String.Join(" ", result));
//     }
// }
