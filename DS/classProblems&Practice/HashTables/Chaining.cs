
#region ChainingWithSet
public class ChainingWithSet
{
    //memoryComplexity teta(m+n) --> m:number of chains(hashs needed) / n:number of pairs (key,value)
    static List<int>[] Chains;
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     Chains = new List<(int, int)>[n];
    //     for (var i = 0; i < n; i++)
    //     {
    //         Chains[i] = new List<(int, int)>();
    //     }
    //     for (var x = 1980; x < 1995; x++)
    //     {
    //         int d = h(x);
    //         Chains[d].Add((d, x));
    //     }
    //     var result = HasKey(2);
    //     Set(9, 9);
    //     Console.WriteLine(result);
    // }
    public static int h(int x)
    {
        int d = x;
        return d % 10;
    }
    public static void Remove(int Object)
    {
        if (!Find(Object))
        {
            return;
        }
        var chain = Chains[h(Object)];
        chain.Remove(Object);
    }
    public static void Add(int Object, int value)
    {
        var chain = Chains[h(Object)];
        for (var i = 0; i < Chains.Length; i++)
        {
            if (chain[i] == Object)
            {
                return;
            }
        }
        chain.Add(value);
    }
    // teta(c+1) ..runtimeComplexity
    public static bool Find(int Object)
    {
        var chain = Chains[h(Object)];
        foreach (var item in chain)
        {
            if (item == Object)
            {
                return true;
            }
        }
        return false;
    }
}
#endregion
#region ChainingWithMap
public class ChainingWithMap
{
    //memoryComplexity teta(m+n) --> m:number of chains(hashs needed) / n:number of pairs (key,value)
    static List<(int, int)>[] Chains;
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     Chains = new List<(int, int)>[n];
    //     for (var i = 0; i < n; i++)
    //     {
    //         Chains[i] = new List<(int, int)>();
    //     }
    //     for (var x = 1980; x < 1995; x++)
    //     {
    //         int d = h(x);
    //         Chains[d].Add((d, x));
    //     }
    //     var result = HasKey(2);
    //     Set(9, 9);
    //     Console.WriteLine(result);
    // }
    public static int h(int x)
    {
        int d = x;
        return d % 10;
    }
    public static int? Get(int Object)
    {
        var chain = Chains[h(Object)];
        foreach (var item in chain)
        {
            if (item.Item1 == Object)
            {
                return item.Item2;
            }
        }
        return null;
    }
    public static void Set(int Object, int value)
    {
        var chain = Chains[h(Object)];
        for (var i = 0; i < Chains.Length; i++)
        {
            if (chain[i].Item1 == Object)
            {
                var old = chain[i];
                chain.RemoveAt(i);
                chain.Add((old.Item1, value));
                return;
            }
        }
        chain.Add((Object, value));
    }
    // teta(c+1) ..runtimeComplexity
    public static bool HasKey(int Object)
    {
        var chain = Chains[h(Object)];
        foreach (var item in chain)
        {
            if (item.Item1 == Object)
            {
                return true;
            }
        }
        return false;
    }
}
#endregion