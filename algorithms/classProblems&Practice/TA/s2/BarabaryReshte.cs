using System;
using System.Linq;
public class Reshte
{
    public static string Compute(string a, string b)
    {
        if (a == b) return "YES";
        if (a.Length == 1 && b.Length == 1 && a != b)
        {
            return "NO";
        }
        if (a.Length % 2 == 0 && b.Length % 2 == 0)
        {
            int n = a.Length / 2;
            var Lefta = a.Substring(0, n);
            var righta = a.Substring(n, n);
            var Leftb = b.Substring(0, n);
            var rightb = b.Substring(n, n);
            var s = Compute(Lefta, rightb);
            var e = Compute(righta, Leftb);
            var s2 = Compute(Lefta, Leftb);
            var e2 = Compute(righta, rightb);
            if ((s == "YES" && e == "YES") || (s2 == "YES" && e2 == "YES"))
            {
                return "YES";
            }
            else return "NO";
        }
        return "NO";
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         var a = Console.ReadLine();
//         var b = Console.ReadLine();
//         var result = Reshte.Compute(a, b);
//         Console.WriteLine(result);
//     }
// }