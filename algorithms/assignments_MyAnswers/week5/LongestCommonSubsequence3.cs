using System;
using System.Collections;
using System.Collections.Generic;
public class LongestCommonSubsequence3
{
    public static int Compute(int[] s1, int[] s2, int[] s3)
    {
        int[,,] dp = new int[s1.Length + 1, s2.Length + 1, s3.Length + 1];
        for (var k = 1; k < s3.Length + 1; k++)
        {
            for (var j = 1; j < s2.Length + 1; j++)
            {
                for (var i = 1; i < s1.Length + 1; i++)
                {
                    int insertion1 = dp[i, j - 1, k];
                    int delation1 = dp[i - 1, j, k];
                    int insertion2 = dp[i, j , k - 1];

                    int match = dp[i - 1, j - 1, k-1] + 1;
                    if (s1[i - 1] == s2[j - 1]  && s1[i - 1] == s3[k - 1])
                        dp[i, j, k] =match;
                    else
                        dp[i, j, k] = Math.Max(Math.Max(insertion1, delation1),insertion2);
                }
            }
        }
        return dp[s1.Length, s2.Length, s3.Length];
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] sequenceA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int m = int.Parse(Console.ReadLine());
        int[] sequenceB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int k = int.Parse(Console.ReadLine());
        int[] sequenceC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

        int result = LongestCommonSubsequence3.Compute(sequenceA, sequenceB, sequenceC);
        Console.WriteLine(result);
    }
}
