using System;
using System.Collections;
public static class ChangeMoney
{
    public static int Compute(int m, int[] coinArr)
    {
        int[] MinNumArr = new int[m + 1];
        for (var i = 0; i < MinNumArr.Length; i++)
        {
            MinNumArr[i] = m + 1;
        }
        MinNumArr[0] = 0;
        for (var i = 1; i <= m; i++)
        {
            for (var j = 0; j < coinArr.Length; j++)
            {
                if (i >= coinArr[j])
                {
                    int minNum = MinNumArr[i - coinArr[j]] + 1;
                    if (minNum < MinNumArr[i])
                    {
                        MinNumArr[i] = minNum;
                    }
                }
            }
        }
        return MinNumArr[m];
    }
    public static int Compute3(int m, int[] coinArr)
    {
        int[] MinNumArr = new int[m + 1];
        for (var i = 0; i < MinNumArr.Length; i++)
        {
            MinNumArr[i] = m + 1;
        }
        MinNumArr[0] = 0;
        for (var i = 1; i <= m; i++)
        {
            for (var j = 0; j < coinArr.Length; j++)
            {
                if (i >= coinArr[j])
                {
                    MinNumArr[i] = Math.Min(MinNumArr[i],MinNumArr[i - coinArr[j]] + 1);
                }
            }
        }
        return MinNumArr[m];
    }
    public static int Compute2(int m, int[] coinArr)
    {
        int n = coinArr.Length;

        // Creating a 2D array to store the minimum number of coins needed for amounts i (0 to m)
        int[,] dp = new int[n + 1, m + 1];

        // Initialize the array with maximum value
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                dp[i, j] = int.MaxValue;
            }
        }

        // Base case: 0 coins needed for amount 0
        for (int i = 0; i <= n; i++)
        {
            dp[i, 0] = 0;
        }

        // Fill the dp array using bottom-up approach
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (coinArr[i - 1] <= j)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - coinArr[i - 1]] + 1);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                Console.Write(dp[i,j]+" ");
            }
            Console.WriteLine();
        }
        return dp[n, m] == int.MaxValue ? -1 : dp[n, m];
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         var result = ChangeMoney.Compute2(n, new int[] { 1, 2, 5 });
//         Console.WriteLine(result);
//     }
// }