
public class SleepSorting
{
    public static void Main(string[] args)
    {
        List<int> arr = new List<int> { 34, 23, 122, 9 };

        SleepSort(arr);
    }
    public static void SleepSort(List<int> arr)
    {
        List<Thread> allThreads = new List<Thread>();
        foreach (var item in arr)
        {
            Thread thread = new Thread(() => Routin(item));
            allThreads.Add(thread);
            thread.Start();
        }
        foreach (var t in allThreads)
        {
            t.Join();
        }
    }

    private static void Routin(int item)
    {
        Thread.Sleep(item);
        Console.Write(item + " ");
    }
}