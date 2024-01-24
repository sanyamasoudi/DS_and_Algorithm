public class CookingDinner
{
    public static bool ComputeCooking(int n,int[] cookTime,int[] freshTime)
    {
        int totalTime = 0;
        for (int i = 0; i < n; i++)
        {
            totalTime += cookTime[i];
        }

        // Check if there exists an order that ensures freshness at some point
        for (int i = 0; i < n; i++)
        {
            int remainingFreshness = 0;
            for (int j = i; j < n; j++)
            {
                remainingFreshness += cookTime[j];
                if (remainingFreshness <= freshTime[j] && totalTime - remainingFreshness <= freshTime[j])
                {
                    return true;
                }
            }
        }

        return false;
    }
}
