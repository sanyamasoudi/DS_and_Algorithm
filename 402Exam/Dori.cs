
public static class Dori
{


    // public static void Main(string[] args)
    // {
    //     var firstInput = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     var arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
    //     var result3 = MaximizeHappiness(arr, firstInput[1]);
    //     Console.WriteLine(result3);
    // }

    private static int MaximizeHappiness(int[] arr, int k)
    {
        Array.Sort(arr);
        int i=0;
        while(k>0 && arr[i]<0 && i<arr.Length)
        {
            arr[i]*=-1;
            i++;
            k--;
        }
        if(k%2!=0)
        {
            Array.Sort(arr);
            arr[0]*=-1;
        }
        return arr.Sum();
    }
}