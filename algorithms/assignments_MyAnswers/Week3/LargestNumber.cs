using System;
using System.Linq;
public class LargestNumber
{
    public static string FindLargestNumber(string[] a)
    {
        var result = "";
        int[] nums = new int[a.Length];
        for (var i = 0; i < a.Length; i++)
        {
            nums[i] = int.Parse(a[i]);
        }
        while (nums.Length > 0)
        {
            int maxNum = 0;
            foreach (var item in nums)
            {
                if (item.ToString().Length == maxNum.ToString().Length && item >= maxNum)
                {
                    maxNum = item;
                }
                else
                {
                    if (IsBetter(item, maxNum)) maxNum = item;
                }
            }
            result += maxNum;
            nums = nums.Where((_, i) => i != Array.IndexOf(nums, maxNum)).ToArray();
        }
        return result;
    }

    private static bool IsBetter(int v1, int v2)
    {
        if (int.Parse(v1.ToString() + v2.ToString()) > int.Parse(v2.ToString() + v1.ToString()))
        {
            return true;
        }
        return false;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         string[] numbers=Console.ReadLine().Split(' ');
//         Console.WriteLine(LargestNumber.FindLargestNumber(numbers));
//     }
// }