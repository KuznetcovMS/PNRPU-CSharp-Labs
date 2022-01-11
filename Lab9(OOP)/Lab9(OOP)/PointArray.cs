using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_OOP_
{
    public class PointArray
    {
        private Point[] _arr;
        public int Length
        {
            get 
            {
                if (_arr == null) return 0;
                return _arr.Length; 
            }
        }

        public PointArray()
        {
            _arr = null;
        }

        public PointArray(int size)
        {
            if (size > 0)
            {
                _arr = new Point[size];
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    _arr[i] = new Point(rnd.Next(0, 100), rnd.Next(0, 100));
                }
            }
            else
            {
                Console.WriteLine("Размер массива должен быть > 0");
                _arr = null;
            }
                
           
        }

        public PointArray(PointArray pArr)
        {
            if (pArr != null)
            {
                _arr = new Point[pArr.Length];
                for (int i = 0; i < _arr.Length; i++)
                {
                    _arr[i] = pArr[i];
                }
            }
            else
            {
                Console.WriteLine("Передана пустая ссылка на массив");
                _arr = null;
            }
            
        }

        public void Show()
        {
            if (_arr == null)
            {
                Console.WriteLine("Массив пуст");
                return;
            }

            for (int i = 0;i < _arr.Length;i++)
            {
                Console.Write($"Элемент #{i} ");
                if (_arr[i] != null) _arr[i].Show();
                else Console.WriteLine("Null");
            }
        }

        public Point this[int index]
        {
            get 
            { 
                if (_arr == null)
                {
                    Console.WriteLine("Массив пуст!!!");
                    return null;
                }
                if (index < _arr.Length && index >= 0) return _arr[index];
                Console.WriteLine("Выход за пределы массива");
                return null;
            }
            set
            {
                if (_arr == null)
                {
                    Console.WriteLine("Массив пуст!!!");
                    _arr = null;
                }
                else if (index < _arr.Length && index >= 0)  _arr[index] = value;
                else
                {
                    Console.WriteLine("Выход за пределы массива");
                }
            }
        }

        public Point GetNearestPoint()
        {
            if (_arr == null)
            {
                Console.WriteLine("Массив пуст!!!");
                return null;
            }

            double dist = _arr[0].GetDistance();
            Point m = _arr[0];
            for (int i = 1; i < _arr.Length; i++)
            {
                if (_arr[i].GetDistance() < dist)
                {
                    m = _arr[i];
                    dist = _arr[i].GetDistance();
                }
            }
            return m;
        }

        public void PushBack(Point p)
        {
            if (_arr != null)
            {
                Point[] buf = new Point[_arr.Length + 1];
                for (int i = 0; i < _arr.Length; i++)
                {
                    buf[i] = _arr[i];
                }
                buf[buf.Length - 1] = p;
                _arr = buf;
            }
            else
            {
                _arr = new Point[1];
                _arr[0] = p; 
            }
        }
    }
}
