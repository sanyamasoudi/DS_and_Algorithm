using System;
using System.Collections;
using System.Collections.Generic;
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         var str = Console.ReadLine();
//         CheckBracket2.Check(str);
//     }
// }
public class Bracket
{
    public char type;
    public int position;
    public Bracket(char type, int position)
    {
        this.type = type;
        this.position = position;
    }

    public bool Match(char c)
    {
        if (this.type == '[' && c == ']')
            return true;
        if (this.type == '{' && c == '}')
            return true;
        if (this.type == '(' && c == ')')
            return true;
        return false;
    }

}
public static class CheckBracket2
{
    public static void Check(string str)
    {
        Stack<Bracket> stack = new Stack<Bracket>();
        List<char> brackets = new List<char>() { '(', ')', '[', ']', '{', '}' };
        List<char> openingBrackets = new List<char>() { '(', '[', '{' };
        List<char> closingBrackets = new List<char>() { ')', ']', '}' };
        int FirstUnmatchedClosingPos = 0;
        bool BoolFirstUnmatchedClosing = false;
        for (var i = 0; i < str.Length; i++)
        {
            var myChar = str[i];
            if (openingBrackets.Contains(myChar))
            {
                stack.Push(new Bracket(myChar, i));
            }
            if (closingBrackets.Contains(myChar))
            {
                if (stack.Count == 0)
                {
                    stack.Push(new Bracket(myChar, i));
                    if (!BoolFirstUnmatchedClosing)
                    {
                        FirstUnmatchedClosingPos = i;
                        BoolFirstUnmatchedClosing = true;
                        break;
                    }
                }
                else
                {
                    var p = stack.Peek();
                    if (p.Match(myChar))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        if (!BoolFirstUnmatchedClosing)
                        {
                            FirstUnmatchedClosingPos = i;
                            BoolFirstUnmatchedClosing = true;
                            break;
                        }
                    }
                }
            }
        }
        if (stack.Count == 0)
        {
            Console.WriteLine("Success");
        }
        else
        {
            if (BoolFirstUnmatchedClosing)
            {
                Console.WriteLine(FirstUnmatchedClosingPos + 1);
            }
            else
            {
                var x = stack.ToArray();
                Console.WriteLine(x[x.Length - 1].position + 1);
            }
        }
    }
}