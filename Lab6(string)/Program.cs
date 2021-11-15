using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] raggedArray = null;
            bool shouldClose = false;
            string mainString = null;

            while (!shouldClose)
            {
                ShowMenu();
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            RaggedArrayWorker.StartWorkRaggedTwoDimArray(ref raggedArray);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            StringWorker.StartWork(ref mainString);
                            Console.Clear();
                            break;
                        case 3:
                            shouldClose = true;
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

        static void ShowMenu()
        {
            Console.WriteLine("========= Главное меню =========");
            Console.WriteLine("1. Работа с рваным массивом");
            Console.WriteLine("2. Работа со строками");
            Console.WriteLine("3. Выход");
        }
    }
}
