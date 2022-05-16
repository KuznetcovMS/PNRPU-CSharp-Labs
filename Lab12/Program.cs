using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lab10Lib;

namespace Lab12
{
    internal class Program
    {
        static void test(ref BalancedTree<int> b)
        {
            int prev = -100;
            foreach(var el in b)
            {
                if (el < prev) 
                    Console.WriteLine($"Error {prev} -> {el}");
                prev = el;
            }
        }
        static void Main(string[] args)
        {
            BalancedTree<int> bt = new BalancedTree<int>();
            for (int i = 0; i < 100; i++)
            {
                bt.Add(i);
                test(ref bt);
            }
            bt.FindChangeItem(5, 100);
            for (int i = 20; i < 70; i++)
            {
                bt.Remove(i);
                Console.Write(i + " ");
                test(ref bt);
                bt.Add(i * 10);
            }
            Console.WriteLine(bt.Contains(11));
            foreach(var el in bt)
            {
                Console.WriteLine(el);
            }

            Random rand = new Random();
            BalancedTree<Document> t = new BalancedTree<Document>();

            Console.WriteLine("Добавление элементов в дерево:");
            for (int i = 0; i < 10; i++)
            {
                t.Add(new Receipt(i.ToString(), i.ToString(), i));
            }
            Console.WriteLine($"Количество элементов: {t.Count}");
            foreach(var elem in t)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine($"Поиск элемента Receipt(2, 2, 2) {t.Contains(new Receipt("2", "2", 2))}");
            Console.WriteLine($"Поиск элемента Check(2, 2, 2) {t.Contains(new Check("2", "2", 2))}");
            Console.WriteLine($"Поиск элемента Receipt(10, 10, 10) {t.Contains(new Receipt("10", "10", 10))}\n");
            t.Clear();


            Console.WriteLine("Добавление случайных элементов");
            for (int i = 0; i < 10; i++)
            {
                int res1 = rand.Next(100);
                int res2 = rand.Next(100);
                Console.WriteLine($"Receipt: {res1}");
                Console.WriteLine($"Check: {res2}");
                t.Add(new Receipt(res1.ToString(), res1.ToString(), res1));
                t.Add(new Check(res2.ToString(), res2.ToString(), res2));
            }

            Console.WriteLine("\nВывод через foreach");
            foreach (var elem in t)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine("\nКонструктор BalancedTree(BalancedTree t)");
            BalancedTree<Document> t2 = new BalancedTree<Document>(t);
            foreach (var elem in t2)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine("\nКлонирование и добавление элемента Check(100, 100, 100)");
            BalancedTree<Document> t3 = (BalancedTree<Document>)t2.Clone();
            t3.Add(new Check("100", "100", 100));
            Console.WriteLine("t2");
            foreach (var elem in t2)
            {
                Console.WriteLine(elem.ToString());
            }
            Console.WriteLine("\nt3");
            foreach (var elem in t3)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine("\nПоверхностное копирование");
            BalancedTree<Document> t4 = t3.MClone();
            t3.Add(new Check("101", "101", 101));
            foreach (var elem in t4)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine("\nЭнумератор");
            var en = t.GetEnumerator();

            for (int i = 0; i < 10; i++)
            {
                en.MoveNext();
                Console.WriteLine(en.Current.ToString());

            }
            en.Reset();
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                en.MoveNext();
                Console.WriteLine(en.Current.ToString());
            }
        }
    }
}
