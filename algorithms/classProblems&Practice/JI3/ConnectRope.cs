public class ConnectRope
{
    public static int MinimalCost(int[] costs)
    {
        Array.Sort(costs);
        if (costs.Length % 2 != 0)
        {
            var lastEle = costs[^1];
            costs = costs.Where(x => x != lastEle).ToArray();
        }
        return costs.Sum();
    }
}