using System;
using System.Collections.Generic;
using System.Linq;

public class FractionalKnapsack
{
    //O(nlogn)
    public static double GetOptimalValue2(int capacity, int[] values, int[] weights)
    {
        double totalValue = 0;
        var valuePerUnit = new List<Tuple<double, int>>();
        for (var i = 0; i < values.Length; i++)
        {
            valuePerUnit.Add(Tuple.Create((double)values[i] / (double)weights[i], i));
        }
        valuePerUnit = valuePerUnit.OrderByDescending(x => x.Item1).ToList();//O(nlogn)
        for (var i = 0; i < valuePerUnit.Count; i++)//O(n)
        {
            if (capacity == 0) return totalValue;
            var indexBestItem = valuePerUnit[i].Item2;
            var a = Math.Min(weights[indexBestItem], capacity);
            totalValue += a * (double)((double)values[indexBestItem] / (double)(weights[indexBestItem]));
            capacity -= a;
        }
        return totalValue;
    }
    public static double GetOptimalValue(int capacity, int[] values, int[] weights)
    {
        List<double> valuePerWeight = new List<double>();
        for (int i = 0; i < values.Length; i++)
        {
            double vpw = (double)values[i] / weights[i];
            valuePerWeight.Add(vpw);
        }

        var sortedValuePerWeight = valuePerWeight.Select((vpw, index) => new { Vpw = vpw, Index = index })
        .OrderByDescending(x => x.Vpw);

        double totalValue = 0;
        foreach (var item in sortedValuePerWeight)
        {
            int currentItemIndex = item.Index;
            int currentWeight = Math.Min(capacity, weights[currentItemIndex]);
            totalValue += currentWeight * item.Vpw;

            capacity -= currentWeight;
            if (capacity == 0)
                break;
        }

        return totalValue;
    }
}


// public class Program
// {
//     public static void Main()
//     {
//         string[] lineOne = Console.ReadLine().Split(' ');
//         int n = int.Parse(lineOne[0]);
//         int capacity = int.Parse(lineOne[1]);
//         int[] values = new int[n];
//         int[] weights = new int[n];
//         for (int i = 0; i < n; i++)
//         {
//             string[] newLine = Console.ReadLine().Split(' ');
//             values[i] = int.Parse(newLine[0]);
//             weights[i] = int.Parse(newLine[1]);
//         }
//         Console.WriteLine(FractionalKnapsack.GetOptimalValue2(capacity, values, weights));
//     }
// }