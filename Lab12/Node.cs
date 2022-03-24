using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10Lib;

namespace Lab12
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;
        public sbyte BalanceFactor;

        public Node()
        {
            Data = default;
            Left = null;
            Right = null;
            BalanceFactor = 0;
        }

        public Node(T el)
        {
            Data = el;
            Left = null;
            Right = null;
            BalanceFactor = 0;
        }

        public override string ToString()
        {
            return Data + " ";
        }
    }
}
