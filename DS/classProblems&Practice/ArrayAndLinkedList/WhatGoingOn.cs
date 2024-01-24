public class Program
{
    public static void Main(string[] args)
    {
        Noden six = new Noden(6, null, null);
        Noden seven = new Noden(7, null, null);
        Noden four = new Noden(4, six, seven);
        Noden three = new Noden(3, null, null);
        Noden five = new Noden(5, null, null);
        Noden one = new Noden(1, three, four);
        Noden two = new Noden(2, five, null);
        Noden zero = new Noden(0, one, two);
        WhatGoingOn.Traversal2(zero);
    }
}
public class Noden
{
    public int value;
    public Noden left;
    public Noden right;
    public Noden(int v, Noden l, Noden r)
    {
        value = v;
        left = l;
        right = r;
    }
}

public static class WhatGoingOn
{
    public static void Traversal1(Noden node)
    {
        if (node == null) return;
        if (node.left != null)
        {
            Traversal1(node.left.right);
        }
        Console.WriteLine(node.value);
        if (node.right != null)
        {
            Traversal1(node.right.left);
        }
    }
    public static int Traversal2(Noden node)
    {
        if (node == null) return 0;
        int val=Traversal2(node.left)+Traversal2(node.right);
        Console.WriteLine(Math.Max(node.value,val));
        return Math.Max(node.value,val);
    }
}