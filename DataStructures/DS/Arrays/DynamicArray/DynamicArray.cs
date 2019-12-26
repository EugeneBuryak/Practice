using System;
using System.Collections;
using System.Collections.Generic;

namespace DS.Arrays.DynamicArray
{
    public class DynamicArray<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private T[] _items;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public DynamicArray(int capacity = 0)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();

            Count = 0;
            Capacity = capacity;
            _items = new T[Capacity];
        }

        public void RemoveAt(int index)
        {
            if (Capacity - 1 <= 0)
                return;

            if (index < 0 || index >= Capacity)
                throw new IndexOutOfRangeException();

            var newCapacity = Capacity - 1;
            var newArray = new T[newCapacity];
            for (var i = 0; i < index; i++)
            {
                newArray[i] = _items[i];
            }
            for (var i = index + 1; i < Capacity; i++)
            {
                newArray[i - 1] = _items[i];
            }

            Count--;
            Capacity = newCapacity;
            _items = newArray;
        }

        public void Remove(T value)
        {
            var index = IndexOf(value);

            if (index.HasValue)
                RemoveAt(index.Value);
        }

        public void Remove()
        {
            if (Count > 0)
            {
                _items[Count - 1] = default(T);
                Count--;
            }
        }

        public void Add(T value)
        {
            if (Count + 1 > Capacity)
            {
                DoubleInSize();
            }

            _items[Count] = value;
            Count++;
        }

        public int? IndexOf(T value)
        {
            for (var i = 0; i < Capacity; i++)
            {
                if (_items[i].Equals(value))
                    return i;
            }

            return null;
        }

        public bool Contains(T value)
        {
            if (IndexOf(value) != null)
                return true;
            return false;
        }

        public void ClearItems()
        {
            for (var i = 0; i < Capacity; i++)
            {
                _items[i] = default(T);
            }
        }

        private void DoubleInSize()
        {
            var newCapacity = Capacity == 0
                ? 1
                : Capacity * 2;

            var newArray = new T[newCapacity];
            for (var i = 0; i < Capacity; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
            Capacity = newCapacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
