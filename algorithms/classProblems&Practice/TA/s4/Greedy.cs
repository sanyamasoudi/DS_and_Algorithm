using System;
using System.Linq;

public class GreedyLose
{
    public static long MaxPoints_Tebu(int[] arr)
    {
        int n = arr.Length;
        if (n <= 3)
        {
            long sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        long[] dp1 = new long[n];
        long[] dp2 = new long[n];

        dp1[n - 1] = arr[n - 1];
        dp1[n - 2] = arr[n - 2] + arr[n - 1];
        dp1[n - 3] = arr[n - 3] + arr[n - 2] + arr[n - 1];

        for (int i = n - 4; i >= 0; i--)
        {
            dp1[i] = Math.Max(arr[i] + dp2[i + 1],
                                    Math.Max(arr[i] + arr[i + 1] + dp2[i + 2],
                                    arr[i] + arr[i + 1] + arr[i + 2] + dp2[i + 3]));

            if (dp1[i] == arr[i] + dp2[i + 1])
            {
                dp2[i] = dp1[i + 1];
            }
            else if (dp1[i] == arr[i] + arr[i + 1] + dp2[i + 2])
            {
                dp2[i] = dp1[i + 2];
            }
            else if (dp1[i] == arr[i] + arr[i + 1] + arr[i + 2] + dp2[i + 3])
            {
                dp2[i] = dp1[i + 3];
            }
        }
        return dp1[0];
    }
    public static long MaxPoints_Memo(int[] arr)
    {
        int n = arr.Length;
        if (n <= 3)
        {
            long sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }

        long[] dp1 = new long[n];
        long[] dp2 = new long[n];

        dp1[n - 1] = arr[n - 1];
        dp1[n - 2] = arr[n - 2] + arr[n - 1];
        dp1[n - 3] = arr[n - 3] + arr[n - 2] + arr[n - 1];

        long[] memo = new long[n]; 

        return MaxPointsHelper(arr, 0, dp1, dp2, memo);
    }

    private static long MaxPointsHelper(int[] arr, int i, long[] dp1, long[] dp2, long[] memo)
    {
        if (i >= arr.Length)
        {
            return 0;
        }


        if (memo[i] != 0)
        {
            return memo[i];
        }

        dp1[i] = Math.Max(arr[i] + MaxPointsHelper(arr, i + 1, dp1, dp2, memo),
                        Math.Max(arr[i] + arr[i + 1] + MaxPointsHelper(arr, i + 2, dp1, dp2, memo),
                                arr[i] + arr[i + 1] + arr[i + 2] + MaxPointsHelper(arr, i + 3, dp1, dp2, memo)));

        if (dp1[i] == arr[i] + MaxPointsHelper(arr, i + 1, dp1, dp2, memo))
        {
            dp2[i] = dp1[i + 1];
        }
        else if (dp1[i] == arr[i] + arr[i + 1] + MaxPointsHelper(arr, i + 2, dp1, dp2, memo))
        {
            dp2[i] = dp1[i + 2];
        }
        else if (dp1[i] == arr[i] + arr[i + 1] + arr[i + 2] + MaxPointsHelper(arr, i + 3, dp1, dp2, memo))
        {
            dp2[i] = dp1[i + 3];
        }

        memo[i] = dp1[i];
        return dp1[i];
    }
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     int[] prizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

    //     long result = MaxPoints(prizes);
    //     Console.WriteLine(result);
    // }
}
