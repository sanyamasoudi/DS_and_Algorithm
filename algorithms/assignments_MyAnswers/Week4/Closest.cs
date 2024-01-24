using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
public static class Closest
{
    public static double MinimalDistance(Point[] points, int n)
    {
        int mid = n / 2;
        Point midPoint = points[mid];
        if (n <= 3)
        {
            return BruteForceMinimalDistance(points, n);
        }
        var left = MinimalDistance(points.Take(mid).ToArray(), mid);
        var right = MinimalDistance(points.Skip(mid).ToArray(), n - mid);
        double d = Math.Min(left, right);
        Point[] strip = points.Where(p => Math.Abs(p.x - midPoint.x) < d).ToArray();
        return Math.Min(d, StripClosest(strip, strip.Length, d));
    }
    static double StripClosest(Point[] strip, int size, double d)
    {
        double min = d;
        Array.Sort(strip, CompareBaseY);
        for (int i = 0; i < size; ++i)
            for (int j = i + 1; j < size && (strip[j].y - strip[i].y) < min; ++j)
                if (Dist(strip[i], strip[j]) < min)
                    min = Dist(strip[i], strip[j]);
        return min;
    }
    static double BruteForceMinimalDistance(Point[] P, int n)
    {
        double min = double.MaxValue;
        for (int i = 0; i < n; ++i)
            for (int j = i + 1; j < n; ++j)
                if (Dist(P[i], P[j]) < min)
                    min = Dist(P[i], P[j]);
        return min;
    }
    private static double Dist(Point p1, Point p2)
    {
        return Math.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));
    }
    public static int CompareBaseX(Point p1, Point p2)
    {
        return p1.x.CompareTo(p2.x);
    }
    private static int CompareBaseY(Point p1, Point p2)
    {
        return p1.y.CompareTo(p2.y);
    }
}
public class Point
{
    public long x, y;

    public Point(long x, long y)
    {
        this.x = x;
        this.y = y;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         Point[] points = new Point[n];
//         for (var i = 0; i < n; i++)
//         {
//             var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
//             points[i] = new Point(p[0], p[1]);
//         }
//         Array.Sort(points, Closest.CompareBaseX);
//         var result = Closest.MinimalDistance(points, points.Length);
//         Console.WriteLine(result);
//     }
// }