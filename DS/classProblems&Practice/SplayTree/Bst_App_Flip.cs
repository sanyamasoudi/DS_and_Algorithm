public class Bst_App_Flip
{
    FlipNode T1;
    FlipNode T2;
    public (bool[], bool[]) NewArray(int n)
    {
        bool[] WhiteArr = new bool[n];
        bool[] BlackArr = new bool[n];
        Array.Fill(WhiteArr, false);
        Array.Fill(BlackArr, true);
        return (WhiteArr, BlackArr);
    }
    string Color(int m)
    {
        var N = Find(T1, m);
        return N.Color;
    }

    private FlipNode Find(FlipNode root, int m)
    {
        FlipNode next = null;
        while (root != null)
        {
            if ((next == null || next.index > root.index) && root.index >= m)
            {
                next = root;
            }
            if (root.index == m)
            {
                break;
            }
            else if (root.index < m)
            {
                root = root.right;
            }
            else
            {
                root = root.left;
            }
        }
        return next;
    }

    void Flip(int x)
    {
        FlipNodePair splitT1 = Split(T1, x);
        FlipNodePair splitT2 = Split(T2, x);
        T1 = Merge(splitT1.left, splitT2.right, T1);
        T2 = Merge(splitT2.left, splitT1.right, T2);
    }

    private FlipNode Merge(FlipNode left, FlipNode right, FlipNode T)
    {
        T.left = left;
        T.right = right;
        return T;
    }

    private FlipNodePair Split(FlipNode T, int x)
    {
        var p = Find(T, x);
        if(p.parent==null)
        {
            var left=p.left;
            p.left=null;
            return new FlipNodePair(left, p);
        }
        if (p.parent.right == p)
        {
            return new FlipNodePair(p.parent, p);
        }
        else
        {
            return new FlipNodePair(p, p.parent);
        }
    }
}
public class FlipNodePair
{
    public FlipNode right;
    public FlipNode left;
    public FlipNodePair(FlipNode right, FlipNode left)
    {
        this.right = right;
        this.left = left;
    }
}
public class FlipNode
{
    public string Color;
    public int index;
    FlipNode _right;
    public FlipNode right
    {
        get => _right;
        set
        {
            _right = value;
            if (value != null) value.parent = null;
        }
    }
    FlipNode _left;
    public FlipNode left
    {
        get => _left;
        set
        {
            _left = value;
            if (value != null) value.parent = null;
        }
    }
    public FlipNode parent;

    public FlipNode(string m)
    {
        this.Color = m;
    }
}