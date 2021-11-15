using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class StringWorker
    {
        static string[] sentences =
        {
            "Если ширина данного поля не указана, то она определяется автоматически - минимально достаточной для изображения значения.",
            "Если ширина поля указана и превышает длину помещаемого в поле значения, то при положительной длине поля W значение выравнивается по правой границе.",
            "раз два т,ри",
            "раз два три.",
            "раз два, ,три.",
            "раз два      три!!!"

        };
        public static void StartWork(ref string mainString)
        {
            bool shouldExitInMainMenu = false;
            while (!shouldExitInMainMenu)
            {
                ShowMenu();

                Console.Write(">");
                if (int.TryParse(Console.ReadLine(), out int command))
                {
                    switch (command)
                    {
                        case 1:
                            Console.Clear();
                            EnterString(ref mainString);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            ReverseWords(ref mainString);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine($"Текущая строка: {mainString}");
                            break;
                        case 4:
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
        
        static void PrintErrorMes(string mes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mes);
            Console.ResetColor();
        }

        static void ShowMenu()
        {
            Console.WriteLine("==== Работа со строками ====");
            Console.WriteLine("1. Ввести строку");
            Console.WriteLine("2. Обработать строку");
            Console.WriteLine("3. Напечатать строку");
            Console.WriteLine("4. Выйти в главное меню");
        }

        static void EnterString(ref string mainString)
        {
            Console.WriteLine("==== Ввод строки ====");

            Console.WriteLine("1. Ввести вручную");
            Console.WriteLine("2. Выбрать из массива");
            GetCorrectVal(out int command, ">", "Неверный код команды", 1, 2);
            switch (command)
            {
                case 1:
                    Console.Write("Введите строку: ");
                    string buf = Console.ReadLine();
                    if (buf.Length > 0) mainString = buf;
                    else
                    {
                        mainString = null;
                        PrintErrorMes("ERROR: Введена пустая строка");
                    }
                    break;

                case 2:
                    for (int i = 0; i < sentences.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {sentences[i]}");
                    }

                    GetCorrectVal(out int sentNum, "Введите номер предложения: ", "Неверный номер предложения", 1, sentences.Length);
                    mainString = sentences[sentNum - 1];
                    break;
            }
            
        }
        private static void GetCorrectVal(out int val, string mess, string errorMes, int min = int.MinValue, int max = int.MaxValue)
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

        static int GetNumMarks(ref string word)
        {
            int numMarks = 0;
            int i = word.Length - 1;
            char[] punctMarks = { ',', '.', '!', '?' };
            while ((Array.IndexOf(punctMarks, word[i]) > -1) && i > 0)
            {
                numMarks++;
                i--;
            }


            for (i--; i >= 0; i--)
            {
                if (Array.IndexOf(punctMarks, word[i]) != -1)
                {
                    return -1;
                }
            }
            return numMarks;
        }

        static void ReverseWords(ref string mainString)
        {
            if (mainString == null)
            {
                PrintErrorMes("ERROR: Пустая строка!");
                return;
            }
            char[] delimiterChars = {' '};
            string[] words = mainString.Split(delimiterChars);
            int wordNumber = 0;
            List<string> incorrectWords = new List<string>(words.Length);

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] != "")
                {
                    wordNumber++;
                    int numMarks = GetNumMarks(ref words[i]);
                   
                    if (numMarks > -1 && words[i].Length - numMarks == wordNumber)
                    {
                        int bufLength = words[i].Length - numMarks;
                        char[] buf = new char[words[i].Length];

                        //Reverse word in buffer array
                        for (int j = 0; j < bufLength; j++)
                        {
                            buf[j] = words[i][bufLength - j - 1];
                        }

                        //Add punctuation marks
                        for (int j = bufLength; j < buf.Length; j++)
                        {
                            buf[j] = words[i][j];
                        }
                        words[i] = new string(buf);
                    }
                    if (numMarks == -1) incorrectWords.Add(words[i]);
                   
                    
                }
            }

            mainString = String.Join(" ", words);
            Console.WriteLine($"Предложение: {mainString}");
            if (incorrectWords.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Слова с опечатками: ");
                Console.ResetColor();
                foreach (var word in incorrectWords)
                {
                    Console.Write($"({word}); ");
                }
                Console.WriteLine("\n");
            }
        }
    }

}

