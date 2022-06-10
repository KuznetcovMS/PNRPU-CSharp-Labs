using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10Lib;
using Lab12;

namespace Lab14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Stack<Document>> documents = new Dictionary<int, Stack<Document>>();
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                documents.Add(i, new Stack<Document>());
                for (int j = 0; j < 10; j++)
                {
                    int val = rnd.Next(1, 100);
                    documents[i].Push(new Check(val.ToString(), val.ToString(), val));
                }
            }

           

            // Запрос №1 
            RunQuery1L(ref documents);
            RunQuery1E(ref documents);

            // Запрос №2  
            RunQuery2L(ref documents);
            RunQuery2E(ref documents);

            // Запрос №3 
            RunQuery3L(ref documents);
            RunQuery3E(ref documents);

            // Запрос №4
            RunQuery4L(ref documents);
            RunQuery4E(ref documents);

            // Запрос №5
            RunQuery5L(ref documents);
            RunQuery5E(ref documents);

            Console.WriteLine("\nЗапросы для бинарного дерева");
            RunTreeQuery();

        }

        static void RunTreeQuery()
        {
            BalancedTree<Document> bt = new BalancedTree<Document>();
            for (int i = 0; i < 10; i++)
            {
                bt.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            var q1 = bt.Where(d => d.GetTotalSum() % 2 == 0);
            Console.WriteLine("Запрос Where");
            foreach (var d in q1)
            {
                Console.WriteLine(d);
            }
            var q2 = bt.Min();
            var q3 = bt.Max();
            var q4 = bt.OrderBy(d => d);

            Console.WriteLine("Order by");
            foreach (var d in q4)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("Max " + q3);
            Console.WriteLine("Min " + q2);
        }

        static void RunQuery1L(ref Dictionary<int, Stack<Document>> documents)
        {
            var q1 = from folder in documents.Values 
                     where folder.Count(d => d.GetTotalSum() > 60) > 5 
                     select folder;

            Console.WriteLine($"Запрос №1 (LINQ) список папок в которых кол-во документов на стоимость > 60 больше 5 штук: {q1.Count()}");
            foreach (var fold in q1)
            {
                foreach (var elem in fold)
                {
                    Console.WriteLine(elem.ToString());
                }
                Console.Write("Кол-во элементов с общей стоимостью > 60: ");
                Console.WriteLine(fold.Count(d => d.GetTotalSum() > 60) + "\n");
            }
        }

        static void RunQuery1E(ref Dictionary<int, Stack<Document>> documents)
        {
            var q1 = documents.Values
                .Where(f => f.Count(d => d.GetTotalSum() > 60) > 5)
                .Select(d => d);

            Console.WriteLine($"Запрос №1 (методы расширения) список папок в которых кол-во документов на стоимость > 60 больше 5 штук: {q1.Count()}");
            foreach (var fold in q1)
            {
                foreach (var elem in fold)
                {
                    Console.WriteLine(elem.ToString());
                }
                Console.Write("Кол-во элементов с общей стоимостью > 60: ");
                Console.WriteLine(fold.Count(d => d.GetTotalSum() > 60) + "\n");
            }
        }

        static void RunQuery2L(ref Dictionary<int, Stack<Document>> documents)
        {
            var q2 = (from folder in documents.Values
                      from doc in folder 
                      where doc.GetTotalSum() % 5 == 0 && doc.GetTotalSum() != 0
                      select doc)
                      .Count();

            Console.Write("Запрос №2 (Linq) кол-во документов с общей суммой кратной 5: ");
            Console.WriteLine(q2 + "\n");
        }

        static void RunQuery2E(ref Dictionary<int, Stack<Document>> documents)
        {
            var q2 = documents.Values.SelectMany(f => f).Where(d => d.GetTotalSum() % 5 == 0 && d.GetTotalSum() != 0).Count();

            Console.Write("Запрос №2 (методы расширения) кол-во документов с общей суммой кратной 5: ");
            Console.WriteLine(q2 + "\n");
        }

        static void RunQuery3L(ref Dictionary<int, Stack<Document>> documents)
        {
            var q3 = (from doc in documents[0] select doc).Intersect(from doc1 in documents[1] select doc1);

            Console.WriteLine("Запрос №3 (Linq) пересечение первых двух папок по сумме в чеке");

            Console.WriteLine("Папка №1");
            foreach (var doc in documents[0])
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("\nПапка №2");
            foreach (var doc in documents[1])
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("\nПересечение");
            foreach (var el in q3)
            {
                Console.WriteLine(el.ToString());
            }
        }

        static void RunQuery3E(ref Dictionary<int, Stack<Document>> documents)
        {
            var q3 = documents[0].Intersect(documents[1]);

            Console.WriteLine("\nЗапрос №3 (методы расширения) пересечение первых двух папок по сумме в чеке");

            Console.WriteLine("Папка №1");
            foreach (var doc in documents[0])
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("\nПапка №2");
            foreach (var doc in documents[1])
            {
                Console.WriteLine(doc.ToString());
            }

            Console.WriteLine("\nПересечение");
            foreach (var el in q3)
            {
                Console.WriteLine(el.ToString());
            }
        }

        static void RunQuery4L(ref Dictionary<int, Stack<Document>> documents)
        {
            Console.WriteLine("\nЗапрос №4 (Linq) поиск максимальной и минимальной суммы среди всех чеков");

            Console.WriteLine($"Максимальный чек: {(from folder in documents from doc in folder.Value select doc).Max()}");
            Console.WriteLine($"Средний чек: {(from folder in documents from doc in folder.Value select doc.GetTotalSum()).Average()}");
            Console.WriteLine($"Минимальный чек: {(from folder in documents from doc in folder.Value select doc).Min()}");
        }

        static void RunQuery4E(ref Dictionary<int, Stack<Document>> documents)
        {
            Console.WriteLine("\nЗапрос №4 (Методы расширения) поиск максимальной и минимальной суммы среди всех чеков");

            Console.WriteLine($"Максимальный чек: {documents.Values.SelectMany(f => f).Select(d => d).Max()}");
            Console.WriteLine($"Средний чек: {documents.Values.SelectMany(f => f).Select(d => d.GetTotalSum()).Average()}");
            Console.WriteLine($"Минимальный чек: {documents.Values.SelectMany(f => f).Select(d => d).Min()}");
        }

        static void RunQuery5L(ref Dictionary<int, Stack<Document>> documents)
        {
            Console.WriteLine("\nЗапрос №5 (Linq) группировка чеков на чётные и нечётные");
            var q5 = from folder in documents.Values from doc in folder group doc by doc.GetTotalSum() % 2 == 0 ? "Чётные" : "Нечётные";
            
            foreach(var group in q5)
            {
                Console.WriteLine($"\nГруппа: {group.Key}");
                foreach(var doc in group)
                {
                    Console.WriteLine(doc.ToString());
                }
            }
        }

        static void RunQuery5E(ref Dictionary<int, Stack<Document>> documents)
        {
            Console.WriteLine("\nЗапрос №5 (методы расширения) группировка чеков на чётные и нечётные");

            var q5 = documents.Values.SelectMany(f => f).Select(d => d).GroupBy(d => d.GetTotalSum() % 2 == 0 ? "Чётные" : "Нечётные");

            foreach (var group in q5)
            {
                Console.WriteLine($"\nГруппа: {group.Key}");
                foreach (var doc in group)
                {
                    Console.WriteLine(doc.ToString());
                }
            }
        }


    }
}
