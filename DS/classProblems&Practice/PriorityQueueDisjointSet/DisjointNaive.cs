// public class Program
// {
//     public static void Main(string[] args)
//     {

//     }
// }
public class DisjointLinkList
{
    LinkedList<int> smallest;
    public DisjointLinkList(int n)
    {
        smallest = new LinkedList<int>();
    }
    public void MakeSet(int i)
    {
        smallest.AddLast(i);
    }
    public int Find(int i) => smallest.ElementAt(i);
    public void Union(LinkedList<int> i, LinkedList<int> j)
    {
        if(i.Last.Value>j.Last.Value)
        {
            j.AddAfter(i.Last,i.Last.Value);
        }
        else
        {
            i.AddAfter(j.Last,j.Last.Value);
        }
    }
}
public class DisjointArr
{
    int[] smallest;
    public DisjointArr(int n)
    {
        smallest = new int[n];
    }
    public void MakeSet(int i)
    {
        smallest[i] = i;
    }
    public int Find(int i) => smallest[i];
    public void Union(int i, int j)
    {
        int i_id = Find(i);
        int j_id = Find(j);
        if (i_id == j_id)
        {
            return;
        }
        int m = Math.Min(i_id, j_id);
        for (var k = 0; k < smallest.Length; k++)
        {
            if (smallest[k] == i_id || smallest[k] == j_id)
            {
                smallest[k] = m;
            }
        }
    }
}
