#region ArrImplemention
public class ServiceAccessLogArr
{
    // public static void Main(string[] args)
    // {
    //     Console.WriteLine(ToIntBV("69.171.230.68"));
    //     int n = int.Parse(Console.ReadLine());
    //     var log = new Internet[n];
    //     for (var k = 0; k < n; k++)
    //     {
    //         var input = Console.ReadLine().Trim().Split().ToArray();
    //         log[k] = new Internet(DateTime.Parse(input[0]), input[1]);
    //     }
    //     int[] C = new int[(int)Math.Pow(2, 32)];

    //     int i = 0;
    //     int j = 0;
    //     UpdateAccessList(log, i, j, C);
    // }

    private static void UpdateAccessList(Internet[] log, int i, int j, int[] c)
    {
        while (log[i].Time < DateTime.Now)
        {
            c[toInt(log[i].IP)] = c[toInt(log[i].IP)] + 1;
            i++;
        }
        while (log[j].Time < DateTime.Now.AddHours(-1))
        {
            c[toInt(log[j].IP)] = c[toInt(log[j].IP)] - 1;
            j++;
        }
    }
    public static bool AccessedLastHour(int[] c, string ip)
    {
        return c[toInt(ip)] > 0;
    }
    private static int ToIntBV(string ip)
    {
        var tokens = ip.Split('.').Select(int.Parse).ToArray();
        return tokens[0] << 24 | tokens[1] << 16 | tokens[2] << 8 | tokens[3];
        // return tokens[0] * (int)Math.Pow(2, 24) + tokens[1] * (int)Math.Pow(2, 16)
        //         + tokens[2] * (int)Math.Pow(2, 8) + tokens[3];
    }

    private static int toInt(string ip)
    {
        var tokens = ip.Split(".").ToArray();
        string binaryCollectorStr = "";
        foreach (var item in tokens)
        {
            var b = ToBinary(int.Parse(item));
            binaryCollectorStr += b;
        }
        // int binary = int.Parse(binaryCollectorStr);
        int result = ToDesimal(binaryCollectorStr);
        return result;
    }

    private static int ToDesimal(string binary)
    {
        var charArr = binary.Reverse().ToArray();
        int sum = 0;
        for (var i = 0; i < charArr.Length; i++)
        {
            sum += int.Parse(charArr[i].ToString()) * (int)Math.Pow(2, i);
        }
        return sum;
    }

    private static string ToBinary(int n)
    {
        Stack<int> remainders = new Stack<int>();
        while (n > 0)
        {
            int rem = n % 2;
            remainders.Push(rem);
            n /= 2;
        }
        int remBits = 8 - remainders.Count;
        string result = "";
        for (var i = 0; i < remBits; i++)
        {
            result += 0;
        }
        while (remainders.Count > 0)
        {
            result += remainders.Pop();
        }
        return result;
    }
}

#endregion

#region DictImplemention

public class ServiceAccessLogDict
{
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     var log = new Internet[n];
    //     for (var k = 0; k < n; k++)
    //     {
    //         var input = Console.ReadLine().Trim().Split().ToArray();
    //         log[k] = new Internet(DateTime.Parse(input[0]), input[1]);
    //     }
    //     Dictionary<string, int> C = new Dictionary<string, int>();
    //     for (var k = 0; k < n; k++)
    //     {
    //         C.Add(log[k].IP, 0);
    //     }
    //     int i = 0;
    //     int j = 0;
    //     UpdateAccessList(log, i, j, C);
    // }

    private static void UpdateAccessList(Internet[] log, int i, int j, Dictionary<string, int> c)
    {
        while (log[i].Time < DateTime.Now)
        {
            c[log[i].IP] = c[log[i].IP] + 1;
            i++;
        }
        while (log[j].Time < DateTime.Now.AddHours(-1))
        {
            c[log[j].IP] = c[log[j].IP] - 1;
            j++;
        }
    }
    public bool AccessedLastHour(Dictionary<int, int> c, int ip)
    {
        return c[ip] > 0;
    }
}

public class Internet
{
    public DateTime Time;
    public string IP;
    public Internet(DateTime time, string ip)
    {
        this.Time = time;
        this.IP = ip;
    }
}
#endregion