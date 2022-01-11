using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Lab9_OOP_;

namespace UnitTestLab9
{
    [TestClass]
    public class UnitTestAL9
    {
        [TestMethod]
        public void IndexGetTest()
        {
            PointArray pa = new PointArray(5);
            PointArray pb = new PointArray(5);

            pa[0] = pb[4];
            Assert.AreEqual(pa[0], pb[4]);
        }

        [TestMethod]
        public void IndexGetOutOfRangeTest()
        {
            PointArray pa = new PointArray(5);

            Assert.AreEqual(pa[5], null);
        }

        [TestMethod]
        public void IndexGetNullArrayTest()
        {
            PointArray pa = new PointArray();
            Assert.IsNull(pa[0]);
        }

        [TestMethod]
        public void IndexSetNullArrayTest()
        {
            PointArray pa = new PointArray();
            pa[0] = new Point(5, 5);
            Assert.IsNull(pa[0]);
        }

        [TestMethod]
        public void IndexSetNullValArrayTest()
        {
            PointArray pa = new PointArray(5);
            pa[0] = null;
            Assert.IsNull(pa[0]);
        }

        [TestMethod]
        public void OutIndexSetValArrayTest()
        {
            PointArray pa = new PointArray(5);
            pa[6] = new Point(5, 5);
            Assert.IsNotNull(pa[0]);
        }

        [TestMethod]
        public void NegatSizeArrayTest()
        {
            PointArray pa = new PointArray(-10);
            Assert.IsNull(pa[0]);
        }


        [TestMethod]
        public void GetLengthNullArrTest()
        {
            PointArray pa = new PointArray();
            Assert.AreEqual(0, pa.Length);
        }

        [TestMethod]
        public void GetLengthArrTest()
        {
            PointArray pa = new PointArray(5);
            Assert.AreEqual(5, pa.Length);
        }

        [TestMethod]
        public void ArrayConstructTest()
        {
            PointArray pa = new PointArray(5);
            PointArray pb = new PointArray(pa);

            Assert.AreEqual(pa[2], pb[2]);
        }

        [TestMethod]
        public void NullArrayConstructTest()
        {
            PointArray pa = null;
            PointArray pb = new PointArray(pa);

            Assert.IsNull(pb[0]);
        }

        [TestMethod]
        public void GetNearestPointTest()
        {
            PointArray pa = new PointArray();
            pa.PushBack(new Point(25, 25));
            pa.PushBack(new Point(35, 21));


            Assert.AreEqual(pa[0].GetDistance(), pa.GetNearestPoint().GetDistance());
        }

        [TestMethod]
        public void GetNearestPointTest2()
        {
            PointArray pa = new PointArray(5);
            pa.PushBack(new Point(0, 0));



            Assert.AreEqual(0, pa.GetNearestPoint().GetDistance());
        }

        [TestMethod]
        public void GetNearestPointNullArrayTest()
        {
            PointArray pa = new PointArray();
            Assert.IsNull(pa.GetNearestPoint());
        }
    }
}