using System;
using System.Linq;
using System.Collections.Generic;
public class DotProduct
{
    //O(nlogn)
    public static long MaxDotProduct(int[] a, int[] b)
    {
        a = a.OrderBy(x=>x).ToArray();
        b=b.OrderBy(x=>x).ToArray();//O(nlogn)
        long result = 0;
        for (int i = 0; i < a.Length; i++)//O(n)
        {
            result += (long)a[i] * (long)b[i];
        }
        return result;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         int[] priceArr = new int[n];
//         int[] clickArr = new int[n];
//         priceArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//         clickArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//         var output = DotProduct.MaxDotProduct(priceArr, clickArr);
//         Console.WriteLine(output);
//     }
// }