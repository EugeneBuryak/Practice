using System.Linq;
using System;
using System.Collections.Generic;

namespace DS.Trees.Heap
{
    public class BinaryHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        private IList<T> _list;
        public int Count => _list.Count;

        public T this[int index] => _list[index];

        public BinaryHeap()
        {
            _list = new List<T>();
        }
        public BinaryHeap(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
                _list.Add(item);

            for (var i = Math.Max(0, (Count / 2) - 1); i >= 0; i--)
                Sink(i);
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Clear()
        {
            _list = new List<T>();
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);

            return _list[0];
        }

        public T Poll()
        {
            return RemoveAt(0);
        }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException("Value cannot be null.");

            _list.Add(value);
            Float(Count - 1);
        }

        public T Remove(T value)
        {
            var index = IndexOf(value);
            if (index.HasValue)
                return RemoveAt(index.Value);

            return default(T);
        }

        public T RemoveAt(int index)
        {
            T node;
            if (IsEmpty())
            {
                throw new NullReferenceException("Heap is empty.");
            }

            if (index < 0 || index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (Count - 1 == 0)
            {
                node = _list[0];
                _list.RemoveAt(0);
            }
            else
            {
                Swap(index, _list.Count - 1);
                node = _list[Count - 1];
                _list.RemoveAt(Count - 1);

                Sink(index);
            }

            return node;
        }

        public int? IndexOf(T value)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_list[i].Equals(value))
                    return i;
            }

            return null;
        }

        public bool Contains(T value)
        {
            return IndexOf(value).HasValue;
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }

        private void Sink(int currentIndex)
        {
            while (true)
            {
                var leftIndex = GetLeftChildNodeIndex(currentIndex);
                var rightIndex = GetRightChildNodeIndex(currentIndex);
                var tmpIndex = leftIndex;

                if (rightIndex < Count - 1 && CompareNodes(rightIndex, leftIndex) < 0)
                {
                    tmpIndex = rightIndex;
                }

                if (leftIndex >= Count - 1 || CompareNodes(currentIndex, tmpIndex) <= 0)
                {
                    break;
                }

                Swap(currentIndex, tmpIndex);
                currentIndex = tmpIndex;
            }
        }

        private void Float(int currentIndex)
        {
            var parentIndex = GetParentIndex(currentIndex);

            while (parentIndex >= 0
                && currentIndex != parentIndex
                && CompareNodes(currentIndex, parentIndex) <= 0)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = GetParentIndex(parentIndex);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var first = _list[firstIndex];
            var second = _list[secondIndex];

            _list[firstIndex] = second;
            _list[secondIndex] = first;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildNodeIndex(int index)
        {
            return (index * 2) + 1;
        }

        private int GetRightChildNodeIndex(int index)
        {
            return (index * 2) + 2;
        }

        private int CompareNodes(int firstIndex, int secondIndex)
        {
            var first = _list[firstIndex];
            var second = _list[secondIndex];
            return first.CompareTo(second);
        }
    }
}