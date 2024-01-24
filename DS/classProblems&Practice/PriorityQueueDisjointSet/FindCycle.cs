//{ Driver Code Starts
//Initial Template for C#

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverCode
{

    class GFG
    {
        // static void Main(string[] args)
        // {
        //     int testcases;// Taking testcase as input
        //     testcases = Convert.ToInt32(Console.ReadLine());
        //     while (testcases-- > 0)// Looping through all testcases
        //     {
        //         var ip = Console.ReadLine().Trim().Split(' ');
        //         int V = int.Parse(ip[0]);
        //         int E = int.Parse(ip[1]);
        //         List<List<int>> adj = new List<List<int>>();
        //         for (int i = 0; i < V; i++)
        //         {
        //             adj.Add(new List<int>());
        //         }
        //         for (int i = 0; i < E; i++)
        //         {
        //             ip = Console.ReadLine().Trim().Split(' ');
        //             int u = int.Parse(ip[0]);
        //             int v = int.Parse(ip[1]);
        //             adj[u].Add(v);
        //             adj[v].Add(u);
        //         }
        //         Solution obj = new Solution();
        //         var res = obj.detectCycle(V, ref adj);
        //         Console.WriteLine(res);

        //     }

        // }
    }
}
// } Driver Code Ends


//User function Template for C#
//User function Template for C#

class Solution
{
    int[] Parent;
    int[] Size;
    //Function to detect cycle using DSU in an undirected graph.
    public int detectCycle(int V, ref List<List<int>> adj)
    {
        Parent = new int[V];
        Size = new int[V];
        for (int i = 0; i < V; i++)
        {
            Parent[i] = i;
            Size[i] = 1;
        }
        for (int i = 0; i <V; i++)
        {
            foreach(var item in adj[i])
            {
                int irep = Find(i, Parent);
                int jrep = Find(item, Parent);
                if (irep == jrep && i<item)
                {
                    return 1;
                }
                Union(i,item);
            }
        }
        return 0;
    }

    public void Union(int i, int j)
    {
        int irep = Find(i, Parent);
        int jrep = Find(j, Parent);
        if(i!=j){
        if (Size[irep] < Size[jrep])
        {
            Parent[irep] = jrep;
            Size[jrep] += Size[irep];
        }
        else
        {
            Parent[jrep] = irep;
            Size[irep] += Size[jrep];
        }}
    }

    public int Find(int i, int[] Parent)
    {
        if (Parent[i] == i)
        {
            return i;
        }
        Parent[i] = Find(Parent[i], Parent);
        return Parent[i];
    }
}
