using System;
using System.Collections;
using System.Collections.Generic;
public static class EditDistance
{
    public static int Compute(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        for (var i = 0; i < s1.Length + 1; i++)
        {
            dp[i, 0] = i;
        }
        for (var j = 0; j < s2.Length + 1; j++)
        {
            dp[0, j] = j;
        }
        for (var j = 1; j < s2.Length + 1; j++)
        {
            for (var i = 1; i < s1.Length + 1; i++)
            {
                int insertion = dp[i, j - 1] + 1;
                int delation = dp[i - 1, j] + 1;
                int match = dp[i - 1, j - 1];
                int misMatch = dp[i - 1, j - 1] + 1;
                if (s1[i-1] == s2[j-1])
                    dp[i,j]=Math.Min(Math.Min(insertion,delation),match);
                else
                    dp[i,j] =Math.Min(Math.Min(insertion,delation),misMatch);
            }
        }
        return dp[s1.Length,s2.Length ];
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var s1=Console.ReadLine();
//         var s2=Console.ReadLine();
//         var result = EditDistance.Compute(s1,s2);

//         Console.WriteLine(result);
//     }
// }
