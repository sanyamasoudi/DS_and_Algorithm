public class Change
{
    //O(n)
    public static int GetChange(int m)
    {
        return m / 10 + m % 10 / 5 + m % 5;
        // int count = 0;
        // while (m > 0) {
        //     if (m >= 10) {
        //         m -= 10;

        //     } else if (m >= 5) {
        //         m -= 5;

        //     } else if (m >= 1) {
        //         m -= 1;

        //     }
        //     count++;
        // }
        // return count;
    }
    public static int GetChange2(int money, List<int> denomination)
    {
        denomination.Sort((int x, int y) => y.CompareTo(x));
        int count = 0;
        while (money > 0 && denomination.Count > 0)
        {
            if (money >= denomination[0])
            {
                money -= denomination[0];
                count++;
            }
            else
            {
                denomination.RemoveAt(0);
            }
        }
        return count;
    }
    public static int GetChange3(int money, List<int> denomination)
    {
        denomination.Sort((int x, int y) => y.CompareTo(x));
        int count = 0;
        for (var i = 0; i < denomination.Count; i++)
        {
            int x = money / denomination[i];
            money %= denomination[i];
            count += x;
        }
        return count;
    }
}

// public class Program
// {
//     public static void Main()
//     {
//           int n=int.Parse(Console.ReadLine());
//           Console.WriteLine(Change.GetChange(n));
//     }
// }