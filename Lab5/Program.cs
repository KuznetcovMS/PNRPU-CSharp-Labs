using System;


namespace Lab5

{
    class Program
    {
       static void Main(string [] args)
        {
            int command;
            bool shouldClose = false;

            int[] oneDimArray = null;
            int[,] twoDimArray = null;
            int[][] raggedArray = null;

            while(!shouldClose)
            {
                ShowMenu();
                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            OneDimArrayWorker.StartWorkOneDimArray(ref oneDimArray);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            TwoDimArrayWorker.StartWorkTwoDimArray(ref twoDimArray);
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            RaggedArrayWorker.StartWorkRaggedTwoDimArray(ref raggedArray);
                            Console.Clear();
                            break;
                        case 4:
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
            Console.WriteLine("1. Работа с одномерным массивом");
            Console.WriteLine("2. Работа с двумерным массивом");
            Console.WriteLine("3. Работа с рваным массивом");
            Console.WriteLine("4. Выход");
        }
    }
}
