using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_Task2_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2
            bool successInput;
            Console.WriteLine("Задача 2\n{");

            bool t2Res = false;
            float x1, y1;

            // Input var x1
            do
            {
                Console.Write("\tВведите значение x1: ");
                successInput = float.TryParse(Console.ReadLine(), out x1);
                if (!successInput) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!successInput);

            // Input var y1
            do
            {
                Console.Write("\tВведите значение y1: ");
                successInput = float.TryParse(Console.ReadLine(), out y1);
                if (!successInput) Console.WriteLine("\tВведённую строку невозможно перевести в вещественное число");
            } while (!successInput);

            // Вetermination of belonging of a point in a given area
            t2Res = (x1 >= -2) && (x1 <= 2) && (y1 >= 0) && (y1 <= (2 - Math.Abs(x1)));

            // Print result
            if (t2Res) Console.WriteLine("\tТочка с координатами (" + x1 + ";" + y1 + ") принадлежит области графика y = 2 - |x|");
            else Console.WriteLine("\tТочка с координатами (" + x1 + ";" + y1 + ") не принадлежит области графика y = 2 - |x|");

            Console.WriteLine("}\n");

            // Exit
            Console.Write("\nPress any button to exit");
            Console.ReadKey();
        }
    }
}
