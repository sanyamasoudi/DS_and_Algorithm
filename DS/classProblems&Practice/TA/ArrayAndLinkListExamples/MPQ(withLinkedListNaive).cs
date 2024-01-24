// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int k = int.Parse(Console.ReadLine());
//         string[] input = new string[k];
//         for (var i = 0; i < k; i++)
//         {
//             input[i] = Console.ReadLine();
//         }
//         for (var i = 0; i < input.Length; i++)
//         {
//             List<int> operands = new List<int>();
//             foreach (var item in input[i])
//             {
//                 if (Char.IsDigit(item))
//                 {
//                     operands.Add(int.Parse(item.ToString()));
//                 }
//             }
//             Perform(input[i].Trim().Split("(")[0], operands.ToArray());
//         }
//         foreach (var r in MPQ.result)
//         {
//             Console.WriteLine(r);
//         }
//     }

//     private static void Perform(string operatorMPQ, int[] operands)
//     {
//         switch (operatorMPQ)
//         {
//             case "build":
//                 MPQ.Build(operands);
//                 break;
//             case "remove":
//                 MPQ.Remove();
//                 break;
//             case "insert":
//                 MPQ.Insert(operands[0]);
//                 break;
//             default:
//                 break;
//         }
//     }
// }
public static class MPQwithLinkedListNaive
{
    public static LinkedList<int> mpq;
    public static int[] mpqArr;
    public static int miane;
    public static List<int> result = new List<int>();
    public static void Build(int[] nums)
    {
        mpqArr = nums;
        mpq = new LinkedList<int>();
        Array.Sort(nums);
        miane = nums[(nums.Length - 1) / 2];
        for (var i = 0; i < nums.Length; i++)
        {
            mpq.AddLast(nums[i]);
        }
    }
    public static void Remove()
    {
        var deleted = mpqArr[(mpqArr.Length - 1) / 2];
        mpq.Remove(deleted);
        result.Add(deleted);
        mpqArr = mpq.ToArray();
    }
    public static void Insert(int n)
    {
        int low = 0; int high = mpqArr.Length - 1;

        while (low <= high)
        {
            int mianeIndex = (high - low) / 2;
            int mid = mpqArr[(high - low) / 2];
            if (high - low <= 1)
            {
                if (n > mpqArr[high])
                {
                    mpq.AddLast(n);
                }
                else if (n < mpqArr[low])
                {
                    mpq.AddBefore(mpq.Find(mpqArr[low]), n);
                }
                else if (n >= mpqArr[low] && n <= mpqArr[high])
                {
                    mpq.AddAfter(mpq.Find(mpqArr[low]), n);
                }
                break;
            }
            else if (n > mid)
            {
                low = mianeIndex + 1;
            }
            else if (n < mid)
            {
                high = mianeIndex - 1;
            }
        }
        mpqArr = mpq.ToArray();
    }
}