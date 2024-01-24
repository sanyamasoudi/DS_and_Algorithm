public static class ChangeMoney
{
    // O(2^n)
    public static int ComputeDynamic(int money, int[] coinArr)
    {
        if (money == 0) return 0;
        int best = -1; int nextTry = 0;
        foreach (var item in coinArr)
        {
            if (item <= money)
            {
                nextTry = ComputeDynamic(money - item, coinArr);
            }
            if (best < 0 || best > nextTry + 1)
            {
                best = nextTry + 1;
            }
        }
        return best;
    }
    // O(m^n)
    public static int DPChange(int money, int[] coinArr)
    {
        var MaxValue = money + 1;
        var MinNumCoins = new int[MaxValue];

        // Initialize the array with a value larger than any possible minimum number of coins
        for (var i = 1; i < MaxValue; i++)
        {
            MinNumCoins[i] = MaxValue;
        }

        MinNumCoins[0] = 0;

        for (var m = 1; m <= money; m++)
        {
            for (var i = 0; i < coinArr.Length; i++)
            {
                if (m >= coinArr[i])
                {
                    // int numCoins = MinNumCoins[m - coinArr[i]] + 1;
                    // if (numCoins < MinNumCoins[m])
                    // {
                    //     MinNumCoins[m] = numCoins;
                    // }
                    MinNumCoins[m]=Math.Min(MinNumCoins[m],MinNumCoins[m-coinArr[i]]+1);
                }
            }
        }

        return MinNumCoins[money] > money ? -1 : MinNumCoins[money];
    }

    public static int RecursiveChange(int money, int[] coinArr)
    {
        if (money == 0) return 0;
        int minNumCoins = int.MaxValue;
        int numCoins = 0;
        for (var i = 0; i < coinArr.Length; i++)
        {
            if (money >= coinArr[i])
            {
                numCoins = RecursiveChange(money - coinArr[i], coinArr);
            }
            if (numCoins + 1 < minNumCoins)
            {
                minNumCoins = numCoins;
            }
        }
        return minNumCoins;
    }
    // O(n*m)
    public static int ComputeGreedy(int money, int[] coinArr)
    {
        int coinRequired = 0;
        Array.Sort(coinArr, (int x, int y) => y.CompareTo(x));
        foreach (var coin in coinArr)
        {
            while (money >= coin)
            {
                Console.Write(coin + " ");
                money -= coin;
                coinRequired++;
            }
        }
        return coinRequired;
    }
    // O(n)
    public static int GetChange2(int money, List<int> denomination)
    {
        denomination.Sort((int x, int y) => y.CompareTo(x));
        int count = 0;
        while (money > 0 && denomination.Count > 0)
        {
            if (money >= denomination[0])
            {
                money -= denomination[0];
                count++;
            }
            else
            {
                denomination.RemoveAt(0);
            }
        }
        return count;
    }
    /// O(n)
    public static int GetChange3(int money, List<int> denomination)
    {
        denomination.Sort((int x, int y) => y.CompareTo(x));
        int count = 0;
        for (var i = 0; i < denomination.Count; i++)
        {
            int x = money / denomination[i];
            money %= denomination[i];
            count += x;
        }
        return count;
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var money = int.Parse(Console.ReadLine());
//         var coinArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         //var result = ChangeMoney.ComputeDynamic(money, coinArr);
//         var result = ChangeMoney.DPChange(money, coinArr);
//         //var result2 = ChangeMoney.ComputeGreedy(money, coinArr);
//         //Console.WriteLine();
//         Console.WriteLine(result);
//     }
// }