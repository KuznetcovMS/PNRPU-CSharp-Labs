using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class TwoDimArrayWorker
    {
        static bool isInitialized = false;
        public static void StartWorkTwoDimArray(ref int[,] twoDimArray)
        {
            bool shouldExitInMainMenu = false;
            while (!shouldExitInMainMenu)
            {
                ShowMenu();
                PrintStat(ref twoDimArray);

                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            CreateArray(ref twoDimArray);
                            break;
                        case 2:
                            Console.Clear();
                            ShowFillArrayMenu(ref twoDimArray);
                            break;
                        case 3:
                            Console.Clear();
                            PrintArray(ref twoDimArray);
                            break;
                        case 4:
                            Console.Clear();
                            AddRows(ref twoDimArray);
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
        static void PrintStat(ref int[,] twoDimArray)
        {
            if (twoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Массив[null, null]");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Массив[{twoDimArray.GetLength(0)}, {twoDimArray.GetLength(1)}]");
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
            Console.WriteLine("==== Двумерный массив ====");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Заполнить массив");
            Console.WriteLine("3. Напечатать массив");
            Console.WriteLine("4. Добавить строки в начало массива");
            Console.WriteLine("5. Выйти в главное меню");
        }

        static void CreateArray(ref int[,] twoDimArray)
        {
            Console.WriteLine("==== Создание двумерного массива ====\n");

            bool successInputRows = false;
            bool successInputColumns = false;
            int rows = 0;
            int columns = 0; ;

            if (twoDimArray != null)
            {
                Console.Write("Массив уже создан. Удалить старый и создать новый? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    Console.Clear();
                    return;
                }
            }

            while (!successInputRows)
            {
                Console.Write("Введите количество строк массива: ");
                if (int.TryParse(Console.ReadLine(), out rows))
                {
                    if (rows > 0)
                    {
                        successInputRows = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: неверное количество строк массива\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintParseErrorMes();
                }

            }

            while (!successInputColumns)
            {
                Console.Write("Введите количество столбцов массива: ");
                if (int.TryParse(Console.ReadLine(), out columns))
                {
                    if (columns > 0)
                    {
                        successInputColumns = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: неверное количество столбцов массива\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    PrintParseErrorMes();
                }

            }

            try
            {
                twoDimArray = new int[rows, columns];
            }
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FATAL ERROR: OUT OF MEMORY EXCEPTION!!!\n");
                Console.ResetColor();
                twoDimArray = null;
                isInitialized = false;
                GC.Collect();
                return;
            }
            
            isInitialized = false;
            Console.Clear();
        }

        private static void ShowFillArrayMenu(ref int[,] twoDimArray, int rows = 0)
        {
            Console.WriteLine("==== Заполнение двумерного массива ====");

            bool shouldExit = false;

            if (twoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            while (!shouldExit)
            {
                Console.Write("1. Задать элементы вручную");
                if (twoDimArray.Length > 10 && rows == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" ({twoDimArray.Length} элементов!)");
                    Console.ResetColor();
                }
                else if (rows != 0 && rows * twoDimArray.GetLength(1) > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" ({rows * twoDimArray.GetLength(1)} элементов!)");
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
                            ManuallyFillingArray(ref twoDimArray, rows);
                            shouldExit = true;
                            break;
                        case 2:
                            RndFillArray(ref twoDimArray, rows);
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

        private static void ManuallyFillingArray(ref int[,] twoDimArray, int rows = 0)
        {
            Console.WriteLine("\nn - Принудительное завершение ввода");
            if (rows == 0)
            {
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        bool correctVal = false;
                        while (!correctVal)
                        {
                            Console.Write($"[{i + 1}/{twoDimArray.GetLength(0)}, {j + 1}/{twoDimArray.GetLength(1)}] ");
                            string buf = Console.ReadLine();
                            if (buf == "n")
                            {
                                Console.Clear();
                                return;
                            }
                            if (int.TryParse(buf, out twoDimArray[i, j]))
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
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        bool correctVal = false;
                        while (!correctVal)
                        {
                            Console.Write($"[{i + 1}/{rows}, {j + 1}/{twoDimArray.GetLength(1)}] ");
                            string buf = Console.ReadLine();
                            if (buf == "n")
                            {
                                Console.Clear();
                                return;
                            }
                            if (int.TryParse(buf, out twoDimArray[i, j]))
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
            }
           
            isInitialized = true;

        }

        private static void RndFillArray(ref int[,] twoDimArray, int rows = 0)
        {
            Console.WriteLine("Массив заполняется...");
            Random rnd = new Random();
            if (rows == 0)
            {
                for (int i = 0; i < twoDimArray.GetLength(0); i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        twoDimArray[i, j] = rnd.Next(1, 100);
                    }
                }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < twoDimArray.GetLength(1); j++)
                    {
                        twoDimArray[i, j] = rnd.Next(1, 100);
                    }
                }
            }
            
        }

        static void PrintArray(ref int[,] twoDimArray)
        {
            Console.WriteLine("==== Вывод элементов массива ====");

            if (twoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            if (twoDimArray.Length > 1000000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Массив слишком велик: {twoDimArray.Length} элементов");
                Console.ResetColor();

                Console.Write("Вывести массив? (+/-) ");
                if (Console.ReadLine() != "+")
                {
                    return;
                }
            }
            Console.Write("Элементы массива:\n");
            for (int i = 0; i < twoDimArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimArray.GetLength(1); j++)
                {
                    Console.Write($"{twoDimArray[i, j]}\t");
                }
                Console.WriteLine();
                
            }
            Console.WriteLine("\n");
        }

        static void AddRows(ref int[,] twoDimArray)
        {
            Console.WriteLine("==== Добавление строк в начало массива ====");
            if (twoDimArray == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Массив не создан!!!\n");
                Console.ResetColor();
                return;
            }

            int numNewRows = 0;
            bool correctVal = false;

            while (!correctVal)
            {
                Console.Write("Введите количество новых строк: ");
                if (int.TryParse(Console.ReadLine(), out numNewRows))
                {
                    if (numNewRows > 0)
                    {
                        correctVal = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR: неверное количество строк\n");
                        Console.ResetColor();
                    }
                }
                else PrintParseErrorMes();
            }

            int[,] newArray;
            try
            {
                 newArray= new int[numNewRows + twoDimArray.GetLength(0), twoDimArray.GetLength(1)];
            }
            catch (OutOfMemoryException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FATAL ERROR: OUT OF MEMORY EXCEPTION!!!\n");
                Console.ResetColor();
                GC.Collect();
                return;
            }

            //int[,] buf = new int[numNewRows, twoDimArray.GetLength(1)];

            Console.Write("Заполнить новые строки? (+/-) ");
            if (Console.ReadLine() == "+")
            {
                ShowFillArrayMenu(ref newArray, numNewRows);
            }
            else isInitialized = false;

            Console.WriteLine("Перенос старых элементов в новый массив...");

            for (int i = numNewRows; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    newArray[i, j] = twoDimArray[i - numNewRows, j];
                }
            }

            twoDimArray = newArray;
            Console.Clear();
        }
    }
}
