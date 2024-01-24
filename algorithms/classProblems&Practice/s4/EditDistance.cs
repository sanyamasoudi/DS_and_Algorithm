using System;

public static class EditDistance
{
    public static int ComputeDistance(int[] A, int[] B)
    {
        int rows = A.Length + 1;
        int cols = B.Length + 1;
        int[,] scoreMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            scoreMatrix[i, 0] = i;
        }

        for (int j = 0; j < cols; j++)
        {
            scoreMatrix[0, j] = j;
        }

        for (int j = 1; j < cols; j++)
        {
            for (int i = 1; i < rows; i++)
            {
                int insertion = scoreMatrix[i, j - 1] + 1;
                int deletion = scoreMatrix[i - 1, j] + 1;
                int match = scoreMatrix[i - 1, j - 1];
                int mismatch = scoreMatrix[i - 1, j - 1] + 1;

                if (A[i - 1] == B[j - 1]) 
                {
                    scoreMatrix[i, j] = Math.Min(Math.Min(insertion, deletion), match);
                }
                else
                {
                    scoreMatrix[i, j] = Math.Min(Math.Min(insertion, deletion), mismatch);
                }
            }
        }
        return scoreMatrix[rows - 1, cols - 1]; 
    }
}
