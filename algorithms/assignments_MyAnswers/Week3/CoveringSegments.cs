using System;
using System.Linq;
using System.Collections.Generic;
public class CoveringSegments
{

    // public static int[] OptimalPoints(Segment[] segments)
    // {
    //     //write your code here
    //     var result = new List<int>();
    //     int[] points = new int[2 * segments.Length];
    //     for (int i = 0; i < segments.Length; i++)
    //     {
    //         points[2 * i] = segments[i].start;
    //         points[2 * i + 1] = segments[i].end;
    //     }
    //     for (var i = 1; i < points.Length - 1; i += 2)
    //     {
    //         if (i + 3 < points.Length)
    //         {
    //             if (points[i] == points[i + 3])
    //             {
    //                 result.Add(points[i]);
    //                 break;
    //             }
    //         }
    //         if (points[i + 1] <= points[i] && points[i] <= points[i + 2])
    //         {
    //             result.Add(points[i]);
    //         }
    //     }
    //     return result.ToArray();
    // }
    //O(nlog n)
    public static int[] OptimalPoints(Segment[] segments)
    {
        var points=new List<int>();
        segments=segments.OrderBy(x=>x.end).ToArray();//O(nlog n)
        int currentPoint=segments[0].end;
        points.Add(currentPoint);
        for (int i = 1; i < segments.Length; i++)//O(n)
        {
            if (currentPoint < segments[i].start || currentPoint > segments[i].end)
            {
                currentPoint = segments[i].end;
                points.Add(currentPoint);
            }
        }

        return points.ToArray();
    }


}
public class Segment
{
    public int start, end;

    public Segment(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         Segment[] segmentArr=new Segment[n];
//         for (var i = 0; i < n; i++)
//         {
//             var inputArr=Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
//             var segment = new Segment(inputArr[0],inputArr[1]);
//             segmentArr[i]=segment;
//         }
//         var output=CoveringSegments.OptimalPoints(segmentArr);
//         Console.WriteLine(output.Length);
//         foreach (var item in output)
//         {
//             Console.Write($"{item} ");
//         }
//     }
// }