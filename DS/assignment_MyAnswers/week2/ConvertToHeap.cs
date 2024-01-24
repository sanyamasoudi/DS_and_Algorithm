using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class ConvertToHeap
{
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     BuildHeap(arr, n);
    //     Console.WriteLine(result.Count);
    //     foreach (var r in result)
    //     {
    //         Console.WriteLine($"{r.Item1} {r.Item2}");
    //     }
    // }

    private static void BuildHeap(int[] arr, int n)
    {
        for (var i = n / 2 - 1; i >= 0; i--)
        {
            SiftDown(i, n, arr);
        }
    }
    static List<Tuple<int,int>> result=new List<Tuple<int,int>>();
    private static void SiftDown(int index, int size, int[] arr)
    {
        
        while (index < size)
        {
            int leftIdx = 2 * index + 1;
            int rightIdx = 2 * index + 2;
            int minIdx = index;
            if (leftIdx < size && arr[leftIdx] <= arr[minIdx])
            {
                minIdx = leftIdx;
            }
            if (rightIdx < size && arr[rightIdx] <= arr[minIdx])
            {
                minIdx = rightIdx;
            }
            if(minIdx==index)
            {
                break;
            }
            Swap(minIdx,index,arr);
            result.Add(Tuple.Create(index,minIdx));
            index=minIdx;
        }
    }

    private static void Swap(int minIdx, int index, int[] arr)
    {
        var tmp=arr[index];
        arr[index]=arr[minIdx];
        arr[minIdx]=tmp;
    }
}