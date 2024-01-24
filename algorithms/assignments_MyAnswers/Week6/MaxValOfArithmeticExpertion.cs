using System;
using System.Linq;
using System.Collections.Generic;

public static class MaxValOfArithmeticExpertion
{
    public static int ComputeParentheses(string str)
    {
        var tokens = TokenizeExpression(str);
        List<int> numbers = new List<int>();
        List<char> operators = new List<char>();
        for (var i = 0; i < tokens.Length; i++)
        {
            if (i % 2 == 0)
            {
                numbers.Add(int.Parse(tokens[i]));
            }
            else
            {
                operators.Add(tokens[i][0]);
            }
        }
        int n = numbers.Count;
        int[,] m = new int[n, n];
        int[,] M = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            M[i, i] = numbers[i];
            m[i, i] = numbers[i];
        }

        for (var s = 1; s < n; s++)
        {
            for (var i = 0; i < n - s; i++)
            {
                int j = i + s;
                MinAndMax(i, j, operators.ToArray(), m, M);
            }
        }
        return M[0, n - 1];
    }

    public static void MinAndMax(int i, int j, char[] op, int[,] m, int[,] M)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (var k = i; k < j; k++)
        {
            int a = PerformOp(M[i, k], op[k], M[k + 1, j]);
            int b = PerformOp(M[i, k], op[k], m[k + 1, j]);
            int c = PerformOp(m[i, k], op[k], M[k + 1, j]);
            int d = PerformOp(m[i, k], op[k], m[k + 1, j]);

            min = Math.Min(min, Math.Min(Math.Min(a, b), Math.Min(c, d)));
            max = Math.Max(max, Math.Max(Math.Max(a, b), Math.Max(c, d)));
        }
        M[i, j] = max;
        m[i, j] = min;
    }

    private static int PerformOp(int v1, char op, int v2)
    {
        if (op == '+')
        {
            return v1 + v2;
        }
        else if (op == '-')
        {
            return v1 - v2;
        }
        else if (op == '*')
        {
            return v1 * v2;
        }
        else
        {
            throw new FormatException("Not a valid operation");
        }
    }

    public static string[] TokenizeExpression(string expression)
    {
        List<string> tokens = new List<string>();
        string currentToken = "";
        foreach (char c in expression)
        {
            if (char.IsDigit(c))
            {
                currentToken += c;
            }
            else
            {
                if (!string.IsNullOrEmpty(currentToken))
                {
                    tokens.Add(currentToken);
                    currentToken = "";
                }
                tokens.Add(c.ToString());
            }
        }
        if (!string.IsNullOrEmpty(currentToken))
        {
            tokens.Add(currentToken);
        }
        return tokens.ToArray();
    }
}

// public class Program
// {
//     public static void Main()
//     {
//         string expression = Console.ReadLine();
//         List<int> numbers = new List<int>();
//         List<char> operators = new List<char>();
//         foreach (var item in expression)
//         {
//             if (item == '+' || item == '-' || item == '*')
//             {
//                 operators.Add(item);
//             }
//             else
//             {
//                 numbers.Add(int.Parse(item.ToString()));
//             }
//         }
//         int result = MaxValOfArithmeticExpertion.ComputeParentheses(expression);
//         Console.WriteLine(result);
//     }
// }



