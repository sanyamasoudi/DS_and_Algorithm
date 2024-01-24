public class SeatTogether
{
    public static int ComputeMin(int n, List<int> k)
    {
        int result = 0;
        if (k.Count % 2 != 0)
        {
            int selected = k.Count / 2;
            for (int i = 0; i < k.Count; i++)
            {
                if (i != selected)
                {
                    result += Math.Abs(k[i] - k[selected]) - 1;
                }
            }
        }
        else
        {
            int selected = (int)(k.Count / 2) - 1;
            for (int i = 0; i < k.Count; i++)
            {
                if (i != selected)
                {
                    result += Math.Abs(k[i] - k[selected]) - 1;
                }
            }
        }
        return result;
    }
    public static int MinMovesToSitTogether(int[] positions, int k)
    {
        Array.Sort(positions); // Sort the positions for easier calculation

        int minMoves = int.MaxValue;
        for (int i = 0; i <= positions.Length - k; i++)
        {
            int start = positions[i];
            int end = positions[i + k - 1];

            // Calculate the number of moves to make friends sit together
            int moves = 0;
            for (int j = start; j <= end; j++)
            {
                moves += Math.Abs(j - positions[i + j - start]);
            }

            minMoves = Math.Min(minMoves, moves);
        }

        return minMoves;
    }
}

