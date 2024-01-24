
public class Program2
{
    // public static void Main(string[] args)
    // {
    //     var r = getPairsCountBV(new int[] { 1,1,1,1}, 4, 2);
    //     Console.WriteLine(r);
    // }
    public static int getPairsCountBV(int[] arr, int n, int k)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (var i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(arr[i]))
                dict.Add(arr[i], 1);
            else
            {
                dict[arr[i]]++;
            }
        }
        int twice_count = 0;
        for (var i = 0; i < n; i++)
        {
            if (dict.ContainsKey(k - arr[i]))
                twice_count += dict[k - arr[i]];
            if (k - arr[i] == arr[i])
            {
                twice_count--;
            }
        }
        return twice_count / 2;
    }
    public static int getPairsCount(int[] arr, int n, int k)
    {
        HashSet<(int, int)> hash = new HashSet<(int, int)>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] >= k)
            {
                continue;
            }
            for (var j = 0; j < arr.Length; j++)
            {
                if (arr[j] == k - arr[i] && j != i && !hash.Contains((i, j)) && !hash.Contains((j, i)))
                {
                    hash.Add((i, j));
                }
            }
        }
        return hash.Count;
    }
}