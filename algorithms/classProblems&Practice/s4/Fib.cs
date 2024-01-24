public static class Fibc
{
    public static int LastDigitTeibo(int n)
    {
        int[] fibArr = new int[n + 1];
        if (fibArr.Length > 1) fibArr[1] = 1;
        for (var i = 2; i <= n; i++)
        {
            fibArr[i] = fibArr[i - 1] % 10 + fibArr[i - 2] % 10;
        }
        return fibArr[n] % 10;
    }
    public static int[] fibArr;
    public static int LastDigitMemo(int n)
    {
        if (n <= 1) return n;
        if (fibArr[n - 1] == 0)
        {
            fibArr[n - 1] = LastDigitMemo(n - 1) % 10;
            fibArr[n - 2] = LastDigitMemo(n - 2) % 10;
            fibArr[n] = fibArr[n - 1] + fibArr[n - 2];
        }
        return fibArr[n] % 10;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Fibc.fibArr = new int[n + 1];
        var result = Fibc.LastDigitMemo(n);
        Console.Write(result);
    }
}