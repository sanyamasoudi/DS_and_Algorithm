using System;
using System.Collections.Generic;
using System.Linq;
public class CarFueling
{
    public static int ComputeMinRefills(int dist, int tank, int[] stops)
    {
        int numRefill = 0;
        int currentRefill = 0;
        int n=stops.Length;
        List<int> stops2 = new List<int>
        {
            0
        };
        stops2.AddRange(stops);
        stops2.Add(dist);
        stops = stops2.ToArray();
        while (currentRefill <= n)
        {
            int lastRefill = currentRefill;
            while (currentRefill <= n && stops[currentRefill + 1] - stops[lastRefill] <= tank)
            {
                currentRefill++;
            }
            if (currentRefill == lastRefill)
            {
                return -1;
            }
            if (currentRefill <= n)
            {
                numRefill++;
            }
        }
        return numRefill;
    }


}
// public class Program
// {
//     public static void Main()
//     {
//         int dist = int.Parse(Console.ReadLine());
//         int tank = int.Parse(Console.ReadLine());
//         int nStops = int.Parse(Console.ReadLine());
//         int[] stops = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//         var ans = CarFueling.ComputeMinRefills(dist, tank, stops);
//         Console.WriteLine(ans);
//     }
// }