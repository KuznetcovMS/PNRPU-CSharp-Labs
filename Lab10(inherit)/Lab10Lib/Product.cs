using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Lib
{
    public class Product : ICloneable
    {
        private string _name;
        private float _price;
        
        public Product ()
        {
            _name = "";
            _price = 0;
        }

        public Product(string name, float price)
        {
            _name = name;
            _price = price;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public object Clone()
        {
            return new Product(_name, _price);
        }

        public void Show()
        {
            Console.Write($"Наименование товара: {_name}, цена: {_price}");
        }
    }
}
