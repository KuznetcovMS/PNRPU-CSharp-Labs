using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public object ModifiedObject { get; }
        public override string ToString()
        {
            return CollectionName + " " + ChangeType + " " + ModifiedObject.ToString();
        }

        public JournalEntry(string collectionName, string changeType, object modifiedObject)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ModifiedObject = modifiedObject;
        }

    }
    public class Journal
    {
        private List<JournalEntry> _entries;

        public int Count { get { return _entries.Count; } }

        public Journal()
        {
            _entries = new List<JournalEntry>(10);
        }

        public void AddEntry(object sender, CollectionHandlerEventArgs e)
        {
            if (sender == null || e == null) return;
            _entries.Add(new JournalEntry(e.CollectionName, e.ChangeType, e.ModifiedObject));
        }

        public void Print()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("Журнал пуст");
                return;
            }
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }
}
