public static class Bakht
{
    public static int ComputeProbability_Memo(int n, int m, int x, Dictionary<string, int> memo)
    {
        string key = n.ToString() + "," + x.ToString();
        if (memo.ContainsKey(key))
        {
            return memo[key];
        }
        if (n == 0)
        {
            if (x == 0)
                return 1;
            else
                return 0;
        }
        if (x < n || x > n * m)
        {
            return 0;
        }

        int sum = 0;
        for (var i = 1; i <= m; i++)
        {
            sum += ComputeProbability_Memo(n - 1, m, x - i, memo);
        }
        memo[key] = sum;
        return memo[key];
    }
    public static int ComputeProbability_Tabu(int n, int m, int x)
    {
        if (n == 0)
        {
            return (x == 0) ? 1 : 0;
        }

        if (x < n || x > n * m)
        {
            return 0;
        }

        int[,] dp = new int[n + 1, x + 1];


        for (int i = 0; i <= x; i++)
        {
            dp[0, i] = (i == 0) ? 1 : 0;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= x; j++)
            {
                for (int k = 1; k <= m; k++)
                {
                    if (j - k >= 0)
                    {
                        dp[i, j] += dp[i - 1, j - k];
                    }
                }
            }
        }

        return dp[n, x];
    }

    // public static void Main(string[] args)
    // {
    //     var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    //     var n = input[0];
    //     var m = input[1];
    //     var x = input[2];
    //     var result = ComputeProbabilityTabulation(n, m, x);
    //     var ans = result / Math.Pow(m, n);
    //     var ansArr = ans.ToString().Split('.').ToArray();

    //     Console.Write(ansArr[0]);
    //     Console.Write(".");
    //     if (ansArr.Length == 2)
    //     {
    //         if (ansArr[1].Length > 4)
    //             Console.Write(String.Join("", ansArr[1].Take(4).ToArray()));
    //         else
    //         {
    //             int delta = 4 - ansArr[1].Length;
    //             Console.Write(ansArr[1]);
    //             for (var i = 0; i < delta; i++)
    //             {
    //                 Console.Write("0");
    //             }
    //         }
    //     }
    //     else
    //     {
    //         for (var i = 0; i < 4; i++)
    //         {
    //             Console.Write("0");
    //         }
    //     }

    // }
}


