using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class StackInterface
{
    public static Stack<int> Stack = new Stack<int>();
    public static Stack<int> MaxStack = new Stack<int>();
    public static List<int> result = new List<int>();
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     for (var i = 0; i < n; i++)
    //     {
    //         var Operator = Console.ReadLine();
    //         if (Operator.Contains("push"))
    //         {
    //             int element = int.Parse(Operator.Trim().Split()[1]);
    //             if (MaxStack.Count == 0)
    //             {
    //                 MaxStack.Push(element);
    //             }
    //             if (MaxStack.Peek() <= element)
    //             {
    //                 MaxStack.Push(element);
    //             }
    //             Stack.Push(element);
    //         }
    //         if (Operator.Contains("pop"))
    //         {
    //             if (MaxStack.Count>0 && Stack.Peek() == MaxStack.Peek()) MaxStack.Pop();
    //             if (Stack.Count>0) Stack.Pop();
    //         }
    //         if (Operator.Contains("max"))
    //         {
    //             int maxint = MaxStack.Peek();
    //             result.Add(maxint);
    //         }
    //     }
    //     Console.WriteLine(String.Join("\n", result));
    // }





    // public static Stack<int> helperStack=new Stack<int>();
    // public static List<int> result=new List<int>();
    // public static void Main(string[] args)
    // {
    //     int n = int.Parse(Console.ReadLine());
    //     for (var i = 0; i < n; i++)
    //     {
    //         var Operator = Console.ReadLine();
    //         if (Operator.Contains("push"))
    //         {
    //             helperStack.Push(int.Parse(Operator.Trim().Split()[1]));
    //         }
    //         if (Operator.Contains("pop"))
    //         {
    //             helperStack.Pop();
    //         }
    //         if (Operator.Contains("max"))
    //         {
    //             int maxint=Max(helperStack);
    //             result.Add(maxint);
    //         }
    //     }
    //     Console.WriteLine(String.Join("\n",result));
    // }

    // private static int Max(Stack<int> helperStack)
    // {
    //     List<int> list=new List<int>();
    //     list=helperStack.ToList();
    //     list.Sort((x,y)=>y.CompareTo(x));
    //     return list[0];
    // }
}