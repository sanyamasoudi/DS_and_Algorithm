
public static class Sorting
{
    public static int[] InsertionSorting(int[] array)
    {
        int n = array.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
        return array;
    }
    public static int[] BasicSorting(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; ++i)
        {
            for (int j = i + 1; j < n; ++j)
            {
                if (array[i] > array[j])
                {
                    (array[j], array[i]) = (array[i], array[j]);
                }
            }
        }
        return array;
    }
    public static int[] SelectionSort(int[] array)
    {
        int startIndex = 0;
        while (startIndex < array.Length)
        {
            int min = FindMin(startIndex, array);
            (array[startIndex], array[Array.IndexOf(array, min)]) = (array[Array.IndexOf(array, min)], array[startIndex]);
            startIndex++;
        }
        return array;
    }

    private static int FindMin(int startIndex, int[] array)
    {
        int min = int.MaxValue;
        for (var i = startIndex; i < array.Length; i++)
        {
            min = Math.Min(min, array[i]);
        }
        return min;
    }
    public static int[] MergeSort(int[] array)
    {
        if (array.Length == 1) return array;
        int mid = array.Length / 2;
        var B = MergeSort(array.Take(mid).ToArray());
        var C = MergeSort(array.Skip(mid).ToArray());
        // var B = MergeSort(array.Where((_, i) => i < mid).ToArray());
        // var C = MergeSort(array.Where((_, i) => i >= mid).ToArray());
        var result = Merge(B, C);
        return result;
    }

    private static int[] Merge(int[] b, int[] c)
    {
        int[] result = new int[b.Length + c.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        while (i < b.Length && j < c.Length)
        {
            if (b[i] < c[j])
            {
                result[k] = b[i];
                i++;
            }
            else
            {
                result[k] = c[j];
                j++;
            }
            k++;
        }
        while (i < b.Length)
        {
            result[k] = b[i];
            i++;
            k++;
        }
        while (j < c.Length)
        {
            result[k] = c[j];
            j++;
            k++;
        }
        return result;
    }
}