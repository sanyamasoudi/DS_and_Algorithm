public static class UnboundedBinarySearch
{
    public static int Compute(Func<int, int> func, int[] domain)
    {
        Array.Sort(domain);
        int left = 0; int right = domain.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (func(domain[mid]) == 0)
            {
                return domain[mid];
            }
            else if (func(domain[mid]) < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
    public static int ComputeInfinte(Func<int, int> func)
    {
        int left = 1; int right = 2;
        while (func(right) < 0)
        {
            (left, right) = (right, 2 * right);
        }

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (func(mid) == 0)
            {
                return mid;
            }
            else if (func(mid) < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         // var domainArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
//         // var result = UnboundedBinarySearch.Compute((x) => x - 1, domainArr);
//         var result2 = UnboundedBinarySearch.ComputeInfinte((x) => 2*x - 5);
//         Console.WriteLine(result2);
//     }
// }