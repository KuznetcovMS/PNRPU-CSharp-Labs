using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_inherit_
{
    public class Program
    {
        static void Main(string[] args)
        {
            Waybill w1 = new Waybill(5);
            w1.Add(new Product("Пр1", 25), 5);
            w1.Add(new Product("Пр2", 150));

            Document[] docs = new Document[6];
            docs[0] = w1;
            (docs[0] as Waybill).Add(new Product("Пр3", 1200), 2);
            (docs[0] as Waybill).Add(new Product("Пр4", 30), 8);
            (docs[0] as Waybill).Add(new Product("Пр5", 50), 4);
            docs[0].VShow();
            docs[0].Show();
            Console.WriteLine();

            docs[1] = new Check("Комп1", "Чел1", 150000);
            docs[1].VShow();
            Console.WriteLine();

            Receipt r1 = new Receipt("Комп2", "банк1", 200000);
            docs[2] = r1;
            docs[2].VShow();
            (docs[2] as Check).Price = 300000;
            docs[2].VShow();

            docs[3] = new Check("Комп1", "Чел3", 500000);
            docs[4] = new Check("Комп2", "Чел2", 1000000);
            docs[5] = new Waybill(3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1500), 3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1100), 1);
            (docs[5] as Waybill).Add(new Product("Пр5", 100), 1);

            //Запросы
            float prodSum = 0;
            int numCheck = 0;
            float sumCheck = 0;
            foreach (var doc in docs)
            {
                
                if (doc is Waybill)
                {
                    prodSum += (doc as Waybill).GetSumByProdName("Пр3");
                }

                else if (doc is Check && !(doc is Receipt))
                {
                    Check buf = (Check)doc;
                    if (buf.Price > 150000) numCheck++; 
                    if (buf.Payer == "Комп1") sumCheck += buf.Price;
                }
            }
            Console.WriteLine($"\nЗапрос на Суммарная стоимость продукции заданного наименования по всем накладным (Пр3): {prodSum}") ;
            Console.WriteLine($"Запрос Количество чеков на сумму превышающую заданную (150 000): {numCheck}");
            Console.WriteLine($"Запрос Общая сумма по всем чекам, выписанным в организации (Комп1): {sumCheck}");

            //Интерфейсы
            Console.WriteLine("\nМассив IExecutable");
            IExecutable[] arrEx = new IExecutable[docs.Length];
            IExecutable[] arrEx2 = new IExecutable[docs.Length];
            for (int i = 0; i < arrEx.Length; i++)
            {
                arrEx[i] = docs[i];
                arrEx2[i] = docs[i];
                (arrEx[i] as Document).VShow();
            }

            Console.WriteLine("\nСортированный массив IExecutable через IComparable");
            Array.Sort(arrEx);
            foreach(Document el in arrEx)
            {
                el.VShow();
            }

            Console.WriteLine($"\n Сортированный массив IExecutable через IComparer<IExecutable>");
            Array.Sort(arrEx2, new SortBySum());
            foreach (Document el in arrEx2)
            {
                el.VShow();
            }

            //Клонирование
            Waybill wb1 = w1.MClone(); //Поверхностное
            Waybill wb2 = (Waybill)w1.Clone(); //Глубокое
            Console.WriteLine();
            w1.VShow();
            Console.WriteLine();
            wb1.VShow();
            w1.Add(new Product("Новый продукт", 99), 2);
            Console.WriteLine("\nЭкземпляр поверхностного копирования");
            wb1.VShow();
            Console.WriteLine("\n Экземпляр глубокого копирования");
            wb2.VShow();




            
        }
    }
}
