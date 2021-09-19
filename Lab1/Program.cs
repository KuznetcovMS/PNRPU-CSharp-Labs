using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1A
            Console.WriteLine("Задача 1А\n{");

            int m, n;
            bool success;

            float firstOperResult;
            bool secondOperResult, thirdOperResult;

            do
            {
                Console.Write("\tВведите значение m: ");
                success = int.TryParse(Console.ReadLine(), out m);
                if (!success) Console.WriteLine("\tВведённую строку невозможно перевести в целое число");
            } while (!success);

            do
            {
                Console.Write("\tВведите значение n: ");
                success = int.TryParse(Console.ReadLine(), out n);
                if (!success) Console.WriteLine("\tВведённую строку невозможно перевести в целое число");
                if (n == 0 && success)
                {
                    Console.WriteLine("\tПри n = 0 невозможно вычислить выражение m++ / n-- (Деление на 0)");
                    success = false;
                }
            } while (!success);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            firstOperResult = (float)m++ / n--;
            Console.WriteLine("\n\tВыражение m++ / n-- = " + firstOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            secondOperResult = ++m < n--;
            Console.WriteLine("\n\tВыражение ++m < n-- = " + secondOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            thirdOperResult = n-- > m;
            Console.WriteLine("\n\tВыражение n-- > m = " + thirdOperResult);
            Console.WriteLine("\tm = " + m + ", n = " + n);

            Console.WriteLine("}\n");

            // Task 1B
            Console.WriteLine("Задача 1Б\n{");

            double x, resX;
            do
            {
                Console.Write("\tВведите значение x: ");
                success = double.TryParse(Console.ReadLine(), out x);
                if (!success) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!success);

            resX = Math.Sin(Math.Pow(x, 3)) + Math.Pow(x, 4) + Math.Pow(Math.Pow(x, 2) + Math.Pow(x, 3), 0.2); 
            Console.WriteLine("\tРезультат выражения sin(x^3) + x^4 + (x^2 + x^3)^0,2 = " + resX + "\n");

            Console.WriteLine("}\n");

            // Task 2
            Console.WriteLine("Задача 2\n{");

            bool t2Res = false;
            float x1, y1;

            do
            {
                Console.Write("\tВведите значение x1: ");
                success = float.TryParse(Console.ReadLine(), out x1);
                if (!success) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!success);

            do
            {
                Console.Write("\tВведите значение y1: ");
                success = float.TryParse(Console.ReadLine(), out y1);
                if (!success) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!success);
            t2Res = -2 <= x1 && x1 <= 2 && 0 <= y1 && y1 <= 2 - Math.Abs(x1);

            if (t2Res) Console.WriteLine("\tТочка с координатами (" + x1 + ";" + y1 + ") принадлежит области графика y = 2 - |x|");
            else Console.WriteLine("\tТочка с координатами (" + x1 + ";" + y1 + ") не принадлежит области графика y = 2 - |x|");

            Console.WriteLine("}\n");

            // Task 3
            Console.WriteLine("Задача 3\n{");
            float af = 100f, bf = 0.001f, rf;
            double ad = 100, bd = 0.001, rd;

            rf = ((float)Math.Pow(af + bf, 3) - (float)Math.Pow(af, 3) - 3 * af * (float)Math.Pow(bf, 2)) / (3 * (float)Math.Pow(af, 2) * bf + (float)Math.Pow(bf, 3));
            Console.WriteLine("\tFloat result: " + rf);

            rd = (Math.Pow(ad + bd, 3) - Math.Pow(ad, 3) - 3 * ad * Math.Pow(bd, 2)) / (3 * Math.Pow(ad, 2) * bf + Math.Pow(bd, 3));
            Console.WriteLine("\tDouble result: " + rd);

            Console.WriteLine("}\n");

            // Exit
            Console.Write("\nPress any button to exit");
            Console.ReadKey();
        }
    }
}
