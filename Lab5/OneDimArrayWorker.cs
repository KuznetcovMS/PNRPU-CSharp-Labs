using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class OneDimArrayWorker
    {
        static bool isInitialized = false;
        public static void StartWorkOneDimArray(ref int[] oneDimArray)
        {
            bool shouldExitInMainMenu = false;
            int command;
            while (!shouldExitInMainMenu)
            {
                ShowMenu();
                PrintStat(ref oneDimArray);

                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            CreateArray(ref oneDimArray);
                            break;
                        case 2:
                            Console.Clear();
                            FillArray(ref oneDimArray);
                            break;
                        case 3:
                            Console.Clear();
                            PrintArray(ref oneDimArray);
                            break;
                        case 4:
                            Console.Clear();
                            RemoveODD(ref oneDimArray);
                            break;
                        case 5:
                            shouldExitInMainMenu = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: Неверный код команды\n");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Введённую строку невозможно интерпретировать как целое число\n");
                    Console.ResetColor();
                }
            }
        }

        static void PrintStat(ref int[] oneDimArray)
        {
            if (oneDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Массив[null]");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Массив[{oneDimArray.Length}]");
                Console.ResetColor();
            }

            if (isInitialized)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("(Заполнен)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("(Пустой)");
                Console.ResetColor();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("==== Одномерный массив ====");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Заполнить массив");
            Console.WriteLine("3. Напечатать массив");
            Console.WriteLine("4. Удалить все нечётные элементы");
            Console.WriteLine("5. Выйти в главное меню");
        }

        static void CreateArray(ref int[] oneDimArray)
        {
            Console.WriteLine("==== Создание одномерного массива ====\n");

            bool successInput = false;
            int size = 1;

            if (oneDimArray != null)
            {
                Console.Write("Массив уже создан. Удалить старый и создать новый? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    Console.Clear();
                    return;
                }
            }

            while (!successInput)
            {
                Console.Write("Введите размер массива: ");
                if (int.TryParse(Console.ReadLine(), out size))
                {
                    if (size > 0)
                    {
                        successInput = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: неверный размер массива\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Введённую строку невозможно интерпретировать как целое число\n");
                    Console.ResetColor();
                }

            }

            try
            {
                oneDimArray = new int[size];
            }
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FATAL ERROR: OUT OF MEMORY EXCEPTION!!!\n");
                Console.ResetColor();
                GC.Collect();
                return;
            }
            isInitialized = false;
            Console.Clear();
        }

        static void FillArray(ref int[] oneDimArray)
        {
            Console.WriteLine("==== Заполнение одномерного массива ====");

            int command;
            bool shouldExit = false;
            Random rnd = new Random();

            if (oneDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            while(!shouldExit)
            {
                Console.Write("1. Задать элементы вручную");
                if (oneDimArray.Length > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" ({oneDimArray.Length} элементов!)");
                    Console.ResetColor();
                }
                else Console.WriteLine();

                Console.WriteLine("2. Задать элементы через ДСЧ");
                Console.WriteLine("3. Назад");
                Console.Write(">");

                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("\nn - Принудительное завершение ввода");
                            for(int i = 0; i < oneDimArray.Length; i++)
                            {
                                bool correctVal = false;
                                string buf;
                                
                                while (!correctVal)
                                {
                                    Console.Write("(" + (i + 1) + "/" + oneDimArray.Length + ") ");
                                    buf = Console.ReadLine();
                                    if (buf == "n")
                                    {
                                        Console.Clear();
                                        return;
                                    }
                                    if (int.TryParse(buf, out oneDimArray[i]))
                                    {
                                        correctVal = true;
                                    }
                                    else 
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("ERROR: Введённую строку невозможно интерпретировать как целое число");
                                        Console.ResetColor();
                                    }
                                }
                            }
                            isInitialized = true;
                            shouldExit = true;
                            break;
                        case 2:
                            Console.WriteLine("Массив заполняется...");
                            for (int i = 0; i < oneDimArray.Length; i++)
                            {
                                oneDimArray[i] = rnd.Next(1, 100);
                            }
                            shouldExit = true;
                            isInitialized = true;
                            break;
                        case 3:
                            shouldExit = true;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERROR: Неверный код команды\n");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            Console.Clear();
        }

        static void PrintArray(ref int[] oneDimArray)
        {
            Console.WriteLine("==== Вывод элементов массива ====");

            if (oneDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            if (oneDimArray.Length > 1000000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Массив слишком велик: {oneDimArray.Length} элементов");
                Console.ResetColor();

                Console.Write("Вывести массив? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    return;
                }
            }
            if (!isInitialized)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Массив пустой\n");
                Console.ResetColor();
            }
            Console.Write("Элементы массива: ");
            for (int i = 0; i < oneDimArray.Length; i++)
            {
                Console.Write($"{oneDimArray[i]} ");
            }
            Console.WriteLine("\n");
        }

        static void RemoveODD(ref int[] oneDimArray)
        {
            Console.WriteLine("==== Удаление нечётных элементов ====");
            if (oneDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            if (!isInitialized)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Массив пустой\n");
                Console.ResetColor();
                return;
            }

            int numEven = 0;
            int numODD =  oneDimArray.Length;

            for (int i = 0; i < oneDimArray.Length; i++)
            {
                if (oneDimArray[i] % 2 == 0)
                {
                    numEven++;
                }
            }

            numODD -= numEven;

            if (numEven > 0)
            {
                int[] newArray = new int[numEven];
                int j = 0;

                for (int i = 0; i < oneDimArray.Length; i++)
                {
                    if (oneDimArray[i] % 2 == 0)
                    {
                        newArray[j] = oneDimArray[i];
                        j++;
                    }
                }
                oneDimArray = newArray;
            }
            else
            {
                oneDimArray = null;
                isInitialized = false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Удалено {numODD} нечётных элементов\n");
            Console.ResetColor();
        }
    }
}
