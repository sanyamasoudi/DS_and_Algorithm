

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         // PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
//         // pq.Enqueue(1, 3);
//         // pq.Enqueue(7, 1);
//         // pq.Enqueue(5, 2);
//         // Console.WriteLine(pq.Dequeue());
//         // Console.WriteLine(pq.Dequeue());
//         PriorityQueue2<int> p = new();
//         p.Insert6(1);
//         p.Insert6(7);
//         p.Insert6(5);
//         Console.WriteLine(p.ExtractMax6());
//         p.Insert6(3);
//         // p.Remove(1);
//         Console.WriteLine(p.ExtractMax6());
//         p.Insert6(4);
//         p.Insert6(2);
//         Console.WriteLine(p.ExtractMax6());

//     }
// }
public class PriorityQueue2<T> where T : IComparable<T>
{
    List<T> Base;
    public PriorityQueue2()
    {
        Base = new List<T>();
    }
    //O(nlogn)
    public void Insert(T element)
    {
        Base.Add(element);
        Base.Sort((x, y) => y.CompareTo(x));
    }
    //O(1)
    public T ExtractMax()
    {
        var returned = Base[0];
        Base.Remove(returned);
        return returned;
    }
    /////////////////////////////////////////////////
    /// deque approach
    public LinkedList<T> maxQ;
    //O(n)
    public void Insert3(T element)
    {
        while (maxQ.Count > 0 && maxQ.First.Value.CompareTo(element) < 0)
        {
            maxQ.RemoveFirst();
        }
        maxQ.AddLast(element);
    }
    //O(1)
    public T ExtractMax3()
    {
        var returned = maxQ.First.Value;
        maxQ.RemoveFirst();
        return returned;
    }

    ////////////////////////////////////////////

    //O(1)
    public void Insert2(T element)
    {
        Base.Add(element);
    }
    //O(n)
    public T ExtractMax2()
    {
        var returned = Base.Max();
        Base.Remove(returned);
        return returned;
    }
    //////////////////////////////////////
    public List<T> arr = new List<T>();
    //O(n)
    public void Insert5(T element)
    {
        if (arr.Count == 0)
        {
            arr.Add(element);
        }
        else if (arr.Count == 1)
        {
            arr.Add(element);
            if (arr[0].CompareTo(element) > 0)
            {
                (arr[0], arr[1]) = (arr[1], arr[0]);
            }
        }
        else
        {
            int index = arr.FindIndex(x => x.CompareTo(element) > 0);
            if (index == -1)
            {
                arr.Add(element);
            }
            else
            {
                arr.Insert(index, element);
            }
        }
    }

    public void Insert4(T element)
    {
        if (arr.Count == 0) arr.Add(element);
        else if (arr.Count == 1)
        {
            arr.Add(element);
            if (arr[0].CompareTo(element) > 0)
            {
                (arr[0], arr[1]) = (arr[1], arr[0]);
            }
        }
        //arr.Sort(); (arr must be sort)
        else
        {
            int low = 0; int high = arr.Count - 1;
            //O(logn) binary search
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (element.CompareTo(arr[mid]) > 0)
                {
                    low = mid + 1;
                    if (low == high)
                    {
                        arr.Add(element);
                        if (element.CompareTo(arr[low]) < 0)
                        {
                            Shift(low);//O(n)
                            arr[low] = element;
                        }
                        break;
                    }
                }
                else if (element.CompareTo(arr[mid]) < 0)
                {
                    high = mid - 1;
                    if (low == high)
                    {
                        arr.Add(element);
                        if (element.CompareTo(arr[low + 1]) < 0)
                        {
                            Shift(low + 1);
                            arr[low + 1] = element;
                        }
                        break;
                    }
                }
            }
        }
    }

    private void Shift(int low)
    {
        List<T> copyList = new List<T>(arr);
        for (var i = low; i < arr.Count - 1; i++)
        {
            arr[i + 1] = copyList[i];
        }
    }
    //O(1)
    public T ExtractMax4()
    {
        var returned = arr[arr.Count - 1];
        arr.RemoveAt(arr.Count - 1);
        return returned;
    }
    ////////////////////////////////////////////
    LinkedList<T> linkList = new LinkedList<T>();
    public void Insert6(T element)
    {
        if (linkList.Count == 0)
        {
            linkList.AddLast(element);
        }
        else
        {
            var p = linkList.First;
            while (p != null)
            {
                if (p.Value.CompareTo(element) > 0)
                {
                    var newNode = new LinkedListNode<T>(element);
                    linkList.AddBefore(p, newNode);
                    break;
                }
                if(p.Next==null)
                {
                    linkList.AddLast(element);
                    break;
                }
                p = p.Next;
            }
        }
    }


    public T ExtractMax6()
    {
        var returned = linkList.Last.Value;
        linkList.RemoveLast();
        return returned;
    }
}
