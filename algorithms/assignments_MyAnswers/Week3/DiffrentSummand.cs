using System.Collections.Generic;
using System;
using System.Linq;
public class DifferentSummands
{
    public static List<int> OptimalSummands(int n)
    {
        List<int> summands = new List<int>();
        int sum = 0;
        int i = 1;
        while (sum!=n)
        {
            sum += i;
            int remaining = n - sum;
            summands.Add(i);
            i++;
            if (remaining < i )
            {
                i--;
                summands.Remove(i);
                summands.Add(i+remaining);
                sum+=remaining;
            }
        }

        return summands;
    }
    // public static List<int> OptimalSummands3(int n)
    // {
    //     List<int> summands = new List<int>();
    //     int sum = 0;
    //     int i = 1;
    //     while (sum!=n)
    //     {
    //         sum += i;
    //         int remaining = n - sum;
    //         summands.Add(i);
    //         i++;
    //         if (remaining < i )
    //         {
    //             i--;
    //             summands.Remove(i);
    //             summands.Add(i+remaining);
    //             sum+=remaining;
    //         }
    //     }

    //     return summands;
    // }


    // public static List<int> OptimalSummandsFast(int n)
    // {
    //     List<int> summands = new List<int>();
    //     int k = (int)Math.Floor((-1 + Math.Sqrt(1 + 8 * n)) / 2);
    //     for (int i = 1; i <= k; i++)
    //     {
    //         summands.Add(i);
    //     }
    //     int sum = k * (k + 1) / 2;
    //     if (n - sum > 0)
    //     {
    //         summands[summands.Count - 1] += n - sum;
    //     }
    //     return summands;
    // }

    // public static List<int> OptimalSummands2(int n)
    // {
    //     List<int> summands = new List<int>();
    //     for (var i = 1; i <= n; i++)
    //     {
    //         n-=i;
    //         if(n-i<=0)
    //         {
    //             i+=n;
    //             summands.Add(i);
    //         }
    //         else summands.Add(i);
    //     }
    //     return summands;
    // }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var result1 = DifferentSummands.OptimalSummands(n);
//         Console.WriteLine(result1.Count);
//         Console.WriteLine(String.Join(" ",result1));
//     }
// }