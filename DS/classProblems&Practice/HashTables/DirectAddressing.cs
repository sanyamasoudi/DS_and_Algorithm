public class Node
{
    public int key;
    public int value;
    public Node next;
    public Node(int k, int v)
    {
        this.key = k;
        this.value = v;
        next = null;
    }
}
public class DirectAddressing
{
    // public static void Main(string[] args)
    // {
    //     List<int[]> inputs = new List<int[]>();
    //     int n = int.Parse(Console.ReadLine());
    //     for (var i = 0; i < n; i++)
    //     {
    //         var nums = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //         inputs.Add(nums);
    //     }
    //     DirectAddressingWithLinkeList(inputs);
    //     // DirectAddressingWithArr(inputs);
    // }
    //if all key is unique
    public static void DirectAddressingWithArr(List<int[]> list)
    {
        var max = list.Select(i => i[0]).ToArray().Max();
        int[] DirectAddressingArr = new int[max + 1];
        InitialArr(DirectAddressingArr);
        for (var i = 0; i < list.Count; i++)
        {
            DirectAddressingArr[list[i][0]] = list[i][1];
        }
        Console.WriteLine(String.Join(" ", DirectAddressingArr.Where(i => i != int.MaxValue)));
    }

    private static void InitialArr(int[] directAddressingArr)
    {
        for (var i = 0; i < directAddressingArr.Length; i++)
        {
            directAddressingArr[i] = int.MaxValue;
        }
    }
    //if all key is not unique
    public static void DirectAddressingWithLinkeList(List<int[]> list)
    {
        List<Node> DirectAddressingLinkList = new List<Node>();

        for (var i = 0; i < list.Count; i++)
        {
            var node = DirectAddressingLinkList.Find(e => e.key == list[i][0]);
            if (node == null)
                DirectAddressingLinkList.Add(new Node(list[i][0], list[i][1]));
            else
            {
                while (node != null)
                {
                    if (node.next == null)
                    {
                        node.next = new Node(list[i][0], list[i][1]);
                        break;
                    }
                    node = node.next;
                }
            }
        }
    }


}