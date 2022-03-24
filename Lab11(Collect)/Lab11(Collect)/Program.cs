using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Lab10Lib;

namespace Lab11_Collect_
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            Stopwatch timer = new Stopwatch();
            //Задание 1
            Console.WriteLine("Задание 1 - поиск элемента в Queue");
            Queue qu = new Queue(100);
            Check c1 = new Check("0", "0", 0);
            Check c2 = new Check("50", "50", 50);
            Check c3 = new Check("99", "99", 99);
            for (int i = 0; i < 100; i++)
            {
                qu.Enqueue((Document)new Check(Convert.ToString(i), Convert.ToString(i), i));
            }

            qu.Contains(c1); //Кеширование машинного кода

            timer.Restart();
            bool res = qu.Contains(c1);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            timer.Restart();
            res = qu.Contains(c2);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            timer.Restart();
            res = qu.Contains(c3);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            //Задание 2
            Console.WriteLine("\nЗадание 2 - поиск элемента в Stack<Check>");
            Stack<Document> stack = new Stack<Document>(100);
            for (int i = 0;i < 100;i++)
            {
                stack.Push(new Check(Convert.ToString(i), Convert.ToString(i), i));
            }

            stack.Contains(c1); //Кеширование машинного кода

            timer.Restart();
            res = stack.Contains(c1);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            timer.Restart();
            res = stack.Contains(c2);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            timer.Restart();
            res = stack.Contains(c3);
            timer.Stop();
            Console.WriteLine($"Резльтат: {res}, время: {timer.ElapsedTicks}");

            //Задание 3
            Console.WriteLine("\nЗадание 3");
            TestCollections tc = new TestCollections(100000);
            tc.RunContainsBenchmarks();
        }
    }
}
