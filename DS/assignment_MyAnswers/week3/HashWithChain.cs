using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public class HashWithChain
{
    static long x = 263;
    static long p = 1000000007;
    static long m;
    static List<string>[] chains;
    static List<string> results;
    // public static void Main(string[] args)
    // {
    //     int nChains = int.Parse(Console.ReadLine());
    //     int nQuery = int.Parse(Console.ReadLine());
    //     results = new List<string>();
    //     chains = new List<string>[nChains];
    //     for (var i = 0; i < nChains; i++)
    //     {
    //         chains[i] = new List<string>();
    //     }
    //     m = nChains;
    //     for (var i = 0; i < nQuery; i++)
    //     {
    //         var q = Console.ReadLine().Trim().Split().ToArray();
    //         switch (q[0])
    //         {
    //             case "add":
    //                 Add(q[1]);
    //                 break;
    //             case "del":
    //                 Del(q[1]);
    //                 break;
    //             case "find":
    //                 Find(q[1], true);
    //                 break;
    //             case "check":
    //                 Check(int.Parse(q[1]));
    //                 break;
    //         }

    //     }
    //     foreach (var item in results)
    //     {
    //         Console.WriteLine(item);
    //     }
    // }
    private static long PolyHash(string s)
    {
        long hash_value = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            hash_value = (hash_value * x + s[i]) % p;
        }
        return hash_value % m;
    }
    private static void Check(int k)
    {
        var hashV = k;
        var chain = chains[hashV];
        var s = "";
        for (var i = chain.Count - 1; i >= 0; i--)
        {
            s += chain[i];
            s += " ";
        }
        results.Add(s);
    }

    private static bool Find(string k, bool FindFuncIsCall)
    {
        var hashV = PolyHash(k);
        var chain = chains[hashV];
        for (var i = 0; i < chain.Count; i++)
        {
            if (chain[i] == k && FindFuncIsCall)
            {
                results.Add("yes");
                return true;
            }
            else if (chain[i] == k)
            {
                return true;
            }
        }
        if (FindFuncIsCall)
        {
            results.Add("no");
        }
        return false;
    }

    private static void Del(string k)
    {
        if (Find(k, false))
        {
            var hashV = PolyHash(k);
            var chain = chains[hashV];
            for (var i = 0; i < chain.Count; i++)
            {
                if (chain[i] == k)
                {
                    chain.RemoveAt(i);
                }
            }
        }
    }

    private static void Add(string k)
    {
        if (!Find(k, false))
        {
            var hashV = PolyHash(k);
            chains[hashV].Add(k);
        }
    }
}