public static class ComparatorString
{
    public static int ComputeComparatorStringNaive(string str)
    {
        int i = 0;
        int count = 1;
        List<int> countList = new();
        while (i < str.Length)
        {
            var current = str[i];
            for (var j = i + 1; j < str.Length; j++)
            {
                if (str[j] != str[i])
                {
                    countList.Add(count);
                    count = 1;
                    i = j;
                    break;
                }
                else
                {
                    count++;
                    if (j == str.Length - 1)
                    {
                        countList.Add(count);
                        count = 1;
                        i = j;
                        break;
                    }
                }
            }
            if (i == str.Length - 1) break;
        }
        return countList.Max() + 1;
    }
    public static int ComputeComparatorStringEfficent(string str)
    {
        var s1=str.Split(">").Max().Length;
        var s2=str.Split("<").Max().Length;
        if(s1>s2) return s1+1;
        else return s2+1;
    }
}
// public class Program
// {
//     public static void Main()
//     {
//         List<string> strList=new();
//         int n = int.Parse(Console.ReadLine());
//         for (var i = 0; i < n; i++)
//         {
//             int nStr = int.Parse(Console.ReadLine());
//             string str = Console.ReadLine();
//             strList.Add(str);
//         }
//         foreach (var item in strList)
//         {
//             Console.WriteLine(ComparatorString.ComputeComparatorStringEfficent(item));
//         }
//     }
// }