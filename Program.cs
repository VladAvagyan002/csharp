//1Show the horse strokes in the matrix [8,8]
using System;

class ChessKnightMoves
{
    static void Main()
    {
        Console.Write("Enter the row (0-7) of the knight: ");
        int knightRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the knight: ");
        int knightColumn = int.Parse(Console.ReadLine());

        Console.WriteLine("Knight's Possible Moves:");
        DisplayValidMoves(knightRow, knightColumn);
    }

    static void DisplayValidMoves(int knightRow, int knightColumn)
    {
        int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };

        for (int i = 0; i < 8; i++)
        {
            int newRow = knightRow + dx[i];
            int newCol = knightColumn + dy[i];

            if (IsValidPosition(newRow, newCol))
            {
                Console.WriteLine($"({newRow}, {newCol})");
            }
        }
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
//2Show the queen strokes in the matrix [8,8]
using System;

class ChessQueenMoves
{
    static void Main()
    {
        Console.Write("Enter the row (0-7) of the queen: ");
        int queenRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the queen: ");
        int queenColumn = int.Parse(Console.ReadLine());

        Console.WriteLine("Queen's Possible Moves:");
        DisplayValidMoves(queenRow, queenColumn);
    }

    static void DisplayValidMoves(int queenRow, int queenColumn)
    {
        Console.WriteLine("Matrix showing Queen's Possible Moves (1) and Current Position (2):");
        int[,] chessboard = new int[8, 8];

        MarkValidMoves(chessboard, queenRow, queenColumn);

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static void MarkValidMoves(int[,] chessboard, int queenRow, int queenColumn)
    {
        MarkHorizontalVertical(chessboard, queenRow, queenColumn);
        MarkDiagonals(chessboard, queenRow, queenColumn);
    }

    static void MarkHorizontalVertical(int[,] chessboard, int row, int col)
    {
        for (int i = 0; i < 8; i++)
        {
            chessboard[row, i] = 1; // Marking horizontal moves
            chessboard[i, col] = 1; // Marking vertical moves
        }
    }

    static void MarkDiagonals(int[,] chessboard, int row, int col)
    {
        for (int i = 0; i < 8; i++)
        {
            if (IsValidPosition(row + i, col + i))
                chessboard[row + i, col + i] = 1; // Marking diagonals (up-right)

            if (IsValidPosition(row - i, col + i))
                chessboard[row - i, col + i] = 1; // Marking diagonals (up-left)

            if (IsValidPosition(row + i, col - i))
                chessboard[row + i, col - i] = 1; // Marking diagonals (down-right)

            if (IsValidPosition(row - i, col - i))
                chessboard[row - i, col - i] = 1; // Marking diagonals (down-left)
        }
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
}
//3 Randomly place queens on the chessboard so that they do not hit each other.
using System;
 
class GFG
{

    static double possiblePositions(double n)
    {
        double term1 = Math.Pow(n, 4);
        double term2 = Math.Pow(n, 3);
        double term3 = Math.Pow(n, 2);
        double term4 = n / 3;
        double ans = (Math.Ceiling(term1 / 2)) -
                     (Math.Ceiling(5 * term2) / 3) +
                     (Math.Ceiling(3 * term3) / 2) - term4;

        return (long)ans;
    }

    public static void Main(String[] args)
    {
        double n;
        n = 3;

        double ans = possiblePositions(n);
        Console.Write(ans + "\n");
    }
}
//4 The horse (knight) will step from the mentioned field with random free fields once.
using System; 
  
class GFG
{
    static int N = 8;

    static bool isSafe(int x, int y, int[,] sol)
    {
        return (x >= 0 && x < N && y >= 0 && y < N
                && sol[x, y] == -1);
    }

    static void printSolution(int[,] sol)
    {
        for (int x = 0; x < N; x++)
        {
            for (int y = 0; y < N; y++)
                Console.Write(sol[x, y] + " ");
            Console.WriteLine();
        }
    }


    static bool solveKT()
    {
        int[,] sol = new int[8, 8];

        for (int x = 0; x < N; x++)
            for (int y = 0; y < N; y++)
                sol[x, y] = -1;


        int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        sol[0, 0] = 0;

        if (!solveKTUtil(0, 0, 1, sol, xMove, yMove))
        {
            Console.WriteLine("Solution does "
                              + "not exist");
            return false;
        }
        else
            printSolution(sol);

        return true;
    }

    static bool solveKTUtil(int x, int y, int movei,
                            int[,] sol, int[] xMove,
                            int[] yMove)
    {
        int k, next_x, next_y;
        if (movei == N * N)
            return true;

        for (k = 0; k < 8; k++)
        {
            next_x = x + xMove[k];
            next_y = y + yMove[k];
            if (isSafe(next_x, next_y, sol))
            {
                sol[next_x, next_y] = movei;
                if (solveKTUtil(next_x, next_y, movei + 1,
                                sol, xMove, yMove))
                    return true;
                else
                    sol[next_x, next_y] = -1;
            }
        }

        return false;
    }

    public static void Main()
    {
        solveKT();
    }
} 
//5 Saddle point. Given an MxN integer size matrix. Determine and find the matrix element that is largest in its row and smallest in its column. If no such element exists, display the message "no".
using System;

class GFG
{

    static bool findSaddlePoint(int[,] mat,
                                int n)
    {

        for (int i = 0; i < n; i++)
        {


            int min_row = mat[i, 0], col_ind = 0;
            for (int j = 1; j < n; j++)
            {
                if (min_row > mat[i, j])
                {
                    min_row = mat[i, j];
                    col_ind = j;
                }
            }


            int k;
            for (k = 0; k < n; k++)

                if (min_row < mat[k, col_ind])
                    break;


            if (k == n)
            {
                Console.WriteLine("Value of Saddle Point "
                                                + min_row);
                return true;
            }
        }


        return false;
    }

    public static void Main()
    {
        int[,] mat = {{1, 2, 3},
                    {4, 5, 6},
                    {7, 8, 9}};

        int n = 3;
        if (findSaddlePoint(mat, n) == false)
            Console.WriteLine("No Saddle Point ");
    }
}
//6 Randomly fill non-repeating numbers in an NxM matrix.
using System;
 
public class GFG
{

    static int numberOfPaths(int m, int n)
    {
        if (m == 1 || n == 1)
            return 1;

        return numberOfPaths(m - 1, n)
            + numberOfPaths(m, n - 1);
    }

    static public void Main()
    {
        Console.WriteLine(numberOfPaths(3, 3));
    }
}
