using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Lib
{
    [Serializable]
    public abstract class Document : IExecutable, IEquatable<Document>, IComparable<Document>, ICloneable
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Document);
        }
        public virtual bool Equals(Document other)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public int CompareTo(Document document)
        {
            if (this.GetTotalSum() > document.GetTotalSum()) return 1;
            else if (this.GetTotalSum() < document.GetTotalSum()) return -1;
            return 0;
        }

        public abstract object Clone();
    }
}
