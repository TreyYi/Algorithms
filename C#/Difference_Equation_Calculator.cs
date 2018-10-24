using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // integer inputs for differece equation (a,b,c)
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            double b_to_the_c = Math.Pow(b, c);
            double d1 = (Math.Pow(b, c)) / (Math.Pow(b, c) - a);

            // When a == b^c
            if (a == b_to_the_c) {
                Console.WriteLine("T[n]= " + "C1(n^" + c + ")" + "+" +  "n^" + c + "Log" + b + "(n)");
            }
            // When a != b^c
            else if (a != Math.Pow(b, c)) {
                // when c == 0
                if (c == 0)
                {
                    Console.WriteLine("T[n]= " + "C1" + "(n)" + "^Log" + b + "(" + a + ")" + d1);
                }
                else {
                    Console.WriteLine("T[n]= " + "C1" + "(n)" + "^Log" + b + "(" + a + ")" + d1 + "(n)^" + c);
                }
            }
            
            // this is just for being able to stay at the cmd
            Console.ReadLine();
        }
    }
}