using System.Collections;
using System.Linq;

public class RezaCookies
{
    public static void Main(string[] args)
    {
        var FirstLineInput = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        int n = FirstLineInput[0];
        int m = FirstLineInput[1];
        int d = FirstLineInput[2];
        var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        var result = MaxHappiness3(arr, n, m, d);
        Console.WriteLine(result);
    }
    public static long MaxHappiness3(int[] arr, int n, int m, int d)
    {
        List<int> heap = new List<int>(); int max = int.MinValue;
        for (var i = 0; i < m; i++)
        {
            heap.Add(arr[i]);
        }
        max = Math.Max(heap.Sum() + -1 * d * (m - 1 + 1), max);
        for (var i = m; i < n; i++)
        {
            heap.Add(arr[i]);
            heap.Remove(heap.Min());
            max = Math.Max(heap.Sum() + -1 * d * (i + 1), max);
        }
        return max;
    }

    // public static int MaxHappiness4(int[] arr, int n, int m, int d)
    // {
    //     PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
    //     int max = int.MinValue;
    //     for (var i = 0; i < m; i++)
    //     {
    //         minHeap.Enqueue(arr[i], arr[i]);
    //     }
    //     int sum = 0;
    //     var l = minHeap.UnorderedItems.ToList(); l = l.OrderBy(e => e.Priority).ToList();
    //     foreach (var item in l)
    //     {
    //         sum += item.Priority;
    //     }
    //     max = Math.Max(sum + -1 * d * (m - 1 + 1), max);

    //     for (var i = m; i < n; i++)
    //     {
    //         sum = 0;
    //         minHeap.Enqueue(arr[i], arr[i]);
    //         minHeap.Dequeue();
    //         l = minHeap.UnorderedItems.ToList(); l = l.OrderBy(e => e.Priority).ToList();
    //         foreach (var item in l)
    //         {
    //             sum += item.Priority;
    //         }
    //         max = Math.Max(sum + -1 * d * (i + 1), max);
    //     }
    //     return max;
    // }

    // public static int MaxHappiness(int[] arr, int n, int m, int d)
    // {
    //     BuildHeap(arr, m - 1);
    //     int size = m - 1;
    //     for (var i = size - 1; i > 0; i--)
    //     {
    //         (arr[0], arr[i]) = (arr[i], arr[0]);
    //         size--;
    //         SiftDown(0, size, arr);
    //     }
    //     int max = int.MinValue;
    //     for (var i = m - 1; i < n; i++)
    //     {
    //         int s = arr[i] + -1 * d * (i + 1);
    //         for (var k = 1; k <= m - 1; k++)
    //         {
    //             s += arr[i - k];
    //         }
    //         max = Math.Max(max, s);
    //         BuildHeap(arr, i + 1);
    //         int nsize = i + 1;
    //         for (var j = nsize - 1; j > 0; j--)
    //         {
    //             (arr[0], arr[j]) = (arr[j], arr[0]);
    //             nsize--;
    //             SiftDown(0, nsize, arr);
    //         }
    //     }
    //     return max;
    // }
    // private static void BuildHeap(int[] arr, int n)
    // {
    //     for (var i = n / 2 - 1; i >= 0; i--)
    //     {
    //         SiftDown(i, n, arr);
    //     }
    // }
    // private static void SiftDown(int index, int size, int[] arr)
    // {
    //     while (index < size)
    //     {
    //         int leftIndex = 2 * index + 1;
    //         int rightIndex = 2 * index + 2;
    //         int largestIndex = index;
    //         if (leftIndex < size && arr[leftIndex] >= arr[largestIndex])
    //         {
    //             largestIndex = leftIndex;
    //         }
    //         if (rightIndex < size && arr[rightIndex] >= arr[largestIndex])
    //         {
    //             largestIndex = rightIndex;
    //         }
    //         if (largestIndex == index)
    //         {
    //             break;
    //         }
    //         (arr[largestIndex], arr[index]) = (arr[index], arr[largestIndex]);
    //         index = largestIndex;
    //     }
    // }

    // public static int MaxHappiness2(int[] arr, int n, int m, int d)
    // {
    //     PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
    //     for (var i = m - 1; i < n; i++)
    //     {
    //         int decreaseX = -1 * d * (i + 1);

    //         List<int> newl = new List<int>(arr.Where((_, index) => index < i).ToArray());
    //         newl.Sort((x, y) => y.CompareTo(x));
    //         int increaseX = 0;
    //         for (var k = 0; k <= m - 2; k++)
    //         {
    //             increaseX += newl[k];
    //         }
    //         increaseX += arr[i];
    //         pq.Enqueue(increaseX + decreaseX, increaseX + decreaseX);
    //     }
    //     return pq.Dequeue();
    // }

}