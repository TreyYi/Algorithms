using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queen_Problem
{
    class Program
    {

        public static int N = 8;
        public static int k = 1;

        // driver program to test above function
        public static void Main(String[] args)
        {
            Program p = new Program();
            solveNQ(N);
            Console.ReadLine();
        }

        /* A utility function to print solution */
        public static void printSolution(int[,] board)
        {
            //int k = 1;
            Console.WriteLine("Solution " + (k++)+ " is below:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + board[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        
        public static bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        /* A recursive utility function */
        public static bool solveNQUtil(int[,] board, int col)
        {
            /* base case: If all queens are placed
            then return true */
            if (col == N)
            {
                printSolution(board);
                return true;
            }

            /* Consider this column and try placing
            this queen in all rows one by one */
            for (int i = 0; i < N; i++)
            {
                /* Check if queen can be placed on
                board[i][col] */
                if (isSafe(board, i, col))
                {
                    /* Place this queen in board[i][col] */
                    board[i, col] = 1;

                    /* recur to place rest of the queens */
                    solveNQUtil(board, col + 1);

                    // below commented statement is replaced
                    // by above one
                    /* if ( solveNQUtil(board, col + 1) )
                         return true;*/

                    /* If placing queen in board[i][col]
                    doesn't lead to a solution, then
                    remove queen from board[i][col] */
                    board[i, col] = 0; // BACKTRACK
                }
            }

            /* If queen can not be place in any row in
                this column col then return false */
            return false;
        }

        /* This function solves the N Queen problem using
        Backtracking. It mainly uses solveNQUtil() to
        solve the problem. It returns false if queens
        cannot be placed, otherwise return true and
        prints placement of queens in the form of 1s.
        Please note that there may be more than one
        solutions, this function prints one of the
        feasible solutions.*/
        public static void solveNQ(int n)
        {
            int[,] board = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i, j] = 0;

                }
            }

            if (solveNQUtil(board, 0))
            {
                Console.WriteLine("Solution does not exist");
            }

        }



    }
}