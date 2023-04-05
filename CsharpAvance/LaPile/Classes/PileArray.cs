using System;
using System.Collections;

namespace LaPile.Classes
{
    internal class PileArray<T> : IEnumerable
    {
        private int _index = 0;
        private T[] _itemsArray;
        public T[] ItemsArray { get { return _itemsArray; } }

        public PileArray(int baseLength = 1)
        {
            _itemsArray = new T[baseLength];
        }

        public void Push(T item)
        {
            if (_index >= _itemsArray.Length)
            {
                Array.Resize(ref _itemsArray, _itemsArray.Length + 1);
            }
            _itemsArray[_index++] = item;
        }

        public void Pop()
        {
            if ( _index <= 0)
            {
                return;
            }
            Array.Resize(ref _itemsArray, --_index);
        }

        public T Get(int index)
        {
            if (index >= _itemsArray.Length)
            {
                throw new IndexOutOfRangeException();
            }
            T tmp = _itemsArray[index];
            for (int i = index; i < _itemsArray.Length - 1; i++)
            {
                _itemsArray[i] = _itemsArray[i + 1];
            }
            Array.Resize(ref _itemsArray, --_index);
            return tmp;
        }

        public override string ToString()
        {
            return $"Pile : {base.ToString()}";
        }

        public IEnumerator GetEnumerator()
        {
            return _itemsArray.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _itemsArray.GetEnumerator();
        }

        public bool isEmpty()
        {
            return _index == 0;
        }
    }
}
