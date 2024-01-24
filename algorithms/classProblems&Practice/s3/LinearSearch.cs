public static class LinearSearch
{
    
    // T(n) is worst case runtime
    // T(n)=T(n-1)+c
    //  --> c is work
    //Bigteta(n)
    // O(n)
    
    //recursive solution
    public static int? ComputeNaive(int[] arr, int lowBound, int highBound, int key)
    {
        if (lowBound > highBound)
        {
            Console.WriteLine("NotFound");
            return null;
        }
        if (arr[lowBound] == key)
        {
            return lowBound;
        }
        return ComputeNaive(arr, lowBound + 1, highBound, key);
    }
    //iterative solution
    public static int? ComputeEfficent(int[] arr, int lowBound, int highBound, int key)
    {

        while (lowBound <= highBound)
        {
            if (arr[lowBound] == key)
            {
                return lowBound;
            }
            lowBound++;
        }
        Console.WriteLine("NotFound");
        return null;
    }
}