using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class RaggedArrayWorker
    {
        static bool isInitialized = false;
        public static void StartWorkRaggedTwoDimArray(ref int[][] raggedTwoDimArray)
        {
            bool shouldExitInMainMenu = false;
            while (!shouldExitInMainMenu)
            {
                ShowMenu();
                PrintStat(ref raggedTwoDimArray);

                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            CreateArray(ref raggedTwoDimArray);
                            break;
                        case 2:
                            Console.Clear();
                            ShowFillArrayMenu(ref raggedTwoDimArray);
                            break;
                        case 3:
                            Console.Clear();
                            PrintArray(ref raggedTwoDimArray);
                            break;
                        case 4:
                            Console.Clear();
                            DeleteRow(ref raggedTwoDimArray);
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
                    PrintParseErrorMes();
                }
            }
        }

        static void PrintParseErrorMes()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERROR: Введённую строку невозможно интерпретировать как целое число\n");
            Console.ResetColor();
        }
        static void PrintStat(ref int[][] raggedTwoDimArray)
        {
            if (raggedTwoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Массив[null][null]");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Массив[{raggedTwoDimArray.GetLength(0)}]");
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
            Console.WriteLine("==== Рваный двумерный массив ====");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Заполнить массив");
            Console.WriteLine("3. Напечатать массив");
            Console.WriteLine("4. Удалить строку");
            Console.WriteLine("5. Выйти в главное меню");
        }

        static void CreateArray(ref int[][] raggedTwoDimArray)
        {
            Console.WriteLine("==== Создание рваного двумерного массива ====\n");

            if (raggedTwoDimArray != null)
            {
                Console.Write("Массив уже создан. Удалить старый и создать новый? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    Console.Clear();
                    return;
                }
            }

            GetCorrectVal("Введите количество строк(1 - 22360): ", "ERROR: невеное количество строк", out int rows, 1, 22360);

            try
            {
                raggedTwoDimArray = new int[rows][];

                Console.WriteLine("1. Строки одинаковой длины");
                Console.WriteLine("2. Строки случайной длины(1 - 10)");
                Console.WriteLine("3. Задать длину вручную для каждой строки");
                GetCorrectVal(">", "Неверный код", out int command, 1, 3);

                int columns;
                switch (command)
                {
                    case 1:
                        GetCorrectVal("Введите длину строк(1 - 22360): ", "ERROR: Неверная длина строк", out columns, 1, 22360);
                        Console.WriteLine("Создание строк...");
                        for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
                        {
                            raggedTwoDimArray[i] = new int[columns];
                        }
                        break;
                    case 2:
                        Console.WriteLine("Создание строк...");
                        Random rnd = new Random();
                        for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
                        {
                            raggedTwoDimArray[i] = new int[rnd.Next(1, 10)];
                        }
                        break;
                    case 3:
                        for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
                        {

                            GetCorrectVal($"Введите длину строки({i + 1}/{raggedTwoDimArray.GetLength(0)}): ", "ERROR: Неверная длина строки", out columns, 1);
                            raggedTwoDimArray[i] = new int[columns];
                        }
                        break;
                }


            }
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FATAL ERROR: OUT OF MEMORY EXCEPTION!!!\n");
                Console.ResetColor();
                raggedTwoDimArray = null;
                isInitialized = false;
                GC.Collect();
                return;
            }

            isInitialized = false;
            Console.Clear();
        }

        private static void ShowFillArrayMenu(ref int[][] raggedTwoDimArray)
        {
            Console.WriteLine("==== Заполнение двумерного массива ====");

            bool shouldExit = false;

            if (raggedTwoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            while (!shouldExit)
            {
                Console.Write("1. Задать элементы вручную");

                int size = 0;
                for (int i = 0; i < raggedTwoDimArray.Length; i++)
                {
                    size += raggedTwoDimArray[i].Length;
                }

                if (size > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" ({size} элементов!)");
                    Console.ResetColor();
                }
                else Console.WriteLine();

                Console.WriteLine("2. Задать элементы через ДСЧ");
                Console.WriteLine("3. Назад");
                Console.Write(">");

                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                        case 1:
                            ManuallyFillingArray(ref raggedTwoDimArray);
                            shouldExit = true;
                            break;
                        case 2:
                            RndFillArray(ref raggedTwoDimArray);
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
                else PrintParseErrorMes();
            }
            Console.Clear();
        }

        private static void GetCorrectVal(string mess, string errorMes, out int val, int min = int.MinValue, int max = int.MaxValue)
        {
            bool successInput = false;
            val = 0;
            while (!successInput)
            {
                Console.Write(mess);
                if (int.TryParse(Console.ReadLine(), out val))
                {
                    if (min <= val && val <= max)
                    {
                        successInput = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(errorMes + "\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintParseErrorMes();
                }
            }
        }
        private static void ManuallyFillingArray(ref int[][] raggedTwoDimArray, int rows = 0)
        {
            Console.WriteLine("\nn - Принудительное завершение ввода");
           
            for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < raggedTwoDimArray[i].Length; j++)
                {
                    bool correctVal = false;
                    while (!correctVal)
                    {
                        Console.Write($"[{i + 1}/{raggedTwoDimArray.GetLength(0)}, {j + 1}/{raggedTwoDimArray[i].Length}] ");
                        string buf = Console.ReadLine();
                        if (buf == "n")
                        {
                            Console.Clear();
                            return;
                        }
                        if (int.TryParse(buf, out raggedTwoDimArray[i][j]))
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
            }

            isInitialized = true;
        }

        private static void RndFillArray(ref int[][] raggedTwoDimArray)
        {
            Console.WriteLine("Массив заполняется...");
            Random rnd = new Random();
            
            for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < raggedTwoDimArray[i].Length; j++)
                {
                    raggedTwoDimArray[i][j] = rnd.Next(1, 100);
                }
            }
        }

        static void PrintArray(ref int[][] raggedTwoDimArray)
        {
            Console.WriteLine("==== Вывод элементов массива ====");

            if (raggedTwoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            if (raggedTwoDimArray.Length > 1000000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Массив слишком велик: {raggedTwoDimArray.Length} элементов");
                Console.ResetColor();

                Console.Write("Вывести массив? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    return;
                }
            }
            Console.Write("Элементы массива:\n");
            for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < raggedTwoDimArray[i].Length; j++)
                {
                    Console.Write($"{raggedTwoDimArray[i][j]}\t");
                }
                Console.WriteLine();

            }
            Console.WriteLine("\n");
        }

        static void DeleteRow(ref int[][] raggedTwoDimArray)
        {
            Console.WriteLine("==== Удаление строк из массива ====");
            if (raggedTwoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            GetCorrectVal($"Введите номер строки(1 - {raggedTwoDimArray.GetLength(0)}): ", "ERROR: неверный номер строки", out int delIndex, 1, raggedTwoDimArray.GetLength(0));


            int[][] newArray;
            newArray = new int[raggedTwoDimArray.GetLength(0) - 1][];
            int j = 0;

            Console.WriteLine("Перенос старых элементов в новый массив...");

            for (int i = 0; i < raggedTwoDimArray.GetLength(0); i++)
            {
                if (i != delIndex - 1)
                {
                    newArray[j] = new int[raggedTwoDimArray[i].Length];
                    for (int p = 0; p < newArray[j].Length; p++)
                    {
                        newArray[j][p] = raggedTwoDimArray[i][p];
                    }
                    j++;
                }
            }
            
            
            if (newArray.Length == 0)
            {
                raggedTwoDimArray = null;
                isInitialized = false;
            }
            else raggedTwoDimArray = newArray; ;
            Console.Clear();
        }
    }
}
