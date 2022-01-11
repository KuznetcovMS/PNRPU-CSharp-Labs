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
        static Dictionary<char, int> ops;
        static string curExp;
        static string rpn;

        static void Main(string[] args)
        {
            vars = new List<char>(5);
            varsVal = new List<bool>(5);
            bool shoudExit = false; ;

            ops = new Dictionary<char, int>();
            ops.Add('!', 7);
            ops.Add('|', 6);
            ops.Add('/', 5);
            ops.Add('&', 4);
            ops.Add('+', 3);
            ops.Add('^', 3);
            ops.Add('>', 2);
            ops.Add('~', 1);
            ops.Add('(', 0);


            while (!shoudExit)
            {
                Console.WriteLine("Калькулятор булевых выражений\n");
                Console.WriteLine("Операторы: \n! - NOT \n| - Штрих Шеффера \n/ - Стрелка Пирса \n& - AND \n+ - OR \n^ - Кольцевая сумма \n> - Импликация \n~ - Эквиваленция\n");
                vars.Clear();
                varsVal.Clear();

                Console.Write("Введите выражение: ");
                curExp = DelSpace(Console.ReadLine()); //Удаление всех пробелов;

                FindAllVars(); //Поиск всех переменных
                PrintTableHeader(); //Заголовок таблицы истинности
                SetRPN(); //Вычисление польской обратной записи
                Compute(); //Расчёты и вывод результата

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
            Console.WriteLine("Res|");
        }
        static void FindAllVars()
        {
            //Обход элементов выражения и поиск букв
            foreach (char elem in curExp)
            {
                if (char.IsLetter(elem) && !vars.Contains(elem))
                {
                    vars.Add(elem);
                    varsVal.Add(false);
                }
            }
            vars.Sort();
        }

        static void SetRPN()
        {
            List<char> buf = new List<char>(curExp.Length);
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < curExp.Length; i++)
            {
                if (char.IsLetterOrDigit(curExp[i])) buf.Add(curExp[i]); //Вставка переменных и констант
                else if (ops.ContainsKey(curExp[i]) && curExp[i] != '(') //Вставка операторов
                {
                    if (stack.Count == 0) stack.Push(curExp[i]);
                    else if (ops[stack.Peek()] < ops[curExp[i]]) stack.Push(curExp[i]);
                    else
                    {
                        while (stack.Count > 0 && ops[stack.Peek()] >= ops[curExp[i]])
                        {
                            buf.Add(stack.Pop());
                        }
                        stack.Push(curExp[i]);
                    }
                }
                //Обработка скобок
                else if (curExp[i] == '(') stack.Push(curExp[i]);
                else if (curExp[i] == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        buf.Add(stack.Pop());
                    }
                    stack.Pop();
                }

            }
            while (stack.Count > 0) buf.Add(stack.Pop());
            rpn = new string(buf.ToArray());
        }

        static void CalcRPN()
        {
            Stack<char> stack = new Stack<char>();
            bool lo, ro;
            foreach (char tock in rpn)
            {
                if (char.IsLetterOrDigit(tock)) stack.Push(tock);
                else
                {

                    switch (tock)
                    {
                        case '!':
                            lo = !GetOperand(stack.Pop());
                            stack.Push(BoolToChar(lo));
                            break;

                        case '|':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(!(lo && ro)));
                            break;
                        case '/':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(!(lo || ro)));
                            break;
                        case '&':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(lo && ro));
                            break;
                        case '+':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(lo || ro));
                            break;
                        case '^':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(lo ^ ro));
                            break;
                        case '>':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(!lo || ro));
                            break;
                        case '~':
                            ro = GetOperand(stack.Pop());
                            lo = GetOperand(stack.Pop());
                            stack.Push(BoolToChar(lo == ro));
                            break;
                    }
                }
            }
            Console.Write(" " + stack.Pop() + " |");
        }

        static bool GetOperand(char op)
        {
            if (char.IsLetter(op))
            {
                return varsVal[vars.IndexOf(op)];
            }
            else if (char.IsDigit(op))
            {
                return Convert.ToBoolean(Convert.ToInt32(Convert.ToString(op)));
            }
            return false;
        }

        static char BoolToChar(bool val)
        {
            return Convert.ToString(Convert.ToInt32(val))[0];
        }
        static void Compute()
        {
            if (vars.Count == 0) return;

            for (int i = 0; i < Math.Pow(2, vars.Count); i++)
            {
                SetupCurVarVal(i);
                CalcRPN();
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