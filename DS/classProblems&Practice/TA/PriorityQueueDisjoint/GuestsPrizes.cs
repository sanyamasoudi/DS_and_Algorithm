public class GuestsPrizes2
{
    static int[] Parent;
    static int[] Size;



    public static void Main2(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var prizes = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        MakeAllSet(n);
        for (var i = 0; i < n; i++)
        {
            Union(i,arr[i]-1);
        }
        int[] AllSum=new int[n];
        
        for (var i = 0; i < n; i++)
        {
            var p=Find(i);
            AllSum[p]+=prizes[i];
        }
        AllSum=AllSum.Where(e=>e!=0).ToArray();
        Array.Sort(AllSum);
        Console.WriteLine(String.Join("\n", AllSum));
    }

    private static void Union(int i, int j)
    {
        int irep = Find(i);
        int jrep = Find(j);
        if(irep==jrep) return;

        if (Size[irep] > Size[jrep])
        {
            Parent[jrep] = irep;
            Size[irep] += Size[jrep];
        }
        else 
        {
            Parent[irep] = jrep;
            Size[jrep] += Size[irep];
        }

    }

    private static int Find(int item)
    {
        if (item == Parent[item]) return item;
        Parent[item] = Find(Parent[item]);
        return Parent[item];
    }

    private static void MakeAllSet(int n)
    {
        Parent = new int[n];
        Size = new int[n];
        for (var i = 0; i < n; i++)
        {
            Parent[i] = i;
            Size[i] = 1;
        }
    }
}