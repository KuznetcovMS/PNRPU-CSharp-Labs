using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab12;
using Lab10Lib;

namespace Lab12UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void BalanceTest()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 1; i < 20; i++)
            {
                tree.Add(i);
            }

            bool res = true;
            int prev = -1;
            foreach(int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DeleteTest()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 1; i < 20; i++)
            {
                tree.Add(i);
            }

            for (int i = 1; i < 10; i++)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res && tree.Count == 10);
        }

        [TestMethod]
        public void ConstructCopyTest()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 20; i > 0; i--)
            {
                tree.Add(i);
            }

            BalancedTree<int> tree2 = new BalancedTree<int>(tree);
            for (int i = 1; i < 11; i++)
            {
                tree.Remove(i);
            }

            Assert.IsTrue(tree2.Count - tree.Count == 10);
        }

        [TestMethod]
        public void CloneTest()
        {
            BalancedTree<Document> tree = new BalancedTree<Document>();
            for (int i = 20; i > 0; i--)
            {
                tree.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            BalancedTree<Document> tree2 = (BalancedTree<Document>)tree.Clone();
            for (int i = 1; i < 11; i++)
            {
                tree.Remove(new Receipt(i.ToString(), i.ToString(), i));
            }

            Assert.IsTrue(tree2.Count - tree.Count == 10);
        }

        [TestMethod]
        public void MCloneTest()
        {
            BalancedTree<Document> tree = new BalancedTree<Document>();
            for (int i = 20; i > 0; i--)
            {
                tree.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            BalancedTree<Document> tree2 = tree.MClone();
            
            var en = tree.GetEnumerator();
            en.MoveNext();

            bool res = true;
            foreach(var elem in tree2)
            {
                if (elem != en.Current) res = false;
                en.MoveNext();
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void ResetTest()
        {
            BalancedTree<Document> t = new BalancedTree<Document>();
            for (int i = 20; i > 0; i--)
            {
                t.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            BalancedTree<Document>.TreeEnumerator<Document> en = (BalancedTree<Document>.TreeEnumerator<Document>)t.GetEnumerator();

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
            
            Assert.AreEqual(en.Max.ToString(), "Receipt 20, 20, 20");
        }

        [TestMethod]
        public void ContainsTest()
        {
            BalancedTree<Document> t = new BalancedTree<Document>();
            t.Contains(null);
            for (int i = 20; i > 0; i--)
            {
                t.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            for (int i = 0; i < 20; i++)
            {
                t.Add(new Receipt(i.ToString(), i.ToString(), i));
            }

            Assert.IsTrue(t.Contains(new Receipt("1", "1", 1)) && t.Contains(new Receipt("10", "10", 10)) && !t.Contains(new Receipt("20", "20", 19)) && !t.Contains(new Receipt("21", "21", 21)));
        }


        [TestMethod]
        public void RemoveTest2()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 1; i < 20; i++)
            {
                tree.Add(i);
            }

            for (int i = 1; i < 20; i+=2)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res && tree.Count == 9);
        }


        [TestMethod]
        public void RemoveTest3()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 1; i < 20; i++)
            {
                tree.Add(i);
            }

            BalancedTree<int> t2 = new BalancedTree<int>(tree);

            for (int i = 1; i < 20; i++)
            {
                tree.Remove(i);
            }
            t2.Clear();
            Assert.AreEqual(tree.Count, t2.Count);
        }

        [TestMethod]
        public void RemoveTest4()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 0; i < 100; i++)
            {
                tree.Add(i);
            }

            for (int i = 20; i < 70; i++)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void ChangeTest()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 0; i < 100; i++)
            {
                tree.Add(i);
            }

            for (int i = 20; i < 70; i++)
            {
                tree.FindChangeItem(i, i*2);
            }
            tree.FindChangeItem(150, 50);
            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 0) 
                    res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void RemoveTest5()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            for (int i = 0; i < 1000; i++)
            {
                tree.Add(i);
            }

            for (int i = 0; i < 1000; i++)
            {
                tree.Add(i);
            }

            for (int i = 10; i < 1001; i++)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 0) res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void RemoveTest6()
        {
            BalancedTree<int> tree = new BalancedTree<int>();
            int[] arr = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = i;
            }
            tree.CopyTo(arr, 0);
            for (int i = 1000; i >= 0; i--)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void AddTest()
        {
            BalancedTree<Document> tree = new BalancedTree<Document>();
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    tree.Add(null);
                }

                for (int i = 0; i < 1000; i++)
                {
                    tree.Remove(null);
                }
            }
            catch (Exception)
            {

                
            }

            Assert.IsTrue(tree.Count == 0);
        }

        [TestMethod]
        public void RemoveTest7()
        {
            BalancedTree<int> tree = new BalancedTree<int>();

            for (int i = 1000; i >= 0; i--)
            {
                tree.Remove(i);
            }

            bool res = true;
            int prev = -1;
            foreach (int cur in tree)
            {
                if (cur.CompareTo(prev) < 1) res = false;
                prev = cur;
            }

            Assert.IsTrue(res);
        }
    }
}
