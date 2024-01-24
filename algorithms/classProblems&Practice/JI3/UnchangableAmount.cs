

public class UnchangableAmount
{
    public static int ComputeMin(List<int> denominations)
    {
        var listSuspectResult = new List<int>();
        foreach (var item in denominations)
        {
            listSuspectResult.Add(2 * item);
        }
        for (var i = 0; i < listSuspectResult.Count; i++)
        {
            if (listSuspectResult[i] > SumBefore(denominations,listSuspectResult, i))
            {
                return listSuspectResult[i];
            }
        }
        return 0;
    }

    private static int SumBefore(List<int> denominations,List<int> listSuspectResult, int index)
    {
        int sum = 0;
        foreach (var item in denominations)
        {
            if(item<=listSuspectResult[index])
            {
                sum+=item;
            }
        }
        return sum;
    }
}