using System;

public static class OutputAlignment
{
    public static void ComputeOutput(int i, int j, int[,] scoreMatrix, string A, string B)
    {
        if (i == 0 && j == 0)
            return;

        if (i > 0 && scoreMatrix[i, j] == scoreMatrix[i - 1, j] + 1)
        {
            ComputeOutput(i - 1, j, scoreMatrix, A, B);
            Console.WriteLine("A: " + A[i - 1]);
        }
        else if (j > 0 && scoreMatrix[i, j] == scoreMatrix[i, j - 1] + 1)
        {
            ComputeOutput(i, j - 1, scoreMatrix, A, B);
            Console.WriteLine("B: " + B[j - 1]);
        }
        else
        {
            ComputeOutput(i - 1, j - 1, scoreMatrix, A, B);
            Console.WriteLine("A&B: " + A[i - 1] + ", " + B[j - 1]);
        }
    }
}
