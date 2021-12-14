using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_inherit_
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
            _price = price;
        }

        public string Payer
        {
            get { return _payer; }  
            set { _payer = value; }
        }

        public string Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
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

    }
}
