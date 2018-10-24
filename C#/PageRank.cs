using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PageRank_Trey
{
    class Program
    {
        static void Main(string[] args)
        {
            double alpha = Convert.ToDouble(Console.ReadLine());
            // Base Case of "r(0)" = 1/7
            double r_0 = 1/7d;
            // create 7x1 matrix which contains 1/7 each
            // example -> matrix[rows, columns]
            double[] matrix_r0 = new double[7] { r_0, r_0, r_0, r_0, r_0, r_0, r_0 };
            
            // create matrix H (value specified matrix)
            double[,] matrix_H = new double[7, 7] { { 0, 0, 0, 0, 0, 0, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0},
                                                    { 0, 1/3d, 0, 0, 0, 0, 0},
                                                    { 0, 1/3d, 0, 0, 0, 0, 1},
                                                    { 0, 1/3d, 1, 1, 0, 0, 0},
                                                    { 0, 0, 0, 0, 1, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0} };
            ///Make matrix S which doesn't contains zero columns
            // create empty 7x7 matrix
            double[,] matrix_S = new double[7, 7] { { 0, 0, 0, 0, 0, 0, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0},
                                                    { 0, 1/3d, 0, 0, 0, 0, 0},
                                                    { 0, 1/3d, 0, 0, 0, 0, 1},
                                                    { 0, 1/3d, 1, 1, 0, 0, 0},
                                                    { 0, 0, 0, 0, 1, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0} };            
            
            /// replace zero columns, change the values to 1/7
            // GetLength(0) is the number of rows
            // GetLength(1) is the number of columns
            int count = 0;
           
            // check columns
            for (int i = 0; i < matrix_H.GetLength(1); i++)
            {
                // check rows
                for (int j = 0; j < matrix_H.GetLength(0); j++)
                {
                    if (matrix_H[j, i] == 0)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Count: " + count);
                if (count == 7)
                {
                    // change the column to 1/7
                    for (int p = 0; p < matrix_H.GetLength(1); p++)
                    {
                        matrix_S[p, i] = 1 / 7d;
                    }

                    // print zero columns
                    for (int q = 0; q < matrix_H.GetLength(0); q++)
                    {
                        Console.WriteLine("Zero column check(1/7): " + matrix_S[q, i]);
                    }
                }
                count = 0;
            }

            Console.WriteLine("This is the S matrix");
            print_matrix(matrix_S);
            Console.WriteLine();


            Console.WriteLine("Alpha: " + alpha);

            /// Print google Matrix
            /// r(1) = G * r(0)
            /// output is r(1)
            double[,] output = google_matrix(matrix_S, alpha);
            Console.WriteLine("This is G");
            print_matrix(output);
            Console.WriteLine("This is r(1) matrix!!!");
            print_final(output, matrix_r0);
            Console.ReadKey();
        }
        
        public static void print_final(double[,] gs, double[] r0)
        {
            List<double[]> print_array = new List<double[]>();
            print_array.Add(r0);
            for (int i = 0; i < 100; i++) {
                print_array.Add(matrices_MULTIPLICATION(gs, print_array[i]));
                Console.Write("r"+i+": ");
                print_matrix_one(print_array[i]);
                Console.WriteLine();
            }
        }

        /*
        public static void recursive_print(double[] matrix_rn)
        {

            matrix_rn = 
        }*/

        public static void print_matrix(double[,] matrix) {
            // print rows first
            // and then print columns
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) 
                {
                    Console.Write(Math.Round(matrix[i, j], 3, MidpointRounding.AwayFromZero) + " ");
                }
                // new line for next rows
                Console.WriteLine();
            }
        }

        public static void print_matrix_one(double[] matrix)
        {
            // print rows first
            // and then print columns
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write(Math.Round(matrix[i], 3, MidpointRounding.AwayFromZero) + " ");
                //Console.WriteLine();
            }
        }

        /*
        public static double[,] g_powers(double[,] matrix_G, int powers) {
            double[,] new_matrix = new double[7,7];
            // rows
            int count = 0;
            while (count != powers)
            {
                if (count == 0) {
                    for (int i = 0; i < matrix_G.GetLength(0); i++)
                    {
                        // columns
                        for (int j = 0; j < matrix_G.GetLength(1); j++)
                        {
                            new_matrix[i, j] = matrix_G[i, j] * matrix_G[i, j];
                        }
                }
                count++;
                }
                else {
                    // rows
                    double temp = 0;
                    for (int i = 0; i < matrix_G.GetLength(0); i++)
                    {
                        // columns
                        for (int j = 0; j < matrix_G.GetLength(1); j++)
                        {
                            temp += matrix_G[i, j] * matrix_G[j, i];
                        }
                        new_matrix[i, j] = temp;
                        temp = 0.0;
                    }
                    count++;
                    //new_matrix[i, j] = new_matrix[i, j] * matrix_G[i, j];
                }
                
            }
            return new_matrix;
        }*/



        public static double[,] google_matrix(double[,] matrix_S, double alpha)
        {
            /// e * e^transfer
            double[,] e_e_transfer;
            e_e_transfer = new double[7,7] { {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1},
                                             {1, 1, 1, 1, 1, 1, 1} };
            /// First part calculation of G
            // alpha * S
            double[,] matrix_G_1st_part = new double[7,7];
            matrix_G_1st_part = matrix_MULTIPLICATION_int(matrix_S, alpha);
            
            /// Second part calculation of G
            // (1-alpha) * 1/n
            double g_2nd_part_double = (1 - alpha) * (1 / 7d);
            
            // now do the G's second part calculation
            double[,] matrix_G_2nd_part = matrix_MULTIPLICATION_int(e_e_transfer, g_2nd_part_double);

            /// Calculate G here
            // calculate G adding up two parts above
            double[,] matrices_sum = matrix_SUM(matrix_G_1st_part, matrix_G_2nd_part);

            return matrices_sum;
        }

        public static double[,] matrix_MULTIPLICATION_int(double[,] matrix, double integer)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] * integer;
                }
            }
            return matrix;
        }

        public static double[,] matrix_SUM(double[,] matrix, double[,] matrix2)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] + matrix2[i, j];
                }
            }
            return matrix;
        }



        
        public static double[] matrices_MULTIPLICATION(double[,] matrix, double[] matrix2)
        {
            double[] new_matrix = new double[7];
            // rows
            double temp = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // columns
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp += matrix[i, j] * matrix2[j];
                }
                new_matrix[i] = temp;
                temp = 0.0;
            }
            return new_matrix;
        }


        
    }
}