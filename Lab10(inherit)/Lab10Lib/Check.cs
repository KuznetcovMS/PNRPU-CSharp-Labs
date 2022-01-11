using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Lib
{
    public class Check : Document
    {
        protected string _payer;
        private string _recipient;
        protected float _price;

        public Check()
        {
            _payer = "";
            _recipient = "";
            _price = 0;
        }

        public Check(string payer, string recipient, float price)
        {
            _payer = payer; 
            _recipient = recipient;
            if (price >= 0) _price = price;
            else _price = 0;
        }

        public string Payer
        {
            get { return _payer; }  
            set 
            { 
                if (value == null) return;
                _payer = value; 
            }
        }

        public string Recipient
        {
            get { return _recipient; }
            set 
            {
                if (value == null) return;
                _recipient = value; 
            }
        }
        public float Price
        {
            get { return _price; }
            set 
            {
                if (value > 0) _price = value;
                else
                {
                    Console.WriteLine("Не верное значение суммы");
                }
            }
        }

        public override void VShow()
        {
            Console.WriteLine("Чек (Overrided VShow)");
            Console.WriteLine($"Плательщик: {_payer}, получатель: {_recipient}, сумма: {_price}");
        }

        public override void exec()
        {
            Console.WriteLine("exec method in Check");
        }

        public override float GetTotalSum()
        {
            return _price;
        }
        
        public override bool Equals(Document other)
        {
            if (other == null) return false;
            Check check = other as Check;
            if (check == null) return false;
            return this.Payer.Equals(check.Payer) && this.Price == check.Price && this.Recipient.Equals(check.Recipient);
        }

        public override int GetHashCode()
        {
            return _payer.GetHashCode() * _recipient.GetHashCode() * ((int)_price + 1);
        }

        public override string ToString()
        {
            return $"Check {_payer}, {_recipient}, {_price}";
        }
    }
}
