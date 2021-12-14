using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_OOP_
{
    class Point
    {
        private double x;
        private double y;
        private static int instancesCount = 0;

        public Point()
        {
            x = 0;
            y = 0;
            instancesCount++;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            instancesCount++;
        }

        ~Point()
        {
            instancesCount--;
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public static int GetInstancesCount()
        {
            return instancesCount; 
        }

        public double GetDistance()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static double GetDistance(Point p)
        {
            return Math.Sqrt(p.x * p.x + p.y * p.y);
        }

        public void Show()
        {
            Console.WriteLine($"X = {x}, Y = {y}");
        }

        public static Point operator--(Point p)
        {
            p.x--;
            p.y--;
            return p;
        }

        public static Point operator-(Point p)
        {
            (p.y, p.x) = (p.x, p.y);
            return p;
        }

        public static Point operator-(Point p, int val)
        {
            p.x -= val;
            return p;
        }

        public static Point operator-(int val, Point p)
        {
            p.y -= val;
            return p;
        }

        public static double operator-(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }

        public static implicit operator int(Point p)
        {
            return (int)p.x;
        }

        public static explicit operator double(Point p)
        {
            return p.y;
        }

    }
}
