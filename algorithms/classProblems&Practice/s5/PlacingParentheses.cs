using System;


class ParenthesesMinMax
{
    static (int, int) MinAndMax(int i, int j, int[] numbers, char[] operators, int[,] m, int[,] M)
    {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int k = i; k < j; k++)
        {
            char op = operators[k - 1];
            int a = PerformOperation(M[i, k], op, M[k + 1, j]);
            int b = PerformOperation(M[i, k], op, m[k + 1, j]);
            int c = PerformOperation(m[i, k], op, M[k + 1, j]);
            int d = PerformOperation(m[i, k], op, m[k + 1, j]);

            min = Math.Min(min, Math.Min(a, Math.Min(b, Math.Min(c, d))));
            max = Math.Max(max, Math.Max(a, Math.Max(b, Math.Max(c, d))));
        }

        return (min, max);
    }

    static int PerformOperation(int a, char op, int b)
    {
        if (op == '+')
            return a + b;
        else if (op == '-')
            return a - b;
        else if (op == '*')
            return a * b;
        // Add more operations as needed

        throw new ArgumentException("Invalid operation");
    }
    //O(n^3)
    static int EvaluateExpression(string expression)
    {
        string[] tokens = expression.Split(' ');
        int n = (tokens.Length + 1) / 2;
        int[] numbers = new int[n];
        char[] operators = new char[n - 1];

        int numIndex = 0;
        int opIndex = 0;

        for (int i = 0; i < tokens.Length; i++)
        {
            if (i % 2 == 0)
            {
                numbers[numIndex] = int.Parse(tokens[i]);
                numIndex++;
            }
            else
            {
                operators[opIndex] = tokens[i][0];
                opIndex++;
            }
        }

        int[,] m = new int[n+1, n+1];
        int[,] M = new int[n+1, n+1];

        for (int i = 1; i <= n; i++)
        {
            m[i, i] = numbers[i - 1];
            M[i, i] = numbers[i - 1];
        }

        for (int s = 1; s <= n - 1; s++)
        {
            for (int i = 1; i <= n - s; i++)
            {
                int j = i + s;
                (m[i, j], M[i, j]) = MinAndMax(i, j, numbers, operators, m, M);
            }
        }

        return M[1, n];
    }

    public static void Main()
    {
        string expression = "5 - 8 + 7 * 4 - 8 + 9";
        int result = EvaluateExpression(expression);
        Console.WriteLine("Maximum value: " + result);
    }
}
