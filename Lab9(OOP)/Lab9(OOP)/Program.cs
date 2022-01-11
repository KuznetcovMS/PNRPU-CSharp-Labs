using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_OOP_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            Console.WriteLine("Задача #1");
            Point p1 = new Point();
            p1.X = 10.5;
            p1.Y = 20.0;
            p1.Show();

            Point p2 = new Point(25.148, 12.26);
            p2.Show();

            Point p3 = new Point();

            Console.WriteLine($"\np1 Метод GetDistance: {p1.GetDistance()}");
            Console.WriteLine($"p2 Метод GetDistance: {p2.GetDistance()}");

            Console.WriteLine($"\np1 Статический метод GetDistance: {Point.GetDistance(p1)}");
            Console.WriteLine($"p2 Статический метод GetDistance: {Point.GetDistance(p2)}");

            Console.WriteLine("\nВведите координаты точки p3");
            double buf;
            ReadCorrectVal(out buf, "X: ");
            p3.X = buf;
            ReadCorrectVal(out buf, "Y: ");
            p3.Y = buf;

            p3.Show();
            Console.WriteLine($"\np3 Метод GetDistance: {p3.GetDistance()}");
            Console.WriteLine($"p3 Статический метод GetDistance: {Point.GetDistance(p3)}");

            Console.WriteLine($"\nКолличество экземпляров Point: {Point.GetInstancesCount()}");

            //Task #2
            Console.WriteLine("\n\nЗадача #2");

            Point p4 = new Point(5.5, 7.25);
            Console.WriteLine("p4:");
            p4.Show();

            Console.WriteLine("Унарный оператор -- для p4");
            p4--;
            p4.Show();

            Console.WriteLine("Унарный оператор - p4");
            p4 = -p4;
            p4.Show();

            Console.WriteLine("Неявное приведение типа (int)");
            int x = p4;
            Console.WriteLine(x);

            Console.WriteLine("Явное приведение типа (double)");
            double y = (double)p4;
            Console.WriteLine(y);

            Console.WriteLine("Левосторонный бинарный оператор - ");
            p4 = p4 - 2;
            p4.Show();

            Console.WriteLine("Правосторонный бинарный оператор - ");
            p4 = 2 - p4;
            p4.Show();


            Console.WriteLine("Бинарный оператор Point - Point");
            Point p5 = new Point(12.6, 7.2);
            p5.Show();
            Console.WriteLine($"Расстояние от p4 до p5: {p4 - p5}");

            //Task #3
            Console.WriteLine("\nЗадача #3");

            Console.WriteLine("Конструктор без параметров");
            PointArray pointArray1 = new PointArray();
            pointArray1.Show();
            pointArray1.PushBack(p5);
            pointArray1.Show();

            Console.WriteLine("\nКонструктор с заполнением через дсч");
            PointArray pointArray2 = new PointArray(10);
            pointArray2.Show();

            Point near = pointArray2.GetNearestPoint();
            Console.WriteLine("Ближайшая точка: " + near.GetDistance());
            near.Show();

            Console.WriteLine("\nВведите 5 элемнтов");
            PointArray arr = new PointArray(5);
            for (int i = 0; i < arr.Length; i++)
            {
                ReadCorrectVal(out double X, "X: ");
                ReadCorrectVal(out double Y, "Y: ");
                arr[i] = new Point(X, Y);
            }
            PointArray pointArray3 = new PointArray(arr);
            pointArray3.Show();
            near = pointArray3.GetNearestPoint();
            Console.WriteLine("Ближайшая точка: " + near.GetDistance());
            near.Show();

            Console.WriteLine("\n Доступ по индексу");
            pointArray3[1].Show();

            pointArray3[2] = pointArray3[1];
            pointArray3[2].Show();

            Console.WriteLine($"\n\nВсего экземпляров класса Piont: {Point.GetInstancesCount()}");
            Console.ReadKey();

        }

        public static void ReadCorrectVal(out double val, string mess)
        {
            bool successInput = false;
            val = 0;
            while (!successInput)
            {
                Console.Write(mess);
                if (double.TryParse(Console.ReadLine(), out val))
                {
                    successInput = true;
                }
                else
                {
                    Console.WriteLine("Введённую строку невозможно преобразовать в double");
                }
            }
        }
    }
}
