using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class BubbleSort_Trey
    {
        static void Main(string[] args)
        {
			string[] lines = File.ReadAllLines(@"C:\Users\student\Desktop\list.csv");
            int[] file_array = Array.ConvertAll(lines, int.Parse);
            string[] lines_1 = File.ReadAllLines(@"C:\Users\student\Desktop\list.csv");
            int[] file_array_1 = Array.ConvertAll(lines_1, int.Parse);
			
            int[] array1 = { 1, 6, 4, 7, 9, 80 };
            int[] array1_1 = { 1, 6, 4, 7, 9, 80 };
            int[] array2 = { 3, 7, 9, 2, 4, 1, 3, 5, 2 };
            int[] array2_1 = { 3, 7, 9, 2, 4, 1, 3, 5, 2 };

            // Using tmp var in order to swap the elements in array1
            int tmp = 0;

            // Loop through 
            for (int i = 0; i < array1.Length; i++)
            {
                // I am cmparing j and j+1, so array1.Length is needed to keep in the range
                // comparing j and j+1 at the "if" statement below
                for (int j = 0; j < (array1.Length - 1); j++)
                {
                    // swapping small numbers with bigger ones
                    if (array1[j] > array1[j + 1])
                    {
                        tmp = array1[j + 1];
                        array1[j + 1] = array1[j];
                        array1[j] = tmp;
                        Console.WriteLine("[{0}]", string.Join(", ", array1));
                    }
                    // print the process
                }
            }
            Console.Write("Bubble sort (1st array): ");
            // print the result (processed array1)
            for (int p = 0; p < array1.Length; p++)
            {
                Console.Write(array1[p] + " ");
            }
            // print \n
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(array1_1,
                            (i1, i2) => i1.CompareTo(i2)
                    );

            Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", array1_1));

            // 2nd array 
            for (int i = 0; i < array2.Length; i++)
            {
                // I am cmparing j and j+1, so array1.Length is needed to keep in the range
                // comparing j and j+1 at the "if" statement below
                for (int j = 0; j < (array2.Length - 1); j++)
                {
                    // swapping small numbers with bigger ones
                    if (array2[j] > array2[j + 1])
                    {
                        tmp = array2[j + 1];
                        array2[j + 1] = array2[j];
                        array2[j] = tmp;
                        Console.WriteLine("[{0}]", string.Join(", ", array2));
                    }
                    // print the process
                }
            }
            Console.Write("Bubble sort (2nd array): ");
            // print the result (processed array1)
            for (int q = 0; q < array2.Length; q++)
            {
                Console.Write(array2[q] + " ");
            }

            // print \n
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(array2_1,
                            (i1, i2) => i1.CompareTo(i2)
                    );
            Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", array2_1));

            // File input
            for (int i = 0; i < file_array.Length; i++)
            {
                // I am cmparing j and j+1, so array1.Length is needed to keep in the range
                // comparing j and j+1 at the "if" statement below
                for (int j = 0; j < (file_array.Length - 1); j++)
                {
                    // swapping small numbers with bigger ones
                    if (file_array[j] > file_array[j + 1])
                    {
                        tmp = file_array[j + 1];
                        file_array[j + 1] = file_array[j];
                        file_array[j] = tmp;
                    }
                    // print the process
                }
            }
            Console.Write("Bubble sort (1st array): ");
            // print the result (processed array1)
            for (int p = 0; p < file_array.Length; p++)
            {
                Console.Write(file_array[p] + " ");
            }
            // print \n
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(file_array_1,
                            (i1, i2) => i1.CompareTo(i2)
                    );

            Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", file_array_1));

            // to hold the cmd window
            Console.ReadKey();
        }
    }
}