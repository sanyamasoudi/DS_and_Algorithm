public class node
{
    public int value;
    public node pointerToNext;
}
public class SinglyLinkedList
{
    public node MakeNode(int val)
    {
        node newNode = new node
        {
            value = val,
            pointerToNext = null
        };
        return newNode;
    }
    public node MakeList(int l)
    {
        node head = null;
        node last = null;
        for (var i = 0; i < l; i++)
        {
            node newNode = MakeNode(i);
            if (head == null)
                head = newNode;
            if (last != null)
                last.pointerToNext = newNode;
            last = newNode;
        }
        return head;
    }
    public void printList(node head)
    {
        while (head != null)
        {
            Console.Write(head.value);
            if (head.pointerToNext != null)
                Console.Write("->");
            head = head.pointerToNext;
        }
        Console.WriteLine();
    }
    public node PushFront(node head, int key)
    {
        node newNode = MakeNode(key);
        newNode.pointerToNext = head;
        return newNode;
    }
    public node PopFront(node head)
    {
        head = head.pointerToNext;
        return head;
    }
    public node TopFront(node head) => head;
    public node PushBack(node head, int key)
    {
        node newNode = MakeNode(key);
        node last = head;
        while (last != null)
        {
            if (last.pointerToNext == null)
            {
                last.pointerToNext = newNode;
                break;
            }
            last = last.pointerToNext;
        }
        return head;
    }
    public node PushBackWithTail(node head, node tail,int key)
    {
        node newNode = MakeNode(key);
        tail.pointerToNext=newNode;
        return head;
    }

    public node PopBack(node head)
    {
        node last = head;
        while (last != null)
        {
            if (last.pointerToNext.pointerToNext == null)
            {
                last.pointerToNext = null;
                break;
            }
            last = last.pointerToNext;
        }
        return head;
    }
    public node TopBack(node head)
    {
        node last = head;
        while (last != null)
        {
            if (last.pointerToNext == null)
            {
                return last;
            }
            last = last.pointerToNext;
        }
        return null; ;
    }
    public node Find(node head, int key)
    {
        while (head != null)
        {
            if (head.value == key)
            {
                return head;
            }
            head = head.pointerToNext;
        }
        return null;
    }
    public node DeleteNode(node head, int deleteNode)
    {
        if (head.value == deleteNode)
        {
            return PopFront(head);
        }
        node last = new node();
        last = head;
        while (last != null)
        {
            if (last.pointerToNext.value == deleteNode)
            {
                last.pointerToNext = last.pointerToNext.pointerToNext;
                break;
            }
            last = last.pointerToNext;
        }
        return head;
    }
    public node DeleteNode(node head, node deleteNode)
    {
        if (head == deleteNode)
        {
            return PopFront(head);
        }
        node last = new node();
        last = head;
        while (last != null)
        {
            if (last.pointerToNext == deleteNode)
            {
                last.pointerToNext = last.pointerToNext.pointerToNext;
                break;
            }
            last = last.pointerToNext;
        }
        return head;
    }
    public node AddBefore(node head, node n, node key)
    {
        node last = head;
        while (last != null)
        {
            if (last.pointerToNext == n)
            {
                last.pointerToNext = key;
                last.pointerToNext.pointerToNext = n;
                break;

            }
            last = last.pointerToNext;
        }
        return head;
    }
    public node AddAfter(node head, node n, node key)
    {
        key.pointerToNext=n.pointerToNext;
        n.pointerToNext=key;
        return head;
    }
    public bool IsEmpty(node head)
    {
        if(head==null || head.pointerToNext==null) return true;
        else return false;
    }

}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         SinglyLinkedList linkList = new SinglyLinkedList();
//         var n = linkList.MakeList(10);
//         linkList.printList(n);
//         var b = linkList.AddBefore(n, linkList.Find(n, 3), linkList.MakeNode(-666));
//         linkList.printList(b);
//         // Console.WriteLine(linkList.IsEmpty(n));
//         // linkList.printList(linkList.TopFront(n));
//         // linkList.printList(linkList.TopBack(n));
//         // var n2 = linkList.DeleteNode(n, 9);
//         // var n3 = linkList.DeleteNode(n, linkList.Find(n,3));
//         // linkList.printList(n3);
//         // var newHead = linkList.PushFront(n, -1);
//         // linkList.printList(newHead);

//         // var popFront = linkList.PopFront(n);
//         // linkList.printList(popFront);

//         // var popBack = linkList.PopBack(n);
//         // linkList.printList(popBack);
//         // var findedNode=linkList.Find(popBack,2);
//         // Console.WriteLine($"{findedNode.value}");
//         // linkList.printList(findedNode);
//         // var newHead2=linkList.PushBack(newHead,10);
//         // linkList.printList(newHead2);
//     }
// }