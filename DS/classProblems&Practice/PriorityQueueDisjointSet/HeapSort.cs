public class Program
{
    public static void Main(string[] args)
    {
        var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        // HeapSort.BuildHeap(arr);
        // var result = HeapSort.Sort3(arr);
        var result = HeapSort.PartialSortingKLast(arr, 4);
        Console.Write(String.Join(" ", result));
    }
}
//O(nlogn)
public static class HeapSort
{
    public static int[] Sort1(this int[] arr)
    {
        PriorityQueue<int, int> pq1 = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        for (var i = 0; i < arr.Length; i++)
        {
            pq1.Enqueue(arr[i], arr[i]);
        }
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            arr[i] = pq1.Dequeue();

        }
        return arr;
    }
    public static int[] Sort2(this int[] arr)
    {
        PriorityQueue pq = new PriorityQueue();
        for (var i = 0; i < arr.Length; i++)
        {
            pq.Enqueue(arr[i]);
        }
        for (var i = arr.Length - 1; i >= 0; i--)
        {
            arr[i] = pq.Dequeue();
        }
        return arr;
    }
    // O(n+klogn)
    public static int[] PartialSortingKLast(this int[] arr, int k)
    {
        BuildHeap(arr);
        for (int i = arr.Length - 1; i > arr.Length - 1 - k; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            SiftDown(0, i, arr);
        }
        return arr;
    }


    public static int[] Sort3(this int[] arr)
    {
        BuildHeap(arr);
        int size = arr.Length;
        for (int i = size - 1; i > 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            size--;
            SiftDown(0, size, arr);
        }
        return arr;
    }

    private static void SiftDown(int index, int size, int[] arr)
    {
        while (index < size)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestChildIndex = index;

            if (leftChildIndex < size && arr[leftChildIndex] > arr[largestChildIndex])
            {
                largestChildIndex = leftChildIndex;
            }
            if (rightChildIndex < size && arr[rightChildIndex] > arr[largestChildIndex])
            {
                largestChildIndex = rightChildIndex;
            }
            if (largestChildIndex == index)
            {
                break;
            }
            (arr[largestChildIndex], arr[index]) = (arr[index], arr[largestChildIndex]);
            index = largestChildIndex;
        }
    }

    public static void BuildHeap(this int[] arr)
    {
        int size = arr.Length;
        for (int i = size / 2 - 1; i >= 0; i--)
        {
            SiftDown(i, size, arr);
        }
    }

}