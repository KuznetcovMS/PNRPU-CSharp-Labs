using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Lib
{
    [Serializable]
    public class Receipt : Check
    {

        protected string _bankName;

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

        public override bool Equals(Document other)
        {
            Receipt buf = other as Receipt;
            if (buf == null) return false;
            return _bankName.Equals(buf._bankName) && _payer.Equals(buf._payer) && _price == buf._price;
        }

        public Check BaseCheck
        {
            get { return new Check(_payer, _bankName, _price); }
        }

        public override string ToString()
        {
            return $"Receipt {_payer}, {_bankName}, {_price}";
        }

        public override object Clone()
        {
            return new Receipt(_payer, _bankName, _price);
        }
    }
}
