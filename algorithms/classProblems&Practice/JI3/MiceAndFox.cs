public class MiceAndFox
{
    public static int ComputeMinDist(int[] m, int[] h)
    {
        h = h.Order().ToArray();
        m = m.Order().ToArray();
        int result = 0;
        for (var i = 0; i < m.Length; i++)
        {
            result += Math.Abs(m[i] - h[i])-1;
        }
        return result;
    }
}