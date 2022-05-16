using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public object ModifiedObject { get; }
        public override string ToString()
        {
            return CollectionName + " " + ChangeType + " " + ModifiedObject.ToString();
        }

        public CollectionHandlerEventArgs(string collectionName, string changeType, object modifiedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ModifiedObject = modifiedObject;
        }

    }
}
