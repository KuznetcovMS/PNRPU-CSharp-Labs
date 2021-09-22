using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_Task1_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1A
            Console.WriteLine("Задача 1А\n{");

            int m, n;
            bool successInput;

            float firstOperResult;
            bool secondOperResult, thirdOperResult;

            // Input var m
            do
            {
                Console.Write("\tВведите значение m: ");
                successInput = int.TryParse(Console.ReadLine(), out m);
                if (!successInput) Console.WriteLine("\tВведённую строку невозможно перевести в целое число");
            } while (!successInput);

            // Input var n
            do
            {
                Console.Write("\tВведите значение n: ");
                successInput = int.TryParse(Console.ReadLine(), out n);
                if (!successInput) Console.WriteLine("\tВведённую строку невозможно перевести в целое число");
                if (n == 0 && successInput)
                {
                    Console.WriteLine("\tПри n = 0 невозможно вычислить выражение m++ / n-- (Деление на 0)");
                    successInput = false;
                }
            } while (!successInput);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            // First operation compute
            firstOperResult = (float)m++ / n--;
            Console.WriteLine("\n\tВыражение m++ / n-- = " + firstOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            // Second operation compute
            secondOperResult = ++m < n--;
            Console.WriteLine("\n\tВыражение ++m < n-- = " + secondOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            // Third operation compute
            thirdOperResult = n-- > m;
            Console.WriteLine("\n\tВыражение n-- > m = " + thirdOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            Console.WriteLine("}\n");

            // Task 1B
            Console.WriteLine("Задача 1Б\n{");

            double x, resX;

            // Input var x
            do
            {
                Console.Write("\tВведите значение x: ");
                successInput = double.TryParse(Console.ReadLine(), out x);
                if (!successInput) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!successInput);

            // Compute operation
            resX = Math.Sin(Math.Pow(x, 3)) + Math.Pow(x, 4) + Math.Pow(Math.Abs(Math.Pow(x, 2) + Math.Pow(x, 3)), 0.2) * Math.Sign(Math.Pow(x, 2) + Math.Pow(x, 3));
            Console.WriteLine("\tРезультат выражения sin(x^3) + x^4 + (x^2 + x^3)^0,2 = " + resX + "\n");

            Console.WriteLine("}\n");

            // Exit
            Console.Write("\nPress any button to exit");
            Console.ReadKey();
        }
    }
}
