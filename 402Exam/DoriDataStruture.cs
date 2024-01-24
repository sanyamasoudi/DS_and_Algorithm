public class MyLinkList
{
    public static int k;
    public static int n;
    public static Node head;
    public static Node tail;
    public static Node favoriteItem;
    public static int favoriteItemIndex;
    public void BasicMake(int[] arr, int N, int K)
    {
        for (var i = 0; i < arr.Length; i++)
        {
            var newNode = new Node(arr[i]);
            if (head == null)
            {
                head = newNode;
            }
            if (tail != null)
            {
                tail.next = newNode;
                if(newNode!=null) newNode.prev=tail;
            }
            tail = newNode;
        }
        n = N; k = K;
        Update();
    }
    public void Print()
    {
        var tmp = head;
        while (tmp != null)
        {
            Console.Write(tmp.value + " ");
            tmp = tmp.next;
        }
    }
    public void Update()
    {
        int favoriteItemIdx = n * k / 100;
        var tmp = head;
        int index = 0;
        while (tmp != null && index < favoriteItemIdx)
        {
            tmp = tmp.next;
            index++;
        }
        favoriteItemIndex = favoriteItemIdx;
        favoriteItem = tmp;
    }
    public void AddFirst(int x)
    {
        Node newNode = new Node(x);
        if(newNode!=null) newNode.next = head;
        if (head != null) head.prev = newNode;
        head = newNode;
        n++;
        Update();
    }
    public void AddLast(int x)
    {
        Node newNode = new Node(x);
        if(tail!=null) tail.next = newNode;
        if (newNode != null) newNode.prev = tail;
        tail = newNode;
        n++;
        Update();
    }
    public void AddAfter(int x)
    {
        if (favoriteItem == tail)
        {
            AddLast(x);
            return;
        }
        Node newNode = new Node(x);
        if(newNode!=null) newNode.next = favoriteItem.next;
        if (favoriteItem.next != null) favoriteItem.next.prev = newNode;
        if(favoriteItem!=null) favoriteItem.next = newNode;
        if (newNode != null) newNode.prev = favoriteItem;
        n++;
        Update();
    }
    public void AddBefore(int x)
    {
        if (favoriteItem == head)
        {
            AddFirst(x);
            return;
        }
        Node newNode = new Node(x);
        if(newNode!=null) newNode.prev = favoriteItem.prev;
        if (favoriteItem.prev != null) favoriteItem.prev.next = newNode;
        if(favoriteItem!=null) favoriteItem.prev = newNode;
        if (newNode != null) newNode.next = favoriteItem;
        n++;
        Update();
    }
    public void DeleteAllBefore()
    {
        head = favoriteItem;
        if(head!=null) head.prev = null;
        n = n - favoriteItemIndex;
        Update();
    }
    public void DeleteAllAfter()
    {
        tail = favoriteItem;
        if(tail!=null) tail.next = null;
        n = favoriteItemIndex + 1;
        Update();
    }
}
public class Node
{
    public int value;
    public Node next;
    public Node prev;

    public Node(int v)
    {
        this.value = v;
        next = prev = null;
    }
}
public class DoriDataStruture
{
    // public static void Main(string[] args)
    // {
    //     MyLinkList linkList = new MyLinkList();

    //     var inputs = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     int n = inputs[0];
    //     int k = inputs[1];
    //     int q = inputs[2];
    //     var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     linkList.BasicMake(arr, n, k);
    //     for (var i = 0; i < q; i++)
    //     {
    //         var op = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //         switch (op[0])
    //         {
    //             case 1:
    //                 linkList.AddFirst(op[1]);
    //                 break;
    //             case 2:
    //                 linkList.AddLast(op[1]);
    //                 break;
    //             case 3:
    //                 linkList.AddBefore(op[1]);
    //                 break;
    //             case 4:
    //                 linkList.AddAfter(op[1]);
    //                 break;
    //             case 5:
    //                 linkList.DeleteAllBefore();
    //                 break;
    //             case 6:
    //                 linkList.DeleteAllAfter();
    //                 break;
    //             default:
    //                 break;
    //         }

    //     }
    //     Console.WriteLine(MyLinkList.n);
    //     linkList.Print();
    // }
}