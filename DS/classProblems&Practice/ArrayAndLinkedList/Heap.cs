// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Console.WriteLine(12.CompareTo(0));
//     }
// }
public class PriorityQueue<T> where T : IComparable<T>
{
    public List<T> queue;
    public PriorityQueue()
    {
        queue = new List<T>();
    }
    public int Count => queue.Count;
    public void Enqueue(T element)
    {
        queue.Add(element);
        BubbleUp(queue.Count - 1);
    }
    public T Dequeue()
    {
        var deleted = queue[0];
        int lastIndex = queue.Count - 1;
        queue[0] = queue[lastIndex];
        queue.RemoveAt(lastIndex);
        BubbleDown(0);
        return deleted;
    }
    public T Peek() => queue[0];
    private void BubbleDown(int index)
    {
        while (index < queue.Count)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            int LargestChildIndex = index;
            if (leftChildIndex < queue.Count && queue[leftChildIndex].CompareTo(queue[index]) > 0)
            {
                LargestChildIndex = leftChildIndex;
            }
            if (rightChildIndex < queue.Count && queue[rightChildIndex].CompareTo(queue[index]) > 0)
            {
                LargestChildIndex = rightChildIndex;
            }
            if (LargestChildIndex == index)
            {
                break;
            }
            Swap(LargestChildIndex, index);
            index = LargestChildIndex;
        }
    }

    private void BubbleUp(int index)
    {
        while (index > 0)
        {
            int parent = (index - 1) / 2;
            if (queue[parent].CompareTo(queue[index]) >= 0)
            {
                break;
            }
            Swap(index, parent);
            index = parent;
        }
    }

    private void Swap(int index, int parent)
    {
        var tmp = queue[index];
        queue[index] = queue[parent];
        queue[parent] = tmp;
    }
}
