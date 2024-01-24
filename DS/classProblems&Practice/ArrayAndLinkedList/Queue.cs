public class QueueWithArr<T>
{
    public T[] arr;
    public int capacity;
    int read;
    int write;
    public QueueWithArr(int c)
    {
        capacity = c;
        arr = new T[capacity];
        write = 0; read = 0;
    }
    public void Enqueue(T element)
    {
        if (write + 1 == read)
        {
            Console.Write("Error");
        }
        else if (write < capacity)
        {
            arr[write] = element;
            write++;
        }
        else
        {
            write = 0;
            arr[write] = element;
            write++;
        }

    }

    public void Dequeue()
    {
        if (read + 1 == write)
        {
            Console.Write("Error");
        }
        else if (read < capacity)
        {
            arr[read] = default;
            read++;
        }
        else
        {
            read = 0;
            arr[0] = default;
            read++;
        }
    }
    public void Print()
    {
        for (var i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i + 1 < arr.Length)
            {
                Console.Write("->");
            }
        }
        Console.WriteLine();
        Console.WriteLine("------------");
    }
}
public class QueueWithLinkedList<T>
{
    public LinkedList<T> linkList;
    public QueueWithLinkedList()
    {
        linkList = new LinkedList<T>();
    }
    public void Enqueue(T element)
    {
        linkList.AddLast(element);
    }
    public T Top() => linkList.First.Value;
    public bool IsEmpty() => linkList.Count == 0;
    public T Dequeue()
    {
        if (linkList.First != null)
        {
            var deleted = linkList.First;
            linkList.RemoveFirst();
            return deleted.Value;
        }
        return default;
    }
    public void Print()
    {
        // for (var i = 0; i < linkList.Count; i++)
        // {
        //     Console.WriteLine(linkList.ElementAt(i));
        // }
        LinkedList<T> cpy = new LinkedList<T>();
        while (linkList.First != null)
        {
            var deleted = Dequeue();
            Console.Write(deleted);
            if (linkList.First != null)
            {
                Console.Write("->");
            }
            cpy.AddLast(deleted);
        }
        linkList = cpy;
        Console.WriteLine();
        Console.WriteLine("------------");
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         // QueueWithLinkedList<int> Queue = new QueueWithLinkedList<int>();
//         // Queue.Enqueue(1);
//         // Queue.Enqueue(2);
//         // Queue.Enqueue(3);
//         // Queue.Print();
//         // Queue.Dequeue();
//         // Queue.Print();
//         // Queue.Dequeue();
//         // Queue.Print();
//         // Queue.Dequeue();
//         // Queue.Print();
//         // Console.WriteLine(Queue.IsEmpty());
//         QueueWithArr<int> QueueA = new QueueWithArr<int>(5);
//         QueueA.Enqueue(0);
//         QueueA.Enqueue(1);
//         QueueA.Print();
//         QueueA.Enqueue(2);
//         QueueA.Print();
//         QueueA.Dequeue();
//         QueueA.Print();
//         QueueA.Dequeue();
//         QueueA.Print();
//         QueueA.Enqueue(3);
//         QueueA.Enqueue(4);
//         QueueA.Print();
//         QueueA.Enqueue(5);
//         QueueA.Print();
//         QueueA.Enqueue(6);
//     }
// }