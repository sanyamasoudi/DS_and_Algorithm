public static class SMTree
{
    static long[] factlArr;
    public static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine());
        var arr = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
        factlArr = new long[n+1]; factlArr[0] = 1;
        ALLFactorial(n);
        var result = Premutation(arr);
        Console.WriteLine(result);
    }

    private static void ALLFactorial(long n)
    {
        for (var i = 1; i <= n; i++)
        {
            factlArr[i] = factlArr[i - 1] * i;
        }
    }
    private static long Premutation(long[] arr)
    {
        long n = arr.Length;
        if (arr.Length <= 2)
        {
            return 1;
        }
        var root = arr[0];
        List<long> left = new List<long>();
        List<long> right = new List<long>();
        for (var i = 1; i < arr.Length; i++)
        {
            if (root > arr[i])
            {
                left.Add(arr[i]);
            }
            else
            {
                right.Add(arr[i]);
            }
        }
        long r = left.Count;
        var rCount = Premutation(right.ToArray());
        var lCount = Premutation(left.ToArray());
        return Tarkib(n - 1, r) * rCount * lCount;
    }

    private static long Tarkib(long n, long r)
    {
        if (r > n) return 0;
        return (long)(factlArr[n] / (factlArr[r] * factlArr[n - r]));
    }
}
