
public class PriorityQueue
{
    public List<int> priorityQueue;
    public int count = 10;


    public PriorityQueue()
    {
        this.priorityQueue = new List<int>();
    }

    public PriorityQueue(int[] arr)
    {
        this.priorityQueue = arr.ToList();
    }

    public void Enqueue(int element)
    {
        priorityQueue.Add(element);
        SiftUp(priorityQueue.Count - 1);
    }

    public void SiftUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = (index - 1) / 2;
            if (priorityQueue[parentIndex] >= priorityQueue[index])
            {
                break;
            }
            Swap(parentIndex, index);
            index = parentIndex;
        }
    }
    public void Print()
    {
        Print(0, 0, count);
    }

    public void Print(int i, int space, int count)
    {
        if (i >= priorityQueue.Count)
        {
            return;
        }
        var parent = i;
        var left = 2 * i + 1;
        var right = 2 * i + 2;
        Print(right, space + count, count);

        for (var j = 0; j < space; j++)
        {
            Console.Write(" ");
        }
        Console.Write(priorityQueue[parent] + "\n");

        Print(left, space + count, count);
    }
    public void ChangePriority(int i, int p)
    {
        var oldP = priorityQueue[i];
        priorityQueue[i] = p;
        if (oldP < p)
        {
            SiftUp(i);
        }
        else
        {
            SiftDown(i);
        }
    }
    public int Remove(int index)
    {
        var tmp = priorityQueue[index];
        priorityQueue[index] = int.MaxValue;
        SiftUp(index);
        Dequeue();
        return tmp;
    }
    public int Dequeue()
    {
        var deleted = priorityQueue[0];
        Swap(0, priorityQueue.Count - 1);
        priorityQueue.RemoveAt(priorityQueue.Count - 1);
        SiftDown(0);
        return deleted;
    }

    public void SiftDown(int index)
    {
        while (index < priorityQueue.Count)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largestChildIndex = index;
            if (leftChildIndex < priorityQueue.Count && priorityQueue[leftChildIndex] >= priorityQueue[largestChildIndex])
            {
                largestChildIndex = leftChildIndex;
            }
            if (rightChildIndex < priorityQueue.Count && priorityQueue[rightChildIndex] >= priorityQueue[largestChildIndex])
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

    public void Swap(int i1, int i2)
    {
        (priorityQueue[i1], priorityQueue[i2]) = (priorityQueue[i2], priorityQueue[i1]);
    }
}