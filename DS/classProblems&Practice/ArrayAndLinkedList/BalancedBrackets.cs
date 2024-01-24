
public static class BalancedBrackets
{
    // public static void Main(string[] args)
    // {

    //     var str = Console.ReadLine();
    //     var result = MainBalanced(str);
    //     Console.WriteLine(result);
    // }
    public static bool MainBalanced(string str)
    {
        Stack<char> myStack = new Stack<char>();
        List<char> OpeningChars = new List<char>() { '[', '(' };
        foreach (var s in str)
        {
            if (OpeningChars.Contains(s))
            {
                myStack.Push(s);
            }
            else
            {
                if (myStack.Count == 0)
                {
                    return false;
                }
                var top = myStack.Pop();
                if ((top == '[' && s != ']') || (top == '(' && s != ')'))
                {
                    return false;
                }
            }
        }
        return myStack.Count==0;
    }
    public static bool IsBalancedStack(string str)
    {
        if (str.Length == 0)
        {
            return true;
        }
        if ((!str.Contains('[') && !str.Contains(']')) || (!str.Contains('(') && !str.Contains(')')))
        {
            return false;
        }
        Stack<char> stack = new Stack<char>();
        stack.Push(str[0]);
        for (var i = 1; i < str.Length; i++)
        {
            if (Cost(stack.Peek()) + Cost(str[i]) == 0)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(str[i]);
            }
        }
        if (stack.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsBalanced(string str)
    {
        if (str.Length == 0)
        {
            return true;
        }
        if ((!str.Contains('(') && !str.Contains(')')) || (!str.Contains('[') && !str.Contains(']')))
        {
            return false;
        }
        int result = 0;
        for (var i = 0; i < str.Length; i++)
        {
            result += Cost(str[i]);
        }
        if (result == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int Cost(char c)
    {
        switch (c)
        {
            case '(':
                return +1;
            case ')':
                return -1;
            case '[':
                return +2;
            case ']':
                return -2;
            default:
                return 0;
        }

    }
}