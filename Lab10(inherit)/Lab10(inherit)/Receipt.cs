using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_inherit_
{
    public class Receipt : Check
    {
        static string _bankName;

        public Receipt() : base()
        {
            _bankName = "";
        }

        public Receipt (string payer, string bankName, float price)
        {
            _bankName = bankName;
            _price = price;
            _payer = payer;
        }

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        public override void VShow()
        {
            Console.WriteLine("Квитанция (Overrided VShow)");
            Console.WriteLine($"Плательщик: {_payer}, название банка: {_bankName}, {_price}");
        }

        public override void exec()
        {
            Console.WriteLine("exec method in Receipt");
        }

    }
}
