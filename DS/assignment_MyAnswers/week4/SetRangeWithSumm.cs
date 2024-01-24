using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
public class VertexPair
{
    public Vertex left;
    public Vertex right;
    public VertexPair()
    {
    }
    public VertexPair(Vertex left, Vertex right)
    {
        this.left = left;
        this.right = right;
    }
}
// Splay tree implementation

// Vertex of a splay tree
public class Vertex
{
    public int key;
    // Sum of all the keys in the subtree - remember to update
    // it after each operation that changes the tree.
    public long sum;
    Vertex _left;
    Vertex _right;
    public Vertex left
    {
        get
        {
            return _left;
        }
        set
        {
            _left = value;
            if (value != null) value.parent = this;
        }
    }
    public Vertex right
    {
        get
        {
            return _right;
        }
        set
        {
            _right = value;
            if (value != null) value.parent = this;
        }
    }
    public Vertex parent;

    public Vertex(int key, long sum, Vertex left, Vertex right, Vertex parent)
    {
        this.key = key;
        this.sum = sum;
        this.left = left;
        this.right = right;
        this.parent = parent;
    }
}
public class SetRangeSum
{
    public static void update(Vertex v)
    {
        if (v == null) return;
        v.sum = v.key + (v.left != null ? v.left.sum : 0) + (v.right != null ? v.right.sum : 0);
        if (v.left != null)
        {
            v.left.parent = v;
        }
        if (v.right != null)
        {
            v.right.parent = v;
        }
    }

    public static void smallRotation(Vertex v)
    {
        Vertex parent = v.parent;
        if (parent == null)
        {
            return;
        }
        Vertex grandparent = v.parent.parent;
        if (parent.left == v)
        {
            Vertex m = v.right;
            v.right = parent;
            parent.left = m;
        }
        else
        {
            Vertex m = v.left;
            v.left = parent;
            parent.right = m;
        }
        update(parent);
        update(v);
        v.parent = grandparent;
        if (grandparent != null)
        {
            if (grandparent.left == parent)
            {
                grandparent.left = v;
            }
            else
            {
                grandparent.right = v;
            }
        }
    }

    public static void bigRotation(Vertex v)
    {
        if (v.parent.left == v && v.parent.parent.left == v.parent)
        {
            // Zig-zig
            smallRotation(v.parent);
            smallRotation(v);
        }
        else if (v.parent.right == v && v.parent.parent.right == v.parent)
        {
            // Zig-zig
            smallRotation(v.parent);
            smallRotation(v);
        }
        else
        {
            // Zig-zag
            smallRotation(v);
            smallRotation(v);
        }
    }

    // Makes splay of the given vertex and returns the new root.
    public static Vertex splay(Vertex v)
    {
        if (v == null) return null;
        while (v.parent != null)
        {
            if (v.parent.parent == null)
            {
                smallRotation(v);
                break;
            }
            bigRotation(v);
        }
        return v;
    }


    // Searches for the given key in the tree with the given root
    // and calls splay for the deepest visited node after that.
    // Returns pair of the result and the new root.
    // If found, result is a pointer to the node with the given key.
    // Otherwise, result is a pointer to the node with the smallest
    // bigger key (next value in the order).
    // If the key is bigger than all keys in the tree,
    // then result is null.
    public static VertexPair find(Vertex root, int key)
    {
        Vertex v = root;
        Vertex last = root;
        Vertex next = null;
        while (v != null)
        {
            if (v.key >= key && (next == null || v.key < next.key))
            {
                next = v;
            }
            last = v;
            if (v.key == key)
            {
                break;
            }
            if (v.key < key)
            {
                v = v.right;
            }
            else
            {
                v = v.left;
            }
        }
        root = splay(last);
        return new VertexPair(next, root);
    }

