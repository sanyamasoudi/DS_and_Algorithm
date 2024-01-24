// using System;
using System;

public static class OptimalAlignment
{
    public static Tuple<string, string> CalculateAlignment(string s1, string s2, int mismatchPenalty, int indelPenalty)
    {
        int rows = s1.Length + 1;
        int cols = s2.Length + 1;
        int[,] scoreMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            scoreMatrix[i, 0] = i * indelPenalty;
        }

        for (int j = 0; j < cols; j++)
        {
            scoreMatrix[0, j] = j * indelPenalty;
        }

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                int insertion = scoreMatrix[i, j - 1] + indelPenalty;
                int deletion = scoreMatrix[i - 1, j] + indelPenalty;
                int match = scoreMatrix[i - 1, j - 1];
                int mismatch = scoreMatrix[i - 1, j - 1] + mismatchPenalty;
                if (s1[i - 1] == s2[j - 1])
                {
                    scoreMatrix[i, j] = Math.Min(Math.Min(insertion, deletion), match);
                }
                else
                {
                    scoreMatrix[i, j] = Math.Min(Math.Min(insertion, deletion), mismatch);
                }
            }
        }

        string alignS1 = "";
        string alignS2 = "";
        int row = rows - 1;
        int col = cols - 1;

        while (row > 0 || col > 0)
        {
            if (row > 0 && col > 0 && scoreMatrix[row, col] == scoreMatrix[row - 1, col - 1] + (s1[row - 1] == s2[col - 1] ? 0 : mismatchPenalty))
            {
                alignS1 = s1[row - 1] + alignS1;
                alignS2 = s2[col - 1] + alignS2;
                row--;
                col--;
            }
            else if (row > 0 && scoreMatrix[row, col] == scoreMatrix[row - 1, col] + indelPenalty)
            {
                alignS1 = s1[row - 1] + alignS1;
                alignS2 = "-" + alignS2;
                row--;
            }
            else
            {
                alignS1 = "-" + alignS1;
                alignS2 = s2[col - 1] + alignS2;
                col--;
            }
        }

        return new Tuple<string, string>(alignS1, alignS2);
    }

}
// 

// public static class OptimalAlignment
// {
//     public static Tuple<string, string> CalculateAlignment(string s1, string s2, int mismatchPenalty, int indelPenalty)
//     {
//         int rows = s1.Length + 1;
//         int cols = s2.Length + 1;
//         int[,] scoreMatrix = new int[rows, cols];

//         for (int i = 0; i < rows; i++)
//         {
//             scoreMatrix[i, 0] = i * indelPenalty;
//         }

//         for (int j = 0; j < cols; j++)
//         {
//             scoreMatrix[0, j] = j * indelPenalty;
//         }

//         for (int i = 1; i < rows; i++)
//         {
//             for (int j = 1; j < cols; j++)
//             {
//                 int mismatch = s1[i - 1] == s2[j - 1] ? 0 : mismatchPenalty;
//                 scoreMatrix[i, j] = Math.Max(
//                     scoreMatrix[i - 1, j - 1] + mismatch,
//                     Math.Max(scoreMatrix[i - 1, j] + indelPenalty, scoreMatrix[i, j - 1] + indelPenalty)
//                 );
//             }
//         }

//         string alignS1 = "";
//         string alignS2 = "";
//         int row = rows - 1;
//         int col = cols - 1;

//         while (row > 0 || col > 0)
//         {
//             if (row > 0 && col > 0 && scoreMatrix[row, col] == scoreMatrix[row - 1, col - 1] + (s1[row - 1] == s2[col - 1] ? 0 : mismatchPenalty))
//             {
//                 alignS1 = s1[row - 1] + alignS1;
//                 alignS2 = s2[col - 1] + alignS2;
//                 row--;
//                 col--;
//             }
//             else if (row > 0 && scoreMatrix[row, col] == scoreMatrix[row - 1, col] + indelPenalty)
//             {
//                 alignS1 = s1[row - 1] + alignS1;
//                 alignS2 = "-" + alignS2;
//                 row--;
//             }
//             else
//             {
//                 alignS1 = "-" + alignS1;
//                 alignS2 = s2[col - 1] + alignS2;
//                 col--;
//             }
//         }

//         return new Tuple<string, string>(alignS1, alignS2);
//     }

// }
// // 
