public static class DuplicateSearch
{
    public static bool Compute(int[] arr)
    {
        Array.Sort(arr);
        for (var i = 0; i < arr.Length; i++)
        {
            if (ComputeRightIndex(arr, arr[i]) > ComputeLeftIndex(arr, arr[i])) return true;
        }
        return false;
    }
    public static bool HasDuplicates(int[] nums)
    {
        // var set = new HashSet<int>();
        // foreach (int num in nums)
        // {
        //     if (!set.Add(num))
        //     {
        //         return true;
        //     }
        // }
        // return false;
        var set = new HashSet<int>();
        foreach (int num in nums)
        {
            if (set.Contains(num))
            {
                return true;
            }
            set.Add(num);
        }
        return false;
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
//         var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         //var result = DuplicateSearch.Compute(arr);
//         var result2 = DuplicateSearch.HasDuplicates(arr);
//         Console.WriteLine(result2);
//     }
// }