public static class PrimitiveCalculator
{
    public static List<int> Compute(int n)
    {
        int[] arr = new int[n + 1];
        int[] prev = new int[n + 1]; // To store the previous number for reconstructing the sequence

        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i - 1] + 1;
            prev[i] = i - 1;

            if (i % 2 == 0 && arr[i / 2] + 1 < arr[i])
            {
                arr[i] = arr[i / 2] + 1;
                prev[i] = i / 2;
            }

            if (i % 3 == 0 && arr[i / 3] + 1 < arr[i])
            {
                arr[i] = arr[i / 3] + 1;
                prev[i] = i / 3;
            }
        }

        List<int> sequence = new List<int>();
        sequence.Add(n);
        int i2 = n;

        while (i2 > 1)
        {
            sequence.Add(prev[i2]);
            i2 = prev[i2];
        }

        sequence.Reverse();
        return sequence;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int n = int.Parse(Console.ReadLine());
//         var result = PrimitiveCalculator.Compute(n);

//         foreach (int number in result)
//         {
//             Console.Write(number + " ");
//         }
//     }
// }
