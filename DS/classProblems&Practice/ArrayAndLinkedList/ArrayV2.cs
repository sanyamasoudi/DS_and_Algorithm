public unsafe class Node
{
    public int index;
    public int value;
    public int* address;
    public Node(int i, int v)
    {
        this.index = i;
        this.value = v;
    }

}
public static class Arr
{
    static List<Node> arr = new List<Node>();
    public static void CreateArr()
    {
        for (var i = 0; i < 3; i++)
        {
            Node node = new Node(i, i+1);
            arr.Add(node);
        }
    }
    
    public static int GetElement(int index)
    {
        return arr.Find(i => i.index == index).value;
    }
    public static void PrintArr()
    {
        for (var i = 0; i < arr.Count; i++)
        {
            Console.WriteLine($"index:{arr[i].index},value:{arr[i].value}");
        }
    }
}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Arr.CreateArr();
//         Arr.PrintArr();
//         Console.WriteLine(Arr.GetElement(1));
//     }
// }