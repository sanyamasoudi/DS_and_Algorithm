using System;
using System.Linq;
using System.Collections.Generic;
public class FindPatternInText
{
    static int x = 235; static int p = 31;
    // public static void Main(string[] args)
    // {
    //     var p = Console.ReadLine();
    //     var s = Console.ReadLine();
    //     var result = RabinKarpAlgorithm(s, p);
    //     result.Sort();
    //     Console.WriteLine(String.Join(" ", result));
    // }
    public static List<int> RabinKarpAlgorithm(string str, string patern)
    {
        List<int> positions = new List<int>();
        var pHash = PolyHash(patern);
        var H = PreComputeHash(str, patern);
        for (var i = 0; i <= str.Length - patern.Length; i++)
        {
            if (pHash != H[i])
            {
                continue;
            }
            if (AreEqual(str.Substring(i, patern.Length), patern))
            {
                positions.Add(i);
            }
        }
        return positions;
    }

    private static long[] PreComputeHash(string str, string patern)
    {
        long[] H = new long[str.Length - patern.Length + 1];
        H[str.Length - patern.Length] = PolyHash(str.Substring(str.Length - patern.Length, patern.Length));
        long y = 1;
        for (var i = 0; i < patern.Length; i++)
        {
            y = y * x % p;
        }
        for (var i = str.Length - patern.Length - 1; i >= 0; i--)
        {
            H[i] = (((x * H[i + 1] + str[i] - str[i + patern.Length] * y) % p) + p) % p;
        }
        return H;
    }

    public static long PolyHash(string s)
    {
        long hash_value = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            hash_value = (hash_value * x + s[i]) % p;
        }
        return hash_value;
    }
    public static bool AreEqual(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return false;
        }
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                return false;
            }
        }
        return true;
    }
}