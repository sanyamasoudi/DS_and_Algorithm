public static class CountElements
{
    public static int Compute(int[] arr, int q)
    {
        Array.Sort(arr);
        var result=ComputeRightIndex(arr,q)-ComputeLeftIndex(arr,q)+1;
        return result;
    }
    private static int ComputeLeftIndex(int[] arr, int q)
    {
        int left = 0; int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (q == arr[mid])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }
    private static int ComputeRightIndex(int[] arr, int q)
    {
        int left = 0; int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (q == arr[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return right;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         var result = CountElements.Compute(new int[] { 1, 3, 3, 3, 5, 9, 9 }, 3);
//         Console.WriteLine(result);
//     }
// }