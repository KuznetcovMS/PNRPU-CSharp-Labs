using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab10Lib;

namespace Lab10LibUnitTests
{
    [TestClass]
    public class CheckTests
    {
        //Check Tests
        [TestMethod]
        public void TotalSumTest()
        {
            Check c = new Check();
            Assert.AreEqual(0, c.GetTotalSum());
        }

        [TestMethod]
        public void SetNegPriceTest()
        {
            Check c = new Check("1", "1", 50);
            c.Price = -50;
            Assert.AreEqual(50, c.Price);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Check c = new Check("1", "1", 50);
            
            Assert.AreEqual("Check 1, 1, 50", c.ToString());
        }

        [TestMethod]
        public void EqualTest()
        {
            Check c = new Check("1", "1", -50);
            Check c2 = new Check("1", "1", 0);

            Assert.AreEqual(c, c2);
        }


        [TestMethod]
        public void HashTest()
        {
            Check c = new Check("1", "1", 0);
            Check c2 = new Check("1", "2", 0);

           Assert.AreNotEqual(c.GetHashCode(), c2.GetHashCode());
        }

        [TestMethod]
        public void HashTestEQ()
        {
            Check c = new Check("1", "1", 0);
            Check c2 = new Check("1", "1", 0);

            Assert.AreEqual(c.GetHashCode(), c2.GetHashCode());
        }

        [TestMethod]
        public void EqualNullRefTest()
        {
            Check c = new Check("1", "1", -50);
            Check c2 = null;

            Assert.AreNotEqual(c, c2);
        }

        [TestMethod]
        public void EqualNotCheckTest()
        {
            Check c = new Check("1", "1", 50);
            Receipt r2 = new Receipt("1", "1", 50);

            Assert.AreNotEqual(c, r2);
        }

        [TestMethod]
        public void NullSetTest()
        {
            Check c1 = new Check();
            Check c2 = new Check("1", "1", 0);

            c1.Payer = "1";
            c1.Price = 0;
            c1.Recipient = "1";

            c2.Payer = null;
            c2.Price = -5;
            c2.Recipient = null;

            Assert.AreEqual(c1, c2);
        }

        //Receipt Tests
        [TestMethod]
        public void ReceiptBaseClassTest()
        {
            Receipt r1 = new Receipt();
            Check r2 = new Check("1", "2", 1);

            r1.BankName = "2";
            r1.Payer = "1";
            r1.Price = 1;

            Assert.AreEqual(r1.BaseCheck, r2);
        }

        [TestMethod]
        public void ReceiptToStringTest()
        {
            Receipt r1 = new Receipt("1", "1", 3);
            Receipt r2 = new Receipt("1", "2", 3);

            r1.BankName = r2.BankName;

            Assert.AreEqual(r1.ToString(), r2.ToString());
        }

        [TestMethod]
        public void ReceiptEqualTest()
        {
            Receipt r1 = new Receipt("1", "1", 3);
            Receipt r2 = new Receipt("1", "2", 3);

            r1.BankName = r2.BankName;

            Assert.AreEqual(r1, r2);
        }

        [TestMethod]
        public void ReceiptNullEqualTest()
        {
            Receipt r1 = new Receipt("1", "1", 3);

            Assert.AreNotEqual(r1, null);
        }

        [TestMethod]
        public void ReceiptNotTypeEqualTest()
        {
            Receipt r1 = new Receipt("1", "1", 3);
            Waybill w1 = new Waybill();

            Assert.AreNotEqual(r1, w1);
        }

        [TestMethod]
        public void ReceiptNotEqualTest()
        {
            Receipt r1 = new Receipt("1", "1", 3);
            Receipt r2 = new Receipt("1", "1", 1);

            Assert.AreNotEqual(r1, r2);
        }

        //Waybill Tests

