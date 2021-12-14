using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_inherit_
{
    public class Waybill : Document, ICloneable
    {
        private List<Tuple<Product, int>> _posWaybill; //1 - продукт, 2 - кол-во

        public Waybill()
        {
            _posWaybill = new List<Tuple<Product, int>>(10);
        }

        public Waybill(int count)
        {
            if (count > 0)
            {
                _posWaybill = new List<Tuple<Product, int>>(count);
            }
            else
            {
                Console.WriteLine("Кол-во элементов должно быть больше нуля. Установлен размер списка по дефолту = 10");
                _posWaybill = new List<Tuple<Product, int>>(10);
            }
            
        }
        public override void VShow()
        {
            Console.WriteLine("Накладная (overrided VShow)");
            if (_posWaybill.Count > 0)
            {
                float total = 0;
                for (int i = 0; i < _posWaybill.Count; i++)
                {
                    Console.Write($"Позиция #{i + 1}: ");
                    _posWaybill[i].Item1.Show();
                    Console.Write($", Кол-во {_posWaybill[i].Item2}, Сумма: {_posWaybill[i].Item1.Price * _posWaybill[i].Item2}\n");
                    total += _posWaybill[i].Item1.Price * _posWaybill[i].Item2;
                }
                Console.WriteLine($"Итого: {total}");

            }
            
            else { Console.WriteLine("Накладная пуста"); }
        }

        public void Show()
        {
            Console.WriteLine("Накладная (overrided Show)");
            if (_posWaybill.Count > 0)
            {
                for (int i = 0; i < _posWaybill.Count; i++)
                {
                    Console.Write($"Позиция #{i + 1}: ");
                    _posWaybill[i].Item1.Show();
                    Console.Write($", Кол-во {_posWaybill[i].Item2}, Сумма: {_posWaybill[i].Item1.Price * _posWaybill[i].Item2}\n");
                }
            }

            else { Console.WriteLine("Накладная пуста"); }
        }
        
        public float GetSumByProdName(string prodName)
        {
            float sum = 0;
            foreach (var product in _posWaybill)
            {
                if (product.Item1.Name == prodName)
                {
                    sum += product.Item1.Price * product.Item2;
                }
            }
            return sum;
        }
        public void Add(Product p, int count = 1)
        {
                _posWaybill.Add(new Tuple<Product, int>(p, count));
          
        }

        public override void exec()
        {
            Console.WriteLine("exec method in Waybill");
        }

        public override float GetTotalSum()
        {
            float total = 0;
            foreach(var product in _posWaybill)
            {
                total += product.Item1.Price * product.Item2;
            }
            return total;
        }

        public object Clone()
        {
            Waybill buf = new Waybill(this._posWaybill.Count);
            foreach (var item in _posWaybill)
            {
                buf.Add((Product)item.Item1.Clone(), item.Item2);
            }
            return buf;
        }

        public Waybill MClone()
        {
            return MemberwiseClone() as Waybill;
        }
    }
}
