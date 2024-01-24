public static class AnalyzePrime
{
    public static List<int> ComputeAnalyzePrime(int n)
    {
        var result = new List<int>();
        while (n > 0)
        {
            if (n == 1)
            {
                result[result.Count - 1] += 1;
                n -= 1;
            }
            else
            {
                result.Add(2);
                n -= 2;
            }
        }
        return result.OrderDescending().ToList();
    }
    // public static List<int> ComputeAnalyzePrimeMain(int n)
    // {
    //     var result = new List<int>();
    //     while (n > 0)
    //     {
    //         if (n % 2 != 0)
    //         {
    //             result.Add(3);
    //             n -= 3;
    //         }
    //         else
    //         {
    //             result.Add(2);
    //             n -= 2;
    //         }
    //     }
    //     return result;
    // }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         var result = AnalyzePrime.ComputeAnalyzePrime(n);
//         Console.WriteLine(result.Count);
//         Console.WriteLine(String.Join(" ", result));
//     }
// }