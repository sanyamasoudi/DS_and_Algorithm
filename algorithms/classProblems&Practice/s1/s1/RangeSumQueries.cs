// public class RangeSumQueries
// {
//     public int Sum(List<int> Numbers, List<List<int>> ranges)
//     {
//         int sum = 0;
//         for (var i = 0; i < ranges.Count; i++)
//         {
//             for (var j = 0; j < ranges[i].Count; j++)
//             {
//                 sum+=Numbers[ranges[i][j]];
//             }
//         }
//         return sum;
//     }
// }
using System;

public class RangeSumQueries {
    public void Sum() {
        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int[,] ranges = {{0, 4}, {2, 6}, {1, 8}};
        int n = arr.Length;
        int q = ranges.GetLength(0);
        int[] prefixSum = new int[n];
        prefixSum[0] = arr[0];
        for (int i = 1; i < n; i++) {
            prefixSum[i] = prefixSum[i - 1] + arr[i];
        }
        for (int i = 0; i < q; i++) {
            int l = ranges[i, 0];
            int r = ranges[i, 1];
            int sum = prefixSum[r] - prefixSum[l] + arr[l];
            Console.WriteLine("Sum of range ({0}, {1}): {2}", l, r, sum);
        }
    }
}
