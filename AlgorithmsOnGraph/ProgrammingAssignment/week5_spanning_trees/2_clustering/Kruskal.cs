


public class Kruskal
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Vertex[] vertices = new Vertex[n];
        for (var i = 0; i < n; i++)
        {
            var vertex = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            vertices[i] = new Vertex(vertex[0], vertex[1]);
        }
        int k = int.Parse(Console.ReadLine());
        double result = MinDist(vertices, n, k);
        string formatedResult = result.ToString("0.000000000");
    }

    private static double MinDist(Vertex[] vertices, int n, int k)
    {
        List<Edge> edges = new List<Edge>();
        for (var i = 0; i < n; i++)
        {
            double min = double.MaxValue;
            int minIdx = 0;
            for (var j = 0; j < n && j != i; j++)
            {
                var d = Weight(vertices[i], vertices[j]);
                if (d < min)
                {
                    min = d;
                    minIdx = j;
                }
            }
            edges.Add(new Edge(vertices[i], vertices[minIdx], min));
        }
        edges.Sort((Edge x, Edge y) => x.weight.CompareTo(y.weight));
        for (var i = 0; i < k; i++)
        {
            foreach (var edge in edges)
            {
                if (Find(edge.x) != Find(edge.y))
                {
                    Union(edge.x, edge.y);
                }
            }
        }
    }

    private static double Weight(Vertex vertex1, Vertex vertex2)
    {
        return Math.Sqrt(Math.Pow(vertex1.x - vertex2.x, 2) + Math.Pow(vertex1.y - vertex2.y, 2));
    }

    private static void Union(Vertex u, Vertex v)
    {
        if (u.rank < v.rank)
        {
            u.parent = v;
        }
        else if (u.rank > v.rank)
        {
            v.parent = u;
        }
        else
        {
            v.parent = u;
            u.rank++;
        }
    }

    private static Vertex Find(Vertex u)
    {
        if (u.parent != u)
        {
            u.parent = Find(u.parent);
        }
        return u.parent;
    }
}

public class Edge
{
    public Vertex x, y;
    public double weight;
    public Edge(Vertex x, Vertex y, double w)
    {
        this.x = x;
        this.y = y;
        this.weight = w;
    }
}

public class Vertex
{
    public int x, y;
    public Vertex parent;
    public int rank;
    public Vertex(int x, int y)
    {
        this.x = x;
        this.y = y;
        parent = this;
    }
}