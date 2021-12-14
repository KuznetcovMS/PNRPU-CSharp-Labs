using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2BoolCalc
{
    internal class Program
    {
        static List<char> vars;
        static List<bool> varsVal;
        readonly string[] ops = { "!", "|", "/", "&", "||", "+", "->", "~"};

        static void Main(string[] args)
        {
            vars = new List<char>(5);
            varsVal = new List<bool>(5);
            bool shoudExit = false;
            string curExp;

            while (!shoudExit)
            {
                Console.WriteLine("Калькулятор булевых выражений\n");
                Console.WriteLine("Операторы: \n! - NOT \n| - Штрих Шеффера \n/ - Стрелка Пирса \n& - AND \n|| - OR \n+ - Кольцевая сумма \n-> - Импликация \n~ - Эквиваленция\n");
                vars.Clear();
                varsVal.Clear();

                Console.Write("Введите выражение: ");
                curExp = DelSpace(Console.ReadLine()); //Удаление всех пробелов;

                FindAllVars(ref curExp); //Поиск всех переменных
                PrintTableHeader(); //Заголовок таблицы истинности
                Compute(ref curExp); //Расчёты и вывод результата

                Console.Write("Ввести новое выражение (y/n): ");
                if (Console.ReadLine() == "n") shoudExit = true;
                else Console.Clear();
            }
        }

        static string DelSpace(string s)
        {
            List<char> buf = new List<char>(10);
            
            foreach (char c in s)
            {
                if (c != ' ') buf.Add(c);
            }
   
            return new string(buf.ToArray());
        }
        static void PrintTableHeader()
        {
            Console.WriteLine("\nТаблица истинности");
            Console.Write("|");
            foreach (var elem in vars)
            {
                Console.Write(elem + "|");
            }
            Console.Write("Result|\n");
        }
        static void FindAllVars(ref string expres)
        {
            //Обход элементов выражения и поиск букв
            foreach (char elem in expres)
            {
                if (char.IsLetter(elem) && !vars.Contains(elem))
                {
                    vars.Add(elem);
                    varsVal.Add(false);
                }
            }
            vars.Sort();
        }

        static void Compute(ref string exp)
        {
            if (vars.Count == 0) return;

            for (int i = 0; i < Math.Pow(2, vars.Count); i++)
            {
                SetupCurVarVal(i);
                
                Console.WriteLine();
            }
        }

        static void SetupCurVarVal(int i)
        {
            string binVal = Convert.ToString(i, 2);
            int charpos = 0;
            Console.Write("|");
            for (int j = 0; j < varsVal.Count; j++)
            {
                //Установка текущего значения переменных
                if (varsVal.Count - j <= binVal.Length)
                    varsVal[j] = Convert.ToBoolean(Convert.ToInt32(Convert.ToString(binVal[charpos++])));
                Console.Write(Convert.ToInt32(varsVal[j]) + "|");
            }
        }
    }
}
