using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12;
using Lab10Lib;

namespace Lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyNewCollection<Document> col1 = new MyNewCollection<Document>("Col1");
            MyNewCollection<Document> col2 = new MyNewCollection<Document>("Col2");

            Journal j1 = new Journal();
            Journal j2 = new Journal();

            col1.CollectionCountChanged += j1.AddEntry;
            col1.CollectionReferenceChanged += j1.AddEntry;
            col1.CollectionReferenceChanged += j2.AddEntry;

            col2.CollectionReferenceChanged += j2.AddEntry;

            for (int i = 0; i < 10; i++)
            {
                col1.Add(new Receipt(i.ToString(), i.ToString(), i));
                col2.Add(new Check(i.ToString(), i.ToString(), i));
            }

            Console.WriteLine("Журнал #1 после добавления элементов");
            j1.Print();

            Console.WriteLine("\nЖурнал #2 после добавления элементов");
            j2.Print();
            Console.WriteLine("\n----------------------------------------\n");
            for (int i = 8; i < 12; i++)
            {
                col1.Remove(new Receipt(i.ToString(), i.ToString(), i));
                col2.Remove(new Check(i.ToString(), i.ToString(), i));
            }

            Console.WriteLine("Журнал #1 после удаления элементов");
            j1.Print();

            Console.WriteLine("\nЖурнал #2 после удаления элементов");
            j2.Print();
            Console.WriteLine("\n----------------------------------------\n");

            for (int i = - 2; i < 4; i++)
            {
                col1.FindChangeItem(new Receipt(i.ToString(), i.ToString(), i), new Check((i * 10).ToString(), (i * 10).ToString(), i * 10));
                col2.FindChangeItem(new Check(i.ToString(), i.ToString(), i), new Receipt((i * 10).ToString(), (i * 10).ToString(), i * 10));
            }

            Console.WriteLine("Журнал #1 после изменения элементов");
            j1.Print();

            Console.WriteLine("\nЖурнал #2 после изменения элементов");
            j2.Print();
            Console.WriteLine("\n----------------------------------------\n");

            Console.WriteLine("Элементы первой коллекции\n");
            foreach(var elem in col1) Console.WriteLine(elem.ToString());

            Console.WriteLine("\nЭлементы второй коллекции\n");
            foreach (var elem in col2) Console.WriteLine(elem.ToString());
        }
    }
}
