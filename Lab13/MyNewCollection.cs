using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12;

namespace Lab13
{
    public delegate void CollectionHandler(object sender, CollectionHandlerEventArgs e); 
    public class MyNewCollection<T> : BalancedTree<T> where T : IComparable<T>
    {
        private string _collectionName;
        public string CollectionName { get { return _collectionName; }  set { _collectionName = value; } }

        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyNewCollection() : base()
        {
            _collectionName = "DefaultName";
        }

        public MyNewCollection(string name) : base()
        {
            _collectionName = name;
        }

        public MyNewCollection(MyNewCollection<T> b) : base(b)
        {
            _collectionName = b.CollectionName;
        }

        public override void Add(T item)
        {
            base.Add(item);
            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(_collectionName, "Add", item));
        }
        public override bool Remove(T item)
        {
            if (base.Remove(item))
            {
                CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(_collectionName, "Successfully removed", item));
                return true;
            }

            CollectionCountChanged?.Invoke(this, new CollectionHandlerEventArgs(_collectionName, "Unsuccessfully removed", item));
            return false;
        }

        public override bool FindChangeItem(T oldItem, T newItem)
        {
            if (base.FindChangeItem(oldItem, newItem))
            {
                CollectionReferenceChanged?.Invoke(this, new CollectionHandlerEventArgs(_collectionName, $"Change {oldItem} on ", newItem));
                return true;
            }
            return false;
        }
    }
}
