using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class SelectionSort_Trey
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

            for (int i = 0; i < array1.Length; i++)
            {
                int minj = i;
                int minx = array1[i];
                for (int j = i + 1; j < array1.Length; j++)
                {
                    if (array1[j] < minx) {
                        minj = j;
                        minx = array1[j];
                        Console.WriteLine("[{0}]", string.Join(", ", array1));
                    }
                }
                array1[minj] = array1[i];
                array1[i] = minx;
            }

            Console.Write("Selection sort: ");
            for (int p = 0; p < array1.Length; p++)
            {
                Console.Write(array1[p] + " ");
            }

            // print \n
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(array1,
                            (i1, i2) => i1.CompareTo(i2)
                    );

			Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", array1_1));

            // 2nd array
            for (int i = 0; i < array2.Length; i++)
            {
                int minj = i;
                int minx = array2[i];
                for (int j = i + 1; j < array2.Length; j++)
                {

                    if (array2[j] < minx)
                    {
                        minj = j;
                        minx = array2[j];
                        Console.WriteLine("[{0}]", string.Join(", ", array2));
                    }
                }
                array2[minj] = array2[i];
                array2[i] = minx;
            }
            Console.Write("Selection sort: ");
            for (int p = 0; p < array2.Length; p++)
            {
                Console.Write(array2[p] + " ");
            }

            // print \n
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(array2,
                            (i1, i2) => i1.CompareTo(i2)
                    );
					
			Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", array2_1));
            
            // sort file input
            for (int i = 0; i < file_array.Length; i++)
            {
                int minj = i;
                int minx = file_array[i];
                for (int j = i + 1; j < file_array.Length; j++)
                {
                    if (file_array[j] < minx)
                    {
                        minj = j;
                        minx = file_array[j];
                    }
                }
                file_array[minj] = file_array[i];
                file_array[i] = minx;
            }
            
            Console.Write("Selection sort (FILE): ");
            for (int p = 0; p < file_array.Length; p++)
            {
                Console.Write(file_array[p] + " ");
            }

            // Just to print new line
            Console.WriteLine();

            // Built-in sort function
            Array.Sort<int>(file_array_1,
                            (i1, i2) => i1.CompareTo(i2)
                    );
			Console.WriteLine("Built-in sorting method: " + "[{0}]", string.Join(", ", file_array));
            Console.ReadKey();
        }
    }
}
