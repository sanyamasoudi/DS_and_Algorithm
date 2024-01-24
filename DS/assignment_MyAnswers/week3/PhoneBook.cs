using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class PhoneBook
{
    static Dictionary<int,string> hm;
    static List<string> results;
    // public static void Main(string[] args)
    // {
    //     hm=new Dictionary<int, string>();
    //     results=new List<string>();
    //     int nQuery=int.Parse(Console.ReadLine());
    //     for (var i = 0; i < nQuery; i++)
    //     {
    //         var q=Console.ReadLine().Trim().Split().ToArray();
    //         switch (q[0])
    //         {
    //             case "add":
    //                 Add(int.Parse(q[1]),q[2]);
    //                 break;
    //             case "del":
    //                 Del(int.Parse(q[1]));
    //                 break;
    //             case "find":
    //                 Find(int.Parse(q[1]));
    //                 break;
    //         }
            
    //     }
    //     Console.WriteLine(String.Join("\n",results));
    // }

    private static void Find(int key)
    {
        if(!hm.ContainsKey(key))
        {
            results.Add("not found");
        }
        else
        {
            results.Add(hm[key]);
        }
    }

    private static void Del(int key)
    {
        hm.Remove(key);
    }

    private static void Add(int key, string value)
    {
        if(!hm.ContainsKey(key))
        {
            hm.Add(key,value);
        }
        else
        {
            hm[key]=value;
        }
    }
}