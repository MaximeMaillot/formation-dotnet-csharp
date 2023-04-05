using System.Collections;

namespace LaPile.Classes
{
    internal class Pile<T> : IEnumerable
    {
        private List<T> _items = new List<T> ();
        public List<T> Items { get { return _items; } }

        public Pile (){}

        public void Push (T item)
        {
            _items.Add(item);
        }

        public void Pop ()
        {
            _items.RemoveAt(_items.Count - 1);
        }

        public T Get (int index)
        {
            T item = _items[index];
            _items.RemoveAt(index);
            return item;
        }

        public override string ToString()
        {
            return $"Pile : {base.ToString()}";
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
