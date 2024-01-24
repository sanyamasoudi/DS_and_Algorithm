using System;
using System.Collections.Generic;

public static class TwoRocksGame
{
    public static bool Compute(int left, int right, List<Tuple<int, int>> moveMatrix)
    {
        // Create a score matrix
        bool[,] scoreMatrix = new bool[left + 1, right + 1];

        // Initialize the score matrix
        for (int i = 0; i <= left; i++)
        {
            for (int j = 0; j <= right; j++)
            {
                scoreMatrix[i, j] = false; // Initialize all values to false
            }
        }

        // Fill the matrix with game results
        for (int i = 0; i <= left; i++)
        {
            for (int j = 0; j <= right; j++)
            {
                // If the current state is a winning position for the player who is about to move
                if (!scoreMatrix[i, j])
                {
                    // Check all possible moves
                    foreach (var move in moveMatrix)
                    {
                        int iPrin = i - move.Item1;
                        int jPrin = j - move.Item2;

                        // If the move is valid and leads to a losing position for the opponent, it's a winning position
                        if (iPrin >= 0 && jPrin >= 0 && !scoreMatrix[iPrin, jPrin])
                        {
                            scoreMatrix[i, j] = true;
                            break; // Once a winning move is found, no need to check further
                        }
                    }
                }
            }
        }
        Console.WriteLine("Score Matrix:");
        Console.WriteLine();
        for (var i = 0; i <= right; i++)
        {
            for (var j = 0; j <= left; j++)
            {
                Console.Write(scoreMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        // The initial state represents the opponent's turn, so return whether it's a winning position for the opponent.
        return scoreMatrix[left, right];
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int leftPile = 10;
//         int rightPile = 10;

//         // List<Tuple<int, int>> moves = new()
//         // {
//         //     new Tuple<int, int>(1, 0), // Taking one rock from the first pile
//         //     new Tuple<int, int>(0, 1), // Taking one rock from the second pile
//         //     new Tuple<int, int>(1, 1) // Taking one rock from both piles
//         // };
//         List<Tuple<int, int>> moves = new()
//         {
//             new Tuple<int, int>(0, 1), // Taking one rock from the first pile
//             new Tuple<int, int>(0, 2), // Taking one rock from the second pile
//             new Tuple<int, int>(0, 3), // Taking one rock from both piles
//             new Tuple<int, int>(1, 0),
//             new Tuple<int, int>(2, 0),
//             new Tuple<int, int>(3, 0),
//             new Tuple<int, int>(1, 1),
//             new Tuple<int, int>(1, 2),
//             new Tuple<int, int>(2, 1)
//         };


//         bool result = TwoRocksGame.Compute(leftPile, rightPile, moves);

//         Console.WriteLine();
//         Console.WriteLine("Is it a winning position for the opponent? " + result);
//     }
// }
