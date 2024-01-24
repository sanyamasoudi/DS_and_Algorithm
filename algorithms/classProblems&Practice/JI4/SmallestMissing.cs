public static class SmallestMissing
{
    public static int Compute(int[] arr)
    {
        int addedToIndex = arr[0];
        int left = 0; int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (mid + addedToIndex == arr[mid])
            {
                left = mid + 1;
            }
            else
            {
                if (mid + addedToIndex - 1 == arr[mid - 1])
                {
                    return mid + addedToIndex;
                }
                right = mid - 1;
            }
        }
        return arr[^1] + 1;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = SmallestMissing.Compute(arr);
//         Console.WriteLine(result);
//     }
// }