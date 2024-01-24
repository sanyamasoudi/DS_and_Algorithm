public class GreedyAlgorithm
{
    //O(n^2)
    public string FindLargestNumber(int[] nums)
    {
        string ans = "";
        while (nums.Length != 0)
        {
            int max = nums.Max();//O(n)
            int indexMax = Array.IndexOf(nums, max);//O(n)
            nums = nums.Where((_, i) => i != indexMax).ToArray();//O(n^2)
            ans += max;
        }
        return ans;
    }
    public void FindLargestNumberRecurs(int[] nums)
    {
        int max = nums.Max();
        int indexMax = Array.IndexOf(nums, max);
        nums = nums.Where((_, i) => i != indexMax).ToArray();
        Console.WriteLine(max);
        FindLargestNumberRecurs(nums);
    }
    public int CarFueling(int d, int m, int n, int[] stops)
    {
        int refill = 0;
        int A = 0;
        while (stops.Length != 0)
        {
            (int G, stops) = FindMaxItem(A, m, n, stops);
            if (stops.Length == n)
            {
                return -1;
            }
            A = G;
            n = stops.Length;
            refill++;
        }
        if (refill == 1) refill = 0;
        return refill;



    }

    private (int, int[]) FindMaxItem(int a, int m, int n, int[] stops)
    {
        int max = 0;
        for (var i = 0; i < n; i++)
        {
            if (stops[0] < a + m && stops[0] > max)
            {
                max = stops[0];
                stops = stops.Where((_, i) => i != Array.IndexOf(stops, max)).ToArray();
            }
        }
        return (max, stops);
    }
    //running time=O(n)
    public int MinRefills(int[] stops, int n, int L)
    {
        int numRefills = 0;
        int currentRefill = 0;
        while (currentRefill + 1 < n)
        {
            int lastRefill = currentRefill;
            while (currentRefill + 1 < n && stops[currentRefill + 1] - stops[lastRefill] <= L)
            {
                currentRefill++;
            }
            if (currentRefill == lastRefill)
            {
                return -1;
            }
            if (currentRefill <= n)
            {
                numRefills++;
            }
        }
        return numRefills;
    }
    public int MinGroups(int n, List<int> elements)
    {
        elements.Sort();
        int group = 0;
        int currentGroupSize = 0;
        foreach (var elment in elements)
        {
            if (currentGroupSize == 0)
            {
                group++;
                currentGroupSize = n;
            }
            currentGroupSize--;
            if (currentGroupSize == 0)
            {
                currentGroupSize = n;
            }
        }
        return group;
    }
    public int GroupingChildren(List<int> ages)
    {
        ages.Sort();
        int group = 1;
        for (var i = 1; i < ages.Count; i++)
        {
            if (ages[i] - ages[i - 1] > 2)
            {
                group++;
            }
        }
        return group;
    }
    public int QueueArrangement(int n, (int, int)[] treatmentTime)
    {
        int minTimeWaiting = 0;
        treatmentTime = treatmentTime.OrderBy(x => x.Item1).ToArray();
        for (int i = 0; i < treatmentTime.Length; i++)
        {
            minTimeWaiting += treatmentTime[i].Item1 * i;
        }
        foreach (var item in treatmentTime)
        {
            Console.Write(item);
        }
        return minTimeWaiting;
    }
    public void Knapsack(List<int> values, List<int> weights, int W)
    {
        var valuePerUnit = new List<int>();
        for (var i = 0; i < values.Count; i++)
        {
            valuePerUnit.Add(values[i] / weights[i]);
        }
        while (valuePerUnit.Count >= 0)
        {
            int indexMax = valuePerUnit.IndexOf(valuePerUnit.Max());
            W -= weights[indexMax];
            if (W < 0)
            {
                valuePerUnit.RemoveAt(indexMax);
                weights.RemoveAt(indexMax);
                values.RemoveAt(indexMax);
            }
        }
    }
    public void BallInBox(int n, int g)
    {
        float minNumberInEeachGroup = (float)n / (float)g;
        var k = minNumberInEeachGroup;
        int halfGroup = (int)(g / 2);
        for (var i = 1; i <= halfGroup; i++)
        {
            Console.WriteLine(k + i);
        }
        for (var i = 1; i <= halfGroup; i++)
        {
            Console.WriteLine(k - i);
        }
    }
}
public class GreedyAlgorithmMainImplementation
{
    public int MinTotalWaintingTime(int[] treatmentTime, int n)
    {
        // int waitingTime = 0;
        // treatmentTime=treatmentTime.OrderByDescending(x => x).ToArray();
        // for (var i = 0; i < n; i++)
        // {
        //     waitingTime += i * treatmentTime[i];
        // }
        // return waitingTime;

        //naive(with find min each time) = O(n^2)
        //runtime complexity=O(nlog n)
        //space complexity=O(n)
        int waitingTime = 0;
        treatmentTime = treatmentTime.OrderBy(x => x).ToArray();//quick sort O(nlogn)
        for (var i = 1; i <= n; i++)//O(n)
        {
            waitingTime += (n - i) * treatmentTime[i - 1];
        }
        return waitingTime;
    }
    //naive= omega(2^n)
    //O(nlogn)
    public List<(int, int)> PointsCoverSorted(List<int> points)
    {
        points.Sort();//O(nlogn)
        var segments = new List<(int, int)>();
        var left = 1;
        //O(n)
        while (left <= points.Count)
        {
            var lr = (points[left], points[left] + 2);
            segments.Add(lr);
            left++;
            while (left <= points.Count && points[left] <= lr.Item2)
            {
                left++;
            }
        }
        return segments;
    }
    //O(n^2)
    public (int, List<int>) Knapsack(int W, List<int> values, List<int> weights)
    {
        var amounts = new List<int>();
        var totalValue = 0;
        for (var i = 0; i < values.Count; i++)
        {
            if (W == 0) return (totalValue, amounts);
            var indexBestItem = BestItem(values, weights);
            var a = Math.Min(weights[indexBestItem], W);
            totalValue += a * values[indexBestItem] / weights[indexBestItem];
            weights[indexBestItem] -= a;
            amounts[indexBestItem] += a;
            W -= a;
        }
        return (totalValue, amounts);
    }
    public int BestItem(List<int> values, List<int> weights)
    {
        int maxValuePerUnit = 0;
        int bestItem = 0;
        for (var i = 0; i < values.Count; i++)
        {
            if (weights[i] > 0)
            {
                if (values[i] / weights[i] > maxValuePerUnit)
                {
                    maxValuePerUnit = values[i] / weights[i];
                    bestItem = i;
                }
            }
        }
        return bestItem;
    }
    //O(nlogn)
    public (int, List<int>) KnapsackFast(int W, List<int> values, List<int> weights)
    {
        var amounts = new List<int>();
        var totalValue = 0;
        var valuePerUnit = new List<(int, int)>();
        for (var i = 0; i < values.Count; i++)
        {
            valuePerUnit.Add((values[i] / weights[i], i));
        }
        valuePerUnit.OrderByDescending(x => x.Item1);//O(nlogn)
        for (var i = 0; i < values.Count; i++)//O(n)
        {
            if (W == 0) return (totalValue, amounts);
            var indexBestItem = valuePerUnit[i].Item2;
            var a = Math.Min(weights[indexBestItem], W);
            totalValue += a * values[indexBestItem] / weights[indexBestItem];
            weights[indexBestItem] -= a;
            amounts[indexBestItem] += a;
            W -= a;
        }
        return (totalValue, amounts);
    }
    //O(n^2)
    public int Change(int money, int[] denomination)
    {
        int numCoins = 0;
        while (money > 0)
        {
            int maxCoin = denomination.Max();
            money -= maxCoin;
            if (money < 0)
            {
                money += maxCoin;
                denomination = denomination.Where((_, i) => i != Array.IndexOf(denomination, maxCoin)).ToArray();
            }
            else
            {
                numCoins++;
                Console.WriteLine(maxCoin);
            }
        }
        return numCoins;
    }
    //O(nlogn)
    public int ChangeFast(int money, int[] denomination)
    {
        int numCoins = 0; int maxIndex = 0;
        denomination = denomination.OrderDescending().ToArray();
        while (money > 0)
        {
            int maxCoin = denomination[maxIndex];
            money -= maxCoin;
            if (money < 0)
            {
                money += maxCoin;
                denomination = denomination.Where((_, i) => i != maxIndex).ToArray();
            }
            else
            {
                numCoins++;
                Console.WriteLine(maxCoin);
            }
        }
        return numCoins;
    }
    int numCoins = 0;
    public int ChangeFastRecurs(int money, int[] denomination)
    {
        int maxIndex = 0;
        denomination = denomination.OrderDescending().ToArray();
        if (money == 0) return 0;
        int maxCoin = denomination[maxIndex];
        money -= maxCoin;
        if (money < 0)
        {
            money += maxCoin;
            denomination = denomination.Where((_, i) => i != maxIndex).ToArray();
        }
        else
        {
            numCoins++;
            Console.WriteLine(maxCoin);
        }
        ChangeFastRecurs(money, denomination);
        return numCoins;
    }
    public long[] BallInBox(int numBalls, int numBoxes)
    {
        var sumOfFilled=(numBoxes-1)*numBoxes/2;
        var remaining=numBalls-sumOfFilled;
        if(remaining<0) return Array.Empty<long>();
        var result=new long[numBoxes];
        for (var i = 0; i < numBoxes-1; i++)
        {
            result[i]=i+1;
        }
        result[numBoxes-1]=remaining;
        return result;
    }
}