        [TestMethod]
        public void DocumentSortTest()
        {
            Waybill w1 = new Waybill(5);
            w1.Add(new Product("Пр1", 25), 5);
            w1.Add(new Product("Пр2", 150));

            Document[] docs = new Document[8];
            docs[0] = w1;
            (docs[0] as Waybill).Add(new Product("Пр3", 1200), 2);
            (docs[0] as Waybill).Add(new Product("Пр4", 30), 8);
            (docs[0] as Waybill).Add(new Product("Пр5", 50), 4);

            docs[1] = new Check("Комп1", "Чел1", 150000);

            Receipt r1 = new Receipt("Комп2", "банк1", 200000);
            docs[2] = r1;
            (docs[2] as Check).Price = 300000;

            docs[6] = docs[2];
            docs[7] = docs[6];
            docs[7].CompareTo(docs[6]);

            docs[4] = new Check("Комп1", "Чел3", 500000);
            docs[3] = new Check("Комп2", "Чел2", 1000000);
            docs[5] = new Waybill(3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1500), 3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1100), 1);
            (docs[5] as Waybill).Add(new Product("Пр5", 100), 1);

            IExecutable[] arrEx = new IExecutable[docs.Length];
            IExecutable[] arrEx2 = new IExecutable[docs.Length];
            for (int i = 0; i < arrEx.Length; i++)
            {
                arrEx[i] = docs[i];
                arrEx2[i] = docs[i];
                (arrEx[i] as Document).VShow();
            }
            Array.Sort(arrEx);
            Array.Sort(arrEx2, new SortBySum());
            bool res = true;
            for (int i = 0;i < arrEx.Length;i++)
            {
                if (arrEx2[i] != arrEx[i]) res = false;
            }
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void WaybillGetSumByName()
        {
            Waybill w1 = new Waybill(5);
            w1.Add(new Product("Пр1", 25), 5);
            w1.Add(new Product("Пр2", 150));

            Document[] docs = new Document[6];
            docs[0] = w1;
            (docs[0] as Waybill).Add(new Product("Пр3", 1200), 2);
            (docs[0] as Waybill).Add(new Product("Пр4", 30), 8);
            (docs[0] as Waybill).Add(new Product("Пр5", 50), 4);

            docs[1] = new Check("Комп1", "Чел1", 150000);

            Receipt r1 = new Receipt("Комп2", "банк1", 200000);
            docs[2] = r1;
            (docs[2] as Check).Price = 300000;

            docs[3] = new Check("Комп1", "Чел3", 500000);
            docs[4] = new Check("Комп2", "Чел2", 1000000);
            docs[5] = new Waybill(3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1500), 3);
            (docs[5] as Waybill).Add(new Product("Пр3", 1100), 1);
            (docs[5] as Waybill).Add(new Product("Пр5", 100), 1);

            float prodSum = 0;
            foreach (var doc in docs)
            {

                if (doc is Waybill)
                {
                    prodSum += (doc as Waybill).GetSumByProdName("Пр3");
                }
            }
            Assert.AreEqual(prodSum, 8000);
        }

        [TestMethod]
        public void InvalidSizeWaybill()
        {
            Waybill waybill1 = new Waybill();
            Waybill waybill2 = new Waybill(-5);
            Assert.AreEqual(waybill1, waybill2);
        }

        [TestMethod]
        public void CloneTest()
        {
            Waybill w1 = new Waybill(5);
            w1.Add(new Product("Пр1", 25), 5);
            w1.Add(new Product("Пр2", 150));

            Waybill wc1 = (Waybill)w1.Clone();//глубокое
            Waybill wc2 = w1.MClone();//Поверхностное

            w1.Add(new Product("Пр3", 200));

            Assert.AreEqual(w1, wc2);
            Assert.AreNotEqual(wc1, wc2);
        }


        [TestMethod]
        public void ProductTest()
        {
            Product product = new Product();
            Product product2 = new Product("1", 2);
            product.Name = product2.Name;
            product.Price = product2.Price;
            Assert.IsTrue((product.Name == product2.Name) && (product.Price == product2.Price));
        }

    }
}
