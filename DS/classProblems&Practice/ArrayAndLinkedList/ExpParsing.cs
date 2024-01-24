public static class ExpParsing
{
    public static int ComputeResultOfExp(string str)
    {
        Stack<int> stack = new Stack<int>();
        for (var i = 0; i < str.Length; i++)
        {
            if (!Char.IsDigit(str[i]))
            {
                var p = stack.Pop();
                int a = Perfom(int.Parse(p.ToString()), str[i], int.Parse(str[i + 1].ToString()));
                stack.Push(a);
                i++;
            }
            else
            {
                stack.Push(int.Parse(str[i].ToString()));
            }
        }
        return stack.Pop();
    }

    private static int Perfom(int v1, char v2, int v3)
    {
        switch (v2)
        {
            case '*':
                return v1 * v3;
            case '+':
                return v1 + v3;
            case '-':
                return v1 - v3;
            case '/':
                return v1 / v3;
            default:
                return 0;
        }

    }

}
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var str = Console.ReadLine();
//         var result = ExpParsing.ComputeResultOfExp(str);
//         Console.WriteLine(result);
//     }
// }