// using System;
// namespace Kadane
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             int[] arr = { 10, -10, 20, -40 };
//             int maxSum = Kadane(arr);
//             Console.WriteLine("Maximum contiguous sum is " + maxSum);
//         }
//         static int Kadane(int[] arr)
//         {
//             int maxSum = arr[0];
//             int currSum = arr[0];
//             for (int i = 1; i < arr.Length; i++)
//             {  
//                 currSum = Math.Max(arr[i], currSum + arr[i]);
//                 maxSum = Math.Max(maxSum, currSum);
//             }
//             return maxSum;
//         }
//     }
// }