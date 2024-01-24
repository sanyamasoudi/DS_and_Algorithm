public static class MedianOfSortArr
{
    public static int Compute(int[] a, int[] b)
    {
        var result = new int[a.Length + b.Length];
        int i = 0; int j = 0; int k = 0;
        while (i < a.Length && j < b.Length)
        {
            if (a[i] < b[j])
            {
                result[k] = a[i];
                k++; i++;
            }
            else
            {
                result[k] = b[j];
                k++; j++;
            }
        }
        return result[(result.Length - 1) / 2];
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         var result = MedianOfSortArr.Compute(new int[] { 1, 4, 7 }, new int[] { 2, 3, 5 });
//         Console.WriteLine(result);
//     }
// }