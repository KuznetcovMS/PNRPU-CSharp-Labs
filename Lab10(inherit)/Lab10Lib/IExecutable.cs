using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10Lib
{
    public interface IExecutable : IComparable
    {
        void exec();
        float GetTotalSum();

    }

    public class SortBySum : IComparer<IExecutable>
    {
        public int Compare(IExecutable ob1, IExecutable ob2)
        {
                if (ob1.GetTotalSum() > ob2.GetTotalSum()) return 1;
                else if (ob1.GetTotalSum() < ob2.GetTotalSum()) return -1;
                return 0;
        }
    }
}
