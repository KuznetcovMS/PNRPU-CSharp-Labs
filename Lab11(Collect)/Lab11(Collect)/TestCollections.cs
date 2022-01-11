using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Lab10Lib;

namespace Lab11_Collect_
{
    internal class TestCollections
    {
        private Queue<Check> clsQueue;
        private Queue<string> strQueue;

        private Dictionary<Check, Receipt> clsDict;
        private Dictionary<string, Receipt> strDict;

        private int capacity;

        public Queue<Check> ClsChecks
        {
            get { return clsQueue; }
        }

        public Queue<string> StrChecks
        {
            get { return strQueue; }
        }

        public Dictionary<string, Receipt> StrDicts
        {
            get { return strDict; }
        }

        public Dictionary<Check, Receipt> ClsDicts
        {
            get { return clsDict; }
        }

        public TestCollections()
        {
            clsQueue = new Queue<Check>(10);
            strQueue = new Queue<string>(10);
            clsDict = new Dictionary<Check, Receipt>(10);
            strDict = new Dictionary<string, Receipt>(10);
            capacity = 10;
            InitCollections();
        }

        public TestCollections(int len)
        {
            clsQueue = new Queue<Check>(len);
            strQueue = new Queue<string>(len);
            clsDict = new Dictionary<Check, Receipt>(len);
            strDict = new Dictionary<string, Receipt>(len);
            capacity = len;
            InitCollections();
        }

        public void InitCollections()
        {
            for (int i = 0; i < capacity; i++)
            {
                Check bufc = new Check(Convert.ToString(i), Convert.ToString(i), i);
                clsQueue.Enqueue(bufc);
                strQueue.Enqueue(bufc.ToString());

                Receipt bufr = new Receipt(Convert.ToString(i), Convert.ToString(i), i);
                clsDict.Add(bufc, bufr);
                strDict.Add(bufc.ToString(), bufr);
            }
        }

        public void bench(string payer, string recip, float price)
        {
            Stopwatch sw = new Stopwatch();
            bool res;
            Receipt rec = new Receipt(payer, recip, price);
            Check ch = rec.BaseCheck;
            string strch = ch.ToString();

            sw.Restart();
            res = clsQueue.Contains(ch);
            sw.Stop();
            Console.WriteLine($"Queue<Check>: result: {res}, Time span: {sw.ElapsedTicks}");

            sw.Restart();
            res = strQueue.Contains(strch);
            sw.Stop();
            Console.WriteLine($"Queue<string>: result: {res}, Time span: {sw.ElapsedTicks}");

            sw.Restart();
            res = clsDict.ContainsValue(rec);
            sw.Stop();
            Console.WriteLine($"Dictionary<Check, Receipt>: result: {res}, Time span: {sw.ElapsedTicks}");

            sw.Restart();
            res = strDict.ContainsKey(strch);
            sw.Stop();
            Console.WriteLine($"Dictionary<string, Receipt>: result: {res}, Time span: {sw.ElapsedTicks}");
        }
        public void RunContainsBenchmarks()
        {
            Console.WriteLine("Первый проход с кешированием");
            bench("0", "0", 0);

            Console.WriteLine("\nПоиск первого элемента");
            bench("0", "0", 0);

            Console.WriteLine("\nПоиск среднего элемента");
            bench("500", "500", 500);

            Console.WriteLine("\nПоиск последнего элемента");
            bench("999", "999", 999);

            Console.WriteLine("\nПоиск не существующего элемента");
            bench("1000", "1000", 1000);
        }

    }
}
