

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         GuestsPrizes gp=new GuestsPrizes(9);
//         var arr=new int[9]{6,4,4,4,5,6,9,6,4};
//         gp.PreProcess(arr);
//         gp.UnionByRank(4,6);
//     }
// }
public class GuestsPrizes
{
    int[] Parent;
    int[] Rank;
    int[] Size;
    public GuestsPrizes(int n)
    {
        Parent = new int[n+1];
        Rank = new int[n+1];
        Size = new int[n+1];
    }
    public void PreProcess(int[] arr)
    {
        for (var i = 1; i <= arr.Length; i++)
        {
            MakeSet(i);
        }
        foreach (var i in arr)
        {
            foreach (var n in neighbor(i, arr))
            {
                UnionByRank(n,i);
            }
        }
    }

    private List<int> neighbor(int key, int[] arr)
    {
        List<int> result = new List<int>();
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
            {
                result.Add(i+1);
            }
        }
        return result;
    }

    public void MakeSet(int i)
    {
        Parent[i] = i;
        Rank[i] = 0;
    }

    public int Find(int i)
    {
        if (Parent[i] == i)
        {
            return i;
        }
        int result = Find(Parent[i]);
        Parent[i] = result;
        return result;
    }
    public void UnionByRank(int i, int j)
    {
        // Find the representatives (or the root nodes)
        // for the set that includes i
        int irep = this.Find(i);

        // And do the same for the set that includes j
        int jrep = this.Find(j);

        // Elements are in same set, no need to
        // unite anything.
        if (irep == jrep)
            return;

        // Get the rank of i’s tree
        int irank = Rank[irep];

        // Get the rank of j’s tree
        int jrank = Rank[jrep];

        // If i’s rank is less than j’s rank
        if (irank < jrank)
        {

            // Then move i under j
            this.Parent[irep] = jrep;
        }

        // Else if j’s rank is less than i’s rank
        else if (jrank < irank)
        {

            // Then move j under i
            this.Parent[jrep] = irep;
        }

        // Else if their ranks are the same
        else
        {

            // Then move i under j (doesn’t matter
            // which one goes where)
            this.Parent[irep] = jrep;

            // And increment the result tree’s
            // rank by 1
            Rank[jrep]++;
        }
    }

    void unionbysize(int i, int j)
    {

        // Find the representatives (or the root nodes)
        // for the set that includes i
        int irep = this.Find(i);

        // And do the same for the set that includes j
        int jrep = this.Find(j);

        // Elements are in same set, no need to
        // unite anything.
        if (irep == jrep)
            return;

        // Get the size of i’s tree
        int isize = Size[irep];

        // Get the size of j’s tree
        int jsize = Size[jrep];

        // If i’s size is less than j’s size
        if (isize < jsize)
        {

            // Then move i under j
            this.Parent[irep] = jrep;

            // Increment j's size by i'size
            Size[jrep] += Size[irep];
        }

        // Else if j’s rank is less than i’s rank
        else if (jsize < isize)
        {

            // Then move j under i
            this.Parent[jrep] = irep;

            // Increment i's size by j'size
            Size[irep] += Size[jrep];
        }

        // Else if their ranks are the same
        else
        {

            // Then move i under j (doesn’t matter
            // which one goes where)
            this.Parent[irep] = jrep;

            // Increment j's size by i'size
            Size[jrep] += Size[irep];
        }
    }
}