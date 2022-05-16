using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сombinatorics;

public class Calc
{
    public void Execute()
    {
        PrintMenu();
        SelectForm();
    }

    private void PrintMenu()
    {
        Console.WriteLine("Выберите формулу для расчёта:\n");

        Console.WriteLine("p  - Перестановки без повторений");
        Console.WriteLine("pr - Перестановки с повторениями");
        Console.WriteLine("a  - Размещения без повторений");
        Console.WriteLine("ar - Размещения с повторениями");
        Console.WriteLine("c  - Сочетания без повторений");
        Console.WriteLine("cr - Сочетания с повторениями\n");
    }

    private void SelectForm()
    {
        Console.Write("Формула: ");

        switch (Console.ReadLine())
        {
            case "p":
                CalculatePermutation();
                break;

            case "pr":
                CalculatePermutationRep();
                break;

            case "a":
                CalculateArrang();
                break;

            case "ar":
                CalculateArrangRep();
                break;

            case "c":
                CalculateComb();
                break;

            case "cr":
                CalculateCombRep();
                break;

            default:
                Console.WriteLine("Не верный код команды");
                break;
        }
    }

    private void CalculatePermutation()
    {
        Console.Clear();

        Console.WriteLine("Перестановки без повторений");
        Console.WriteLine("P = n!");        

        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (n < 0) Console.WriteLine("n должно быть больше 0");
        else
        {
            if (n <= 20) Console.WriteLine($"\nP = {Factorial(n)}");
            else Console.WriteLine("Число слишком велико");
        }   
    }

    private void CalculatePermutationRep()
    {
        string? divInput;
        string[] div;

        Console.Clear();
        Console.WriteLine("Перестановки с повторениями");
        Console.WriteLine("P = n! / (l1!*l2!*...*lk!)");

        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n)) 
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (n < 0) Console.WriteLine("n должно быть больше 0");
        else
        {
            if (n <= 20)
            {
                Console.Write("Введите все подразделения l: ");
                divInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(divInput))
                {
                    div = divInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (div != null)
                    {
                        long res = Factorial(n);
                        for (int i = 0; i < div.Length; i++)
                        {
                            res /= Factorial(Math.Abs(Convert.ToInt32(div[i])));
                        }
                        Console.WriteLine($"P = {res}");
                    }
                }
                else Console.WriteLine("Пустая строка");
            }
            else Console.WriteLine("Число слишком велико");
        }
    }

    private void CalculateArrang()
    {
        Console.Clear();

        Console.WriteLine("Размещения без повторений");
        Console.WriteLine("A = n! / (n - m)!");

        // Input n
        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }
        if (n < 0) { Console.WriteLine("n должно быть больше 0"); return; }

        // Input m
        Console.Write("Введите количество размещений m: ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (m < 0 || m > n) { Console.WriteLine("m должно быть больше 0 и меньше n"); return; }

        // Calculate result
        Console.WriteLine("\nA = " + DivFact(n, n - m));
    }

    private void CalculateArrangRep()
    {
        Console.Clear();

        Console.WriteLine("Размещения c повторениями");
        Console.WriteLine("A = n^m");

        // Input n
        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (n < 0) { Console.WriteLine("n должно быть больше 0"); return; }

        // Input m
        Console.Write("Введите количество размещений m: ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        Console.WriteLine($"A = {Math.Pow(n, m)}");
    }

    private void CalculateComb()
    {
        Console.Clear();

        Console.WriteLine("Сочетания без повторений");
        Console.WriteLine("С = n! / ((n - m)!) * m!)");

        // Input n
        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (n < 0) { Console.WriteLine("n должно быть больше 0"); return; }

        // Input m
        Console.Write("Введите количество размещений m: ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        // Calculate result
        Console.WriteLine("\nC = " + DivFact(n, n - m) / Factorial(m));
    }

    private void CalculateCombRep()
    {
        Console.Clear();

        Console.WriteLine("Сочетания c повторениями");
        Console.WriteLine("С = (n + m - 1)! / ((n - 1)!) * m!)");

        // Input n
        Console.Write("Введите количество элементов n: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        if (n < 0) { Console.WriteLine("n должно быть больше 0"); return; }

        // Input m
        Console.Write("Введите количество размещений m: ");
        if (!int.TryParse(Console.ReadLine(), out int m))
        {
            Console.WriteLine("Пустая строка!");
            return;
        }

        // Calculate result
        Console.WriteLine("\nC = " + DivFact(n + m - 1, n - 1) / Factorial(m));
    }

    private long Factorial(int n)
    {
        long res = 1;
        for (int i = 2; i <= n; i++)
        {
            res *= i;
        }
        return res;
    }

    private long DivFact(int num, int denom)
    {
        long res = 1;
        for (int i = denom + 1; i <= num; i++)
        {
            res *= i;
        }
        return res;
    }
}
    