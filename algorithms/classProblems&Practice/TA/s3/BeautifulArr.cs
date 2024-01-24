using System;

public static class BeautifulArray
{
    public static int MinChangesToBeautifulArray(int[] arr, int[] dp)
    {
        for (var i = arr.Length - 2; i >= 0; i--)
        {
            if (i + arr[i] < arr.Length)
            {
                dp[i] = Math.Min(i + arr[i] + 1 < arr.Length ? dp[i + arr[i] + 1] : 0, dp[i + 1] + 1);
            }
            else
            {
                dp[i] = dp[i + 1] + 1;
            }
        }
        return dp[0];
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int testCases = int.Parse(Console.ReadLine());
//         List<int> result = new List<int>();
//         for (int t = 0; t < testCases; t++)
//         {
//             int n = int.Parse(Console.ReadLine());
//             var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
//             int[] dp = new int[elements.Length];
//             dp[dp.Length - 1] = 1;
//             int changes = BeautifulArray.MinChangesToBeautifulArray(elements, dp);
//             result.Add(changes);
//         }
//         foreach (var item in result)
//         {
//             Console.WriteLine(item);
//         }
//     }
// }