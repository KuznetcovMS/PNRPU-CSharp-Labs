using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class BalancedTree<T> : ICollection<T>, ICloneable where T : IComparable<T>
    {
        protected Node<T> _root;
        protected int _count;

        public int Count 
        { 
            get { return _count; } 
        }

        public bool IsReadOnly 
        {
            get { return false; } 
        }

        public BalancedTree()
        {
            _root = null;
            _count = 0;
        }

        public BalancedTree(BalancedTree<T> c)
        {
            _root = c.GetTreeCopy();
            _count = c.Count;
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (_root == null)
            {
                _root = new Node<T>(item);
                _count++;
            }
            else
            {
                insert(ref _root, item);
                _count++;
            }
        }
       
        private void insert(ref Node<T> root, T item)
        {
            if (root == null) root = new Node<T>(item);

            else
            {
                if (item.CompareTo(root.Data) >= 0)
                {
                    insert(ref root.Right, item);
                    root.BalanceFactor++;
                    if (root.BalanceFactor > 1)
                    {
                        if (root.Right.BalanceFactor < 0) TurnRight(ref root.Right);
                        TurnLeft(ref root);
                    }
                }
                else
                {
                    insert(ref root.Left, item);
                    root.BalanceFactor--;
                    if (root.BalanceFactor < -1)
                    {
                        if (root.BalanceFactor > 0) TurnLeft(ref root.Left);
                        TurnRight(ref root);
                    }
                }
            }
        }

        private void TurnLeft(ref Node<T> locRoot)
        {
            Node<T> rightSubtree, rightSubtreeLeftSubtree;
            rightSubtree = locRoot.Right;
            rightSubtreeLeftSubtree = rightSubtree.Left;

            rightSubtree.Left = locRoot;
            locRoot.Right = rightSubtreeLeftSubtree;
            locRoot = rightSubtree;

            SetBalanceFactor(locRoot.Left);
            SetBalanceFactor(locRoot);
        }

        private void TurnRight(ref Node<T> locRoot)
        {
            Node<T> leftSubtree, leftSubtreeRightSubtree;
            leftSubtree = locRoot.Left;
            leftSubtreeRightSubtree = leftSubtree.Right;

            leftSubtree.Right = locRoot;
            locRoot.Left = leftSubtreeRightSubtree;
            locRoot = leftSubtree;

            SetBalanceFactor(locRoot.Right);
            SetBalanceFactor(locRoot);
        }

        private sbyte GetTreeHeight(Node<T> locRoot)
        {
            if (locRoot == null) return 0;
            sbyte hLeft = GetTreeHeight(locRoot.Left);
            sbyte hRight = GetTreeHeight(locRoot.Right);

            if (hLeft > hRight) return (sbyte)(hLeft + 1);
            else return (sbyte)(hRight + 1);
        }

        private void SetBalanceFactor(Node<T> locRoot)
        {
            if (locRoot != null) 
                locRoot.BalanceFactor = (sbyte)(GetTreeHeight(locRoot.Right) - GetTreeHeight(locRoot.Left));
        }
        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        private void RecursiveСopying(Node<T> oldTreePos, Node<T> newTreePos)
        {
            if (oldTreePos.Data is ICloneable)
            {
                newTreePos.Data = (T)((ICloneable)oldTreePos.Data).Clone();
            }
            else
            {
                newTreePos.Data = oldTreePos.Data;
            }
            
            if (oldTreePos.Left != null)
            {
                newTreePos.Left = new Node<T>();
                RecursiveСopying(oldTreePos.Left, newTreePos.Left);
            }

            if (oldTreePos.Right != null)
            {
                newTreePos.Right = new Node<T>();
                RecursiveСopying(oldTreePos.Right, newTreePos.Right);
            }
        }
        private Node<T> GetTreeCopy()
        {
            if (_root == null) return null;
            Node<T> newTree = new Node<T>();
            Node<T> oldTree = _root;

            RecursiveСopying(oldTree, newTree);
            return newTree;
        }
        public bool Contains(T item)
        {   
            return FindItemNode(item) != null; ;
        }

        private Node<T> FindItemNode(T item)
        {
            bool foundElem = false;
            Node<T> curPos = _root;
            while (curPos != null && !foundElem)
            {
                switch (item.CompareTo(curPos.Data))
                {
                    case -1:
                        curPos = curPos.Left;
                        break;

                    case 0:
                        if (curPos.Data.Equals(item)) foundElem = true;
                        else curPos = curPos.Right;
                        break;

                    case 1:
                        curPos = curPos.Right;
                        break;
                }
            }
            return curPos;
        }

        public T FindGetItem(T item)
        {
            return FindItemNode(item).Data;
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < array.Length; i++)
            {
                if (array[i] != null) Add(array[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator<T>(this);
        }

        public bool Remove(T item)
        {
            if (_root == null) return false;
       
            bool isRemoved = false;
            bool foundElem = false;

            Node<T> prevPos = _root;
            Node<T> curPos = _root;

            while (curPos != null && !foundElem)
            {
                switch (item.CompareTo(curPos.Data))
                {
                    case -1:
                        prevPos = curPos;
                        curPos = curPos.Left;
                        break;

                    case 0:
                        if (curPos.Data.Equals(item)) foundElem = true;
                        else
                        {
                            prevPos = curPos;
                            curPos = curPos.Right;
                        }
                        break;

                    case 1:
                        prevPos = curPos;
                        curPos = curPos.Right;
                        break;
                }
            }
            //if (foundElem)
            //{
                
            //}
            return isRemoved;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            return new BalancedTree<T>(this);
        }

        public BalancedTree<T> MClone()
        {
            return MemberwiseClone() as BalancedTree<T>;
        }

        public class TreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private Node<T> _root;
            private Node<T> _begin;
            private Node<T> _cur;
            private Stack<Node<T>> nodeStack;
            private Stack<Node<T>> beginStateStack;
            public T Current
            {
                get { return _cur.Data; }
            }

            public TreeEnumerator(BalancedTree<T> col)
            {
                _root = col._root;
                _begin = col._root;
                _cur = col._root;
                nodeStack = new Stack<Node<T>>(50);

                if (_root != null)
                {
                    nodeStack.Push(_root);
                    SetLowestNodeInSubtree(ref _begin);
                    _cur = _begin;
                }
      
                beginStateStack = new Stack<Node<T>>(nodeStack);          
            }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose()
            {
                beginStateStack.Clear();
                nodeStack.Clear();
            }


            public bool MoveNext()
            {
                if (_root == null) return false;
                if (nodeStack.Count == 0) return false;
                _cur = nodeStack.Pop();

                if (_cur.Right != null)
                {
                    Node<T> buf = _cur.Right;
                    nodeStack.Push(buf);
                    SetLowestNodeInSubtree(ref buf);
                }
                return true;
            }

            private void SetLowestNodeInSubtree(ref Node<T> node)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                    nodeStack.Push(node);
                }
            }

            public void Reset()
            {
                _cur = _begin;
                nodeStack.Clear();
                foreach(var item in beginStateStack)
                {
                    nodeStack.Push(item);
                }
            }
        }
    }
}
