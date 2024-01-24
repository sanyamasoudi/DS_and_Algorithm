using System;
using System.Collections;
using System.Collections.Generic;
public class LongestCommonSubsequence2
{

    // public static int ComputeLCS(int[] sequenceA, int[] sequenceB)
    // {
    //     int[,] dp = new int[sequenceA.Length + 1, sequenceB.Length + 1];

    //     for (int i = 0; i <= sequenceA.Length; i++)
    //     {
    //         for (int j = 0; j <= sequenceB.Length; j++)
    //         {
    //             if (i == 0 || j == 0)
    //                 dp[i, j] = 0;
    //             else if (sequenceA[i - 1] == sequenceB[j - 1])
    //                 dp[i, j] = dp[i - 1, j - 1] + 1;
    //             else
    //                 dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
    //         }
    //     }
    //     return dp[sequenceA.Length, sequenceB.Length];
    // }
    public static int Compute(int[] s1, int[] s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        for (var j = 1; j < s2.Length + 1; j++)
        {
            for (var i = 1; i < s1.Length + 1; i++)
            {
                int insertion = dp[i, j - 1];
                int delation = dp[i - 1, j];
                int match = dp[i - 1, j - 1] + 1;
                if (s1[i - 1] == s2[j - 1])
                    dp[i, j] = match;
                else
                    dp[i, j] = Math.Max(insertion, delation);
            }
        }
        return dp[s1.Length, s2.Length];
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         int[] sequenceA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

//         int m = int.Parse(Console.ReadLine());
//         int[] sequenceB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

//         int result = LongestCommonSubsequence2.Compute(sequenceA, sequenceB);
//         Console.WriteLine(result);
//     }
// }