    public static VertexPair split(Vertex root, int key)
    {
        VertexPair result = new VertexPair();
        VertexPair findAndRoot = find(root, key);
        root = findAndRoot.right;
        result.right = findAndRoot.left;
        if (result.right == null)
        {
            result.left = root;
            return result;
        }
        result.right = splay(result.right);
        result.left = result.right.left;
        result.right.left = null;
        if (result.left != null)
        {
            result.left.parent = null;
        }
        update(result.left);
        update(result.right);
        return result;
    }

    public static Vertex merge(Vertex left, Vertex right)
    {
        if (left == null) return right;
        if (right == null) return left;
        while (right.left != null)
        {
            right = right.left;
        }
        right = splay(right);
        right.left = left;
        update(right);
        return right;
    }

    // Code that uses splay tree to solve the problem

    public static Vertex root = null;

    public static void insert(int x)
    {
        Vertex left = null;
        Vertex right = null;
        Vertex new_vertex = null;
        VertexPair leftRight = split(root, x);
        left = leftRight.left;
        right = leftRight.right;
        if (right == null || right.key != x)
        {
            new_vertex = new Vertex(x, x, null, null, null);
        }
        root = merge(left, merge(new_vertex, right));
        if (root != null) root.parent = null;

        // root = splay(root);
        // update(root);
        // update(new_vertex);
        // update(left);
        // update(right);
    }
    public static void erase(int x)
    {
        var p = find(root, x);
        root = p.right;
        if (p.left != null && p.left.key == x)
        {
            root = splay(p.left);
            update(root);
            root = merge(root.left, root.right);
            if(root!=null)root.parent = null;
            // root = splay(root);
            // update(root);
        }
    }
    public static bool find(int x)
    {
        var findAndRoot = find(root, x);
        root = findAndRoot.right;
        if (root != null) root.parent = null;
        // root = splay(root);
        // update(root);
        var findElement = findAndRoot.left;
        if (findElement == null)
        {
            return false;
        }
        else if (findElement.key == x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static long sum(int from, int to)
    {
        if (root == null) return 0;
        VertexPair leftMiddle = split(root, from);
        Vertex left = leftMiddle.left;
        Vertex middle = leftMiddle.right;
        VertexPair middleRight = split(middle, to + 1);
        middle = middleRight.left;
        Vertex right = middleRight.right;
        long ans = 0;
        if (middle != null)
        {
            ans += middle.sum;
        }
        root = merge(left, merge(middle, right));
        root = splay(root);
        update(root);
        update(left);
        update(middle);
        update(right);
        return ans;
    }

    public static int MODULO = 1000000001;
    public static void solve()
    {
        int n = int.Parse(Console.ReadLine());
        int last_sum_result = 0;
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Trim().Split().ToArray();
            switch (input[0])
            {
                case "+":
                    {
                        int x = int.Parse(input[1]);
                        insert((x + last_sum_result) % MODULO);
                    }
                    break;
                case "-":
                    {
                        int x = int.Parse(input[1]);
                        erase((x + last_sum_result) % MODULO);
                    }
                    break;
                case "?":
                    {
                        int x = int.Parse(input[1]);
                        Console.WriteLine(find((x + last_sum_result) % MODULO) ? "Found" : "Not found");
                    }
                    break;
                case "s":
                    {
                        int l = int.Parse(input[1]);
                        int r = int.Parse(input[2]);
                        long res = sum((l + last_sum_result) % MODULO, (r + last_sum_result) % MODULO);
                        Console.WriteLine(res);
                        last_sum_result = (int)(res % MODULO);
                        break;
                    }
                case "p":
                    {
                        Print(root, 0);
                        break;
                    }
                default:
                    break;
            }
        }
    }

    private static void Print(Vertex root, int s)
    {
        if (root == null)
        {
            return;
        }
        Print(root.right, s + 10);
        for (var i = 0; i < s; i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(root.key);
        Print(root.left, s + 10);
    }

    // public static void Main(String[] args)
    // {
    //     solve();
    // }
}