using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    internal class Order
    {
        private List<string> items = new List<string>();

        public int Count
        {
            get { return items.Count; }
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public bool Contains(string item)
        {
            return items.Contains(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public string this[int index]
        {
            get { return items[index]; }
        }
    }
}
