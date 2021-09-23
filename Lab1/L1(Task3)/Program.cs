using System;

namespace L1_Task3_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3
            Console.WriteLine("Задача 3\n{");
            float af = 100f, bf = 0.001f, rf;
            double ad = 100, bd = 0.001, rd;

            // Calculate Float result
            rf = ((float)Math.Pow(af + bf, 3) - (float)Math.Pow(af, 3) - 3 * af * (float)Math.Pow(bf, 2)) / (3 * (float)Math.Pow(af, 2) * bf + (float)Math.Pow(bf, 3));
            Console.WriteLine("\tFloat result: " + rf);

            // Calculate Double result
            rd = (Math.Pow(ad + bd, 3) - Math.Pow(ad, 3) - 3 * ad * Math.Pow(bd, 2)) / (3 * Math.Pow(ad, 2) * bf + Math.Pow(bd, 3));
            Console.WriteLine("\tDouble result: " + rd);

            Console.WriteLine("}\n");

            // Exit
            Console.Write("\nPress any button to exit");
            Console.ReadKey();
        }
    }
}
