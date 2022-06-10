using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    [Serializable]
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

        public virtual void Add(T item)
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
                    if (root.BalanceFactor > 1)
                    {
                        if (root.Right.BalanceFactor < 0) TurnRight(ref root.Right);
                        TurnLeft(ref root);
                    }
                }
                else
                {
                    insert(ref root.Left, item);
                    if (root.BalanceFactor < -1)
                    {
                        if (root.BalanceFactor > 0) TurnLeft(ref root.Left);
                        TurnRight(ref root);
                    }
                }
                SetBalanceFactor(root);
            }
        }

        private void Rebalance(ref Node<T> root)
        {
            if (root.BalanceFactor > 1)
            {
                if (root.Right.BalanceFactor < 0) TurnRight(ref root.Right);
                TurnLeft(ref root);
            }

            if (root.BalanceFactor < -1)
            {
                if (root.BalanceFactor > 0) TurnLeft(ref root.Left);
                TurnRight(ref root);
            }
            SetBalanceFactor(root);

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

            locRoot.BalanceFactor = (sbyte)(hRight - hLeft);
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

        public virtual bool FindChangeItem(T oldItem, T newItem)
        {
            if (Remove(oldItem))
            {
                Add(newItem);
                return true;
            }
            return false;
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

        public virtual bool Remove(T item)
        {
            if (item == null) return false;

            if (RecRemove(ref _root, item))
            {
                _count--;
                return true;
            }
            return false;
        }

        private bool RecRemove(ref Node<T> root, T item)
        {
            if (root == null) return false;
            if (root.Data.Equals(item))
            {
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                    return true;
                }
                else if(root.Left != null && root.Right == null)
                {
                    root = root.Left;
                }
                else if (root.Right != null && root.Left == null)
                {
                    root = root.Right;
                }
                else if (root.Left != null && root.Right != null)
                {
                    Node<T> pNode = root;
                    Node<T> cNode = root.Right;
                    while(cNode.Left != null)
                    {
                        pNode = cNode;
                        cNode = cNode.Left;
                    }

                    if (cNode.Right == null)
                    {
                        cNode.Left = root.Left;
                        if (root.Right != cNode) cNode.Right = root.Right;
                        pNode.Left = null;
                        root = cNode;
                    }
                    else
                    {
                        if (root.Right != cNode)
                        {
                            pNode.Left = cNode.Right;
                            cNode.Right = root.Right;
                        }
                        cNode.Left = root.Left;
                        root = cNode;
                    }
                }
                SetBalanceFactor(root);
                Rebalance(ref root);
                return true;
            }

            else
            {
                switch (item.CompareTo(root.Data))
                {
                    case -1:
                        return RecRemove(ref root.Left, item);

                    case 0:
                        return RecRemove(ref root.Right, item);

                    case 1:
                        return RecRemove(ref root.Right, item);
                }
            }
            return false;
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
            private Node<T> _end;
            private Stack<Node<T>> nodeStack;
            private Stack<Node<T>> beginStateStack;
            public T Current
            {
                get { return _cur.Data; }
            }

            public T Max
            {
                get
                {
                    if (_end.Right != null) SetHighiestNodeInSubtree(ref _end);
                    return _end.Data;
                }
            }

            public TreeEnumerator(BalancedTree<T> col)
            {
                _root = col._root;
                _begin = col._root;
                _cur = col._root;
                _end = col._root;
                nodeStack = new Stack<Node<T>>(50);

                if (_root != null)
                {
                    nodeStack.Push(_root);
                    SetLowestNodeInSubtree(ref _begin);
                    _cur = _begin;
                    SetHighiestNodeInSubtree(ref _end);
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

            private void SetHighiestNodeInSubtree(ref Node<T> node)
            {
                while (node.Right != null)
                {
                    node = node.Right;
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
