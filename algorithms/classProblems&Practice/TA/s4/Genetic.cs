using System;
using System.Collections.Generic;
using System.Linq;

public static class Genetic
{
    public static int Computem(string s1, string s2)
    {
        int[,] dp = new int[s1.Length + 1, s2.Length + 1];
        for (var j = 1; j < s2.Length + 1; j++)
        {
            dp[0, j] = dp[0, j-1] + getvalue(s2[j - 1]);
        }
        for (var i = 1; i <= s1.Length; i++)
        {
            for (var j = 1; j <= s2.Length; j++)
            {
                int insertion = dp[i, j-1] + getvalue(s2[j - 1]);
                int match = dp[i - 1, j - 1];

                if (s1[i - 1] == s2[j - 1])
                {
                    dp[i, j] = Math.Min(insertion, match);
                }
                else
                {
                    dp[i, j] = insertion;
                }
            }
        }     
        int result = int.MaxValue;
        for (var i = 0; i <= s1.Length; i++)
        {
            result = Math.Min(dp[i, s2.Length], result);
        }
        return result;
    }
    public static int[] valuesArr;
    private static int getvalue(char v)
    {
        if (v == 'A')
        {
            return valuesArr[0];
        }
        else if (v == 'C')
        {
            return valuesArr[1];
        }
        else if (v == 'G')
        {
            return valuesArr[2];
        }
        else
        {
            return valuesArr[3];
        }
    }

    public static void Main()
    {
        var s1 = Console.ReadLine();
        var s2 = Console.ReadLine();
        var values = Console.ReadLine().Split().Select(int.Parse).ToArray();
        valuesArr = values;

        var result = Computem(s1, s2);
        Console.WriteLine(result);
    }
}
