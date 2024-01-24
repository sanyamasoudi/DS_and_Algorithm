using System.Collections.Generic;
// public class Program
// {
//     static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
//         int k = int.Parse(Console.ReadLine());
//         int result = MaxBenefit.Max3(arr, k);
//         Console.WriteLine(result);
//     }
// }
public class PriorityQueue<T> where T : IComparable<T>
{
    public List<T> heap;

    public PriorityQueue()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get { return this.heap.Count; }
    }

    public void Enqueue(T item)
    {
        this.heap.Add(item);
        this.BubbleUp(this.heap.Count - 1);
    }

    public T Dequeue()
    {
        T item = this.heap[0];
        int lastIndex = this.heap.Count - 1;
        this.heap[0] = this.heap[lastIndex];
        this.heap.RemoveAt(lastIndex);
        this.BubbleDown(0);
        return item;
    }

    public T Peek()
    {
        return this.heap[0];
    }

    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (this.heap[parentIndex].CompareTo(this.heap[index]) >= 0)
            {
                break;
            }
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }

    private void BubbleDown(int index)
    {
        while (index < this.heap.Count)
        {
            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int largestChildIndex = index;
            if (leftChildIndex < this.heap.Count && this.heap[leftChildIndex].CompareTo(this.heap[largestChildIndex]) >= 0)
            {
                largestChildIndex = leftChildIndex;
            }
            if (rightChildIndex < this.heap.Count && this.heap[rightChildIndex].CompareTo(this.heap[largestChildIndex]) >= 0)
            {
                largestChildIndex = rightChildIndex;
            }
            if (largestChildIndex == index)
            {
                break;
            }
            Swap(largestChildIndex, index);
            index = largestChildIndex;
        }
    }

    private void Swap(int i, int j)
    {
        T temp = this.heap[i];
        this.heap[i] = this.heap[j];
        this.heap[j] = temp;
    }
}
public static class MaxBenefit
{
    public static PriorityQueue<int> maxHeap = new PriorityQueue<int>();
    public static int Max3(int[] arr, int k)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            int sum = 0;
            for (var j = i; j < arr.Length; j++)
            {
                sum += arr[j];
                maxHeap.Enqueue(sum);
            }
        }
        for (var i = 0; i <= k - 2; i++)
        {
            maxHeap.Dequeue();
        }
        return maxHeap.Peek();
    }
    // public static List<int> maxHeap2 = new List<int>();
    // public static int Max(int[] arr, int k)
    // {
    //     for (var i = 0; i < arr.Length; i++)
    //     {
    //         int sum = 0;
    //         for (var j = i; j < arr.Length; j++)
    //         {
    //             sum += arr[j];
    //             maxHeap.Add(sum);
    //         }
    //     }
    //     maxHeap.Sort((x, y) => y.CompareTo(x));
    //     return maxHeap[k - 1];
    // }
}