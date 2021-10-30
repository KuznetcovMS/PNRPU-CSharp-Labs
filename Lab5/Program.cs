using System;

namespace ConsoleApp1

{
    class Program
    {
       static void Main(string [] args)
        {
            int command;
            bool shouldClose = false;
            while(!shouldClose)
            {
                ShowMenu();
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 4:
                            shouldClose = true;
                            break;
                        default:
                            Console.WriteLine("ERROR: Неверный код команды\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Введённую строку невозможно интерпретировать как целое число\n");
                }
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("========= Главное меню =========");
            Console.WriteLine("1. Работа с одномерным массивом");
            Console.WriteLine("2. Работа с двумерным массивом");
            Console.WriteLine("3. Работа с рваным массивом");
            Console.WriteLine("4. Выход\n");
        }

        static void WorkOneDimArray()
        {
            Console.WriteLine("====Одномерный массив====");
            Console.WriteLine("{");
        }

        static void ShowOneDimMenu()
        {
            Console.WriteLine("\t1. Создать массив");
            Console.WriteLine("\t2. Напечатать массив");
            Console.WriteLine("\t3. Удалить все нечётные элементы");
            Console.WriteLine("\t4. Выйти в главное меню");
        }
    }
}
