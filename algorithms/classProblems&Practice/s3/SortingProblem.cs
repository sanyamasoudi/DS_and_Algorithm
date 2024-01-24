public static class SortingProblem
{
    // any comparison based sorting algorithm performs omega(nlogn) comparisons in worst case to sort n objects
    // has at least n! leaves
    // the worst case running time of algorithm is at least depth d
    // 2^d >= l
    // log2(n!)=Omega(nlogn)
    //O(n^2) ...Comparison based
    public static int[] SelectionSort(this int[] arr)
    {
        int start = 0;
        int min = 0;
        while (start < arr.Length)
        {
            min = FindMin(arr, start);
            arr = Swap(start, Array.IndexOf(arr, min), arr);
            start++;
        }
        return arr;
    }
    // O(nlogn) ...Comparison based
    // T(n) = 2T(n/2) + O(n)
    public static int[] MergeSort(this int[] arr)
    {
        if (arr.Length == 1) return arr;
        int m = arr.Length / 2;
        var B = MergeSort(arr.Where((_, i) => i < m).ToArray());
        var C = MergeSort(arr.Where((_, i) => m <= i).ToArray());
        int[] arrprin = Merge(B, C);
        return arrprin;
    }
    // ...Non Comparison based
    public static int[] CountSort(this int[] arr, int m)
    {
        var Count = new int[m];
        for (var i = 0; i < arr.Length; i++)
        {
            Count[arr[i]] += 1;
        }
        var Pos = new int[m];
        for (var j = 2; j < Pos.Length; j++)
        {
            Pos[j] = Pos[j - 1] + Count[j - 1];
        }
        var arrPrin = new int[m];
        for (var i = 0; i < arr.Length; i++)
        {
            arrPrin[Pos[arr[i]]] = arr[i];
            Pos[arr[i]]++;
        }
        return arrPrin;
    }
    // O(nlogn) ...Comparison based
    public static int[] QuickSortRecurs(this int[] arr, int l, int r)
    {
        if (l >= r) return arr;
        int m = Partition(arr, l, r);
        QuickSortRecurs(arr, l, m - 1);
        QuickSortRecurs(arr, m + 1, r);
        return arr;
    }
    public static int[] QuickSort3(this int[] arr, int l, int r)
    {
        if (l >= r) return arr;
        var (m1, m2) = Partition4(arr, l, r);
        QuickSort3(arr, l, m1);
        QuickSort3(arr, m2 + 1, r);
        return arr;
    }
    private static (int m1, int m2) Partition4(int[] arr, int l, int r)
    {
        int value = arr[l];
        int i = l;
        while (i <= r)
        {
            if (arr[i] == value)
            {
                i++;
            }
            else if (arr[i] < value)
            {
                Swap(l, i, arr);
                i++;
                l++;
            }
            else
            {
                Swap(r, i, arr);
                r--;
            }
        }
        return (l, r);
    }

    // private static (int m1, int m2) Partition3(int[] arr, int l, int r)
    // {
    //     int x = arr[l];
    //     int j2 = l;
    //     int c = 0;
    //     int j1;
    //     for (var i = l + 1; i <= r; i++)
    //     {
    //         if (arr[i] <= x)
    //         {
    //             j2++;
    //             arr = Swap(j2, i, arr);
    //         }
    //         if (arr[i] == x)
    //         {
    //             c++;
    //         }
    //     }
    //     j1 = j2 - c;
    //     arr = Swap(l, j2, arr);
    //     return (j1, j2);
    // }

    public static int[] QuickSortIterative(this int[] arr, int l, int r)
    {
        while (r > l)
        {
            int m = Partition(arr, l, r);
            if (m - l < r - m)
            {
                QuickSortIterative(arr, l, m - 1);
                l = m + 1;
            }
            else
            {
                QuickSortIterative(arr, m + 1, r);
                r = m - 1;
            }
        }
        return arr;
    }
    public static int[] RandomizedQuickSort(this int[] arr, int l, int r)
    {
        if (l >= r) return arr;
        Random rand = new();
        int k = rand.Next(l, r);
        arr = Swap(l, k, arr);
        int m = Partition(arr, l, r);
        RandomizedQuickSort(arr, l, m - 1);
        RandomizedQuickSort(arr, m + 1, r);
        return arr;
    }
    private static int Partition(int[] arr, int l, int r)
    {
        int x = arr[l];
        int j = l;
        for (var i = l + 1; i <= r; i++)
        {
            if (arr[i] <= x)
            {
                j++;
                arr = Swap(j, i, arr);
            }
        }
        arr = Swap(l, j, arr);
        return j;
    }

    private static int[] Merge(int[] b, int[] c)
    {
        var result = new List<int>();
        while (b.Length != 0 && c.Length != 0)
        {
            if (b[0] <= c[0])
            {
                result.Add(b[0]);
                b = b.Where((_, i) => i != 0).ToArray();
            }
            else
            {
                result.Add(c[0]);
                c = c.Where((_, i) => i != 0).ToArray();
            }
        }
        foreach (var item in b)
        {
            result.Add(item);
        }
        foreach (var item in c)
        {
            result.Add(item);
        }
        return result.ToArray();
    }
    private static int[] Merge2(int[] b, int[] c)
    {
        var result = new List<int>();
        int i = 0, j = 0;
        while (i < b.Length && j < c.Length)
        {
            if (b[i] <= c[j])
            {
                result.Add(b[i]);
                i++;
            }
            else
            {
                result.Add(c[j]);
                j++;
            }
        }
        while (i < b.Length)
        {
            result.Add(b[i]);
            i++;
        }
        while (j < c.Length)
        {
            result.Add(c[j]);
            j++;
        }
        return result.ToArray();
    }
    private static int[] Swap(int v1, int v2, int[] arr)
    {
        var v3 = arr[v1];
        arr[v1] = arr[v2];
        arr[v2] = v3;
        return arr;
    }

    private static int FindMin(int[] arr, int startIndex)
    {
        int min = int.MaxValue;
        for (int i = startIndex; i < arr.Length; i++)
        {
            min = Math.Min(min, arr[i]);
        }
        return min;
    }
}