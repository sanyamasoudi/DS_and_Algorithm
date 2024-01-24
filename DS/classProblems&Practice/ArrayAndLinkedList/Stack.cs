public class StackWithArr<T>
{
    public T[] arr;
    public int capacity;
    public int size = 0;
    public StackWithArr(int c)
    {
        capacity = c;
        arr = new T[capacity];
    }
    public void Push(T element)
    {
        if (size < capacity)
        {
            arr[size] = element;
            size++;
        }
        else
        {
            Console.WriteLine("Error Stack is Full!");
        }
    }
    public T Top() => arr[size - 1];
    public bool IsEmpty() => size == 0;
    public T Pop()
    {
        if (size >= 1)
        {
            var deleted = arr[size - 1];
            arr[size - 1] = default;
            size--;
            return deleted;
        }
        else
        {
            Console.WriteLine("Error");
            return default;
        }
    }
    public void Print()
    {
        T[] cpy = new T[size];
        while (size >= 1)
        {
            int sizeBeforePop = size;
            cpy[sizeBeforePop - 1] = Pop();
            Console.WriteLine(cpy[sizeBeforePop - 1]);
        }
        for (var i = 0; i < cpy.Length; i++)
        {
            Push(cpy[i]);
        }
        Console.WriteLine("------------");
    }

}
public class StackWithLinkedList<T>
{
    public LinkedList<T> linkList;
    public StackWithLinkedList()
    {
        linkList = new LinkedList<T>();
    }
    public void Push(T element)
    {
        linkList.AddFirst(element);
    }
    public T Top() => linkList.First.Value;
    public bool IsEmpty() => linkList.Count == 0;
    public T Pop()
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
        LinkedList<T> cpy=new LinkedList<T>();
        while(linkList.First != null)
        {
            var deleted=Pop();
            Console.WriteLine(deleted);
            cpy.AddLast(deleted);
        }
        linkList=cpy;
        Console.WriteLine("------------");
    }

}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         // StackWithArr<int> mStack = new StackWithArr<int>(3);
//         // mStack.Push(1);
//         // mStack.Push(2);
//         // mStack.Push(3);
//         // mStack.Print();
//         // mStack.Pop();
//         // mStack.Print();
//         // mStack.Pop();
//         // mStack.Print();
//         // mStack.Pop();
//         // mStack.Print();
//         // Console.WriteLine(mStack.IsEmpty());
//         StackWithLinkedList<int> mStack = new StackWithLinkedList<int>();
//         mStack.Push(1);
//         mStack.Push(2);
//         mStack.Push(3);
//         mStack.Print();
//         mStack.Pop();
//         mStack.Print();
//         mStack.Pop();
//         mStack.Print();
//         mStack.Pop();
//         mStack.Print();
//         // Console.WriteLine(mStack.IsEmpty());
//     }
// }