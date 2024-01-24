using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
public static class MergeSort2
{
    public static int index;
    public static string x;
    public static int[] ComputeMerge(int[] arr)
    {
        if (arr.Length == 1) return arr;
        Stack<int> stackLeft = new Stack<int>();
        Stack<int> stackRight = new Stack<int>();

        for (var i = arr.Length - 1; i >= 0; i--)
        {
            if (x[index] == '0')
            {
                stackLeft.Push(arr[i]);
                index--;
            }
            else if (x[index] == '1')
            {
                stackRight.Push(arr[i]);
                index--;
            }
        }
        var right = ComputeMerge(stackRight.ToArray());
        var left = ComputeMerge(stackLeft.ToArray());
        var result = Combine(left, right);
        return result;
    }

    private static int[] Combine(int[] left, int[] right)
    {
        int resultIndex = 0;
        int[] result = new int[left.Length + right.Length];
        for (var i = 0; i < left.Length; i++)
        {
            result[resultIndex] = left[i];
            resultIndex++;
        }
        for (var i = 0; i < right.Length; i++)
        {
            result[resultIndex] = right[i];
            resultIndex++;
        }
        return result;
    }
    public static int CountOfOperations(int n)
    {
        if (n == 1)
            return 0;
        return n + CountOfOperations(n / 2) + CountOfOperations(n - n / 2);
    }
    public static int BinarySearch(int[] arr, int q)
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
public class Program
{
    public static void Main()
    {

        // int n = int.Parse(Console.ReadLine());
        string str = Console.ReadLine();
        MergeSort2.index = str.Length - 1;
        MergeSort2.x = str;

        int[] SearchArr = new int[str.Length];
        for (var i = 1; i <= str.Length; i++)
        {
            SearchArr[i - 1] = MergeSort2.CountOfOperations(i);
        }
        int n = MergeSort2.BinarySearch(SearchArr, str.Length) + 1;

        int[] myArr = new int[n];
        for (var i = 1; i <= n; i++)
        {
            myArr[i - 1] = i;
        }
        var result = MergeSort2.ComputeMerge(myArr);
        Console.WriteLine(String.Join(" ", result));
    }
}