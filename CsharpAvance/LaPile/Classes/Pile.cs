using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPile.Classes
{
    internal class Pile<T>
    {
        List<T> items = new List<T> ();

        public void Push (T item)
        {
            Console.WriteLine($"Add : {item}");
            items.Add(item);
        }

        public void Pop ()
        {
            Console.WriteLine($"Remove : {items[items.Count - 1]}");
            items.RemoveAt(items.Count - 1);
        }

        public object Get (int index)
        {
            T item = items[index];
            items.RemoveAt(index);
            return item;
        }

        public override string ToString()
        {
            return $"Pile : {base.ToString()}";
        }
    }
}
