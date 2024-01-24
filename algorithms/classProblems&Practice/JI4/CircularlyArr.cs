public static class CircularlyArr
{
    public static int[] Sort(int[] arr)
    {
        List<int> result = new();
        int minEleIndex = Array.IndexOf(arr, arr.Min());
        for (var i = minEleIndex; i < arr.Length; i++)
        {
            result.Add(arr[i]);
        }
        for (var i = 0; i < minEleIndex; i++)
        {
            result.Add(arr[i]);
        }
        return result.ToArray();
    }
    static int FindMin(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] < arr[right])
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        return arr[left];
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         var result = CircularlyArr.Sort(arr);
//         Console.WriteLine(String.Join(" ", result));
//     }
// }