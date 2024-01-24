public static class BinarySearch
{

    //just for sorted array or collections
    // T(n)=T(Math.Floor(n/2))+c
    //Bigteta(logn)
    // O(logn)

    //recursive solution
    public static int ComputeNaive(int[] arr, int lowBound, int highBound, int key)
    {
        if (lowBound > highBound)
        {
            return lowBound - 1;
        }
        int mid = lowBound + (int)(highBound - lowBound) / 2;
        if (arr[mid] == key)
            return mid;
        else if (arr[mid] < key)
            return ComputeNaive(arr, mid + 1, highBound, key);
        else
            return ComputeNaive(arr, lowBound, mid - 1, key);
    }
    //iterative solution
    public static int ComputeEfficent(int[] arr, int lowBound, int highBound, int key)
    {

        while (lowBound <= highBound)
        {
            int mid = lowBound + (int)(highBound - lowBound) / 2;
            if (arr[mid] == key)
                return mid;
            else if (arr[mid] < key)
                lowBound = mid + 1;
            else
                highBound = mid - 1;
        }
        return lowBound - 1;
    }
}
