
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int k = int.Parse(Console.ReadLine());
//         string[] input = new string[k];
//         for (var i = 0; i < k; i++)
//         {
//             input[i] = Console.ReadLine().Trim();
//         }
//         for (var i = 0; i < input.Length; i++)
//         {
//             string[] parts = input[i].Split('(', ')', ',');
//             string command = parts[0];
//             int[] operands = null;
//             int c=0;
//             if (command != "remove")
//             {
//                 operands = new int[parts.Length - 2];
//                 for (int j = 0; j < operands.Length; j++)
//                 {
//                     if (!string.IsNullOrEmpty(parts[j + 1]) && int.TryParse(parts[j + 1], out int number))
//                     {
//                         operands[j] = number;
//                         c++;
//                     }
//                 }
//             }
//             if(c==0) operands=null;
//             Perform(command, operands);
//         }
//         static void Perform(string operatorMPQ, int[] operands)
//         {
//             switch (operatorMPQ)
//             {
//                 case "build":
//                     MPQ2.Build(operands);
//                     break;
//                 case "remove":
//                     MPQ2.Remove();
//                     break;
//                 case "insert":
//                     foreach (var item in operands)
//                     {
//                         MPQ2.Insert(item);
//                     }
//                     break;
//                 default:
//                     break;
//             }
//         }
//         foreach (var r in MPQ2.result)
//         {
//             Console.WriteLine(r);
//         }
//     }
// }
public static class MPQ2
{
    public static List<int> mpq = new List<int>();
    public static int mid;
    public static List<int> result = new List<int>();

    public static void Build(int[] nums)
    {
        if (nums == null || nums.Length == 0) return;
        mpq.Clear();
        Array.Sort(nums);
        mpq = nums.ToList();
        mid = nums[(nums.Length - 1) / 2];
    }
    public static void Remove()
    {
        if (mpq.Count > 0)
        {
            mpq.Remove(mid);
            mpq.Sort();
            result.Add(mid);
            if (mpq.Count > 0) mid = mpq[(mpq.Count - 1) / 2];
        }
    }
    public static void Insert(int n)
    {
        mpq.Add(n);
        mpq.Sort();
        mid = mpq[(mpq.Count - 1) / 2];
    }
}