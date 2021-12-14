using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_inherit_
{
    public abstract class Document : IExecutable
    {
        public virtual void VShow()
        {
            Console.WriteLine("Абстрактный (виртуальный) документ");
        }

        public void Show()
        {
            Console.WriteLine("Абстрактный документ");
        }

        public virtual void exec()
        {
            Console.WriteLine("exec method in Document");
        }

        public abstract float GetTotalSum();

        public int CompareTo(object obj)
        {
            Document document = (Document)obj;
            if (this.GetTotalSum() > document.GetTotalSum()) return 1;
            else if (this.GetTotalSum() < document.GetTotalSum()) return -1;
            return 0;
        }
    }
}
