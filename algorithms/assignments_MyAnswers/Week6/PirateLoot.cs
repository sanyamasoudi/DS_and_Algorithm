using System;

public class PirateLootSplitting
{
    public static bool CanSplitIntoThree(int[] values)
    {
        int total = 0;
        foreach (int value in values)
        {
            total += value;
        }

        if (total % 3 != 0)
        {
            return false;
        }

        return CanPartition(values, 0, 0, 0, 0, total / 3);
    }

    private static bool CanPartition(int[] values, int index, int sum1, int sum2, int sum3, int target)
    {
        if (index == values.Length)
        {
            return sum1 == sum2 && sum2 == sum3;
        }

        if (sum1 > target || sum2 > target || sum3 > target)
        {
            return false;
        }

        return CanPartition(values, index + 1, sum1 + values[index], sum2, sum3, target) ||
               CanPartition(values, index + 1, sum1, sum2 + values[index], sum3, target) ||
               CanPartition(values, index + 1, sum1, sum2, sum3 + values[index], target);
    }

    // public static void Main()
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     string[] input = Console.ReadLine().Split(' ');
    //     int[] values = new int[n];

    //     for (int i = 0; i < n; i++)
    //     {
    //         values[i] = int.Parse(input[i]);
    //     }

    //     int result = CanSplitIntoThree(values) ? 1 : 0;
    //     Console.WriteLine(result);
    // }
}
