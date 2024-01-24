using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class Bst
{
    static List<int> key = new List<int>();
    static List<int> left = new List<int>();
    static List<int> right = new List<int>();
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     for (var i = 0; i < n; i++)
    //     {
    //         var input = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //         key.Add(input[0]);
    //         left.Add(input[1]);
    //         right.Add(input[2]);
    //     }
    //     if (n == 0)
    //     {
    //         Console.WriteLine("CORRECT");
    //     }
    //     else
    //     {
    //         var result = IsBst(0, int.MinValue, int.MaxValue);
    //         Console.WriteLine(result == true ? "CORRECT" : "INCORRECT");
    //     }
    // }
    public static bool IsBst(int nodeIndex, int min, int max)
    {
        if (nodeIndex == -1)
        {
            return true;
        }
        if (key[nodeIndex] < min || key[nodeIndex] > max)
        {
            return false;
        }
        return IsBst(left[nodeIndex], min, key[nodeIndex]) && IsBst(right[nodeIndex], key[nodeIndex], max);
    }
}