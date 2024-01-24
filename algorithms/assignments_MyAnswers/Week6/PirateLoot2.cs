using System;
using System.Linq;
using System.Collections.Generic;
public static class PirateLoot2
{
    public static bool Compute(int[] w)
    {
        int totalSum = 0;
        for (var i = 0; i < w.Length; i++)
        {
            totalSum += w[i];
        }
        if (totalSum % 3 != 0)
        {
            return false;
        }

        int partitionSum = totalSum / 3;
        bool[,,,] dp = new bool[w.Length + 1, partitionSum + 1, partitionSum + 1, partitionSum + 1];
        dp[0, 0, 0, 0] = true;

        for (var i = 0; i < w.Length; i++)
        {
            for (var a = 0; a <= partitionSum; a++)
            {
                for (var b = 0; b <= partitionSum; b++)
                {
                    for (var c = 0; c <= partitionSum; c++)
                    {
                        if (dp[i, a, b, c])
                        {
                            dp[i + 1, a, b, c] = true;

                            if (a + w[i] <= partitionSum)
                                dp[i + 1, a + w[i], b, c] = true;
                            if (b + w[i] <= partitionSum)
                                dp[i + 1, a, b + w[i], c] = true;
                            if (c + w[i] <= partitionSum)
                                dp[i + 1, a, b, c + w[i]] = true;
                        }
                    }
                }
            }
        }

        return dp[w.Length, partitionSum, partitionSum, partitionSum];
    }
}

// public static class Program
// {

//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var values= Console.ReadLine().Split().Select(int.Parse).ToArray();
//         int result = PirateLoot2.Compute(values) ? 1 : 0;
//         Console.WriteLine(result);
//     }
// }