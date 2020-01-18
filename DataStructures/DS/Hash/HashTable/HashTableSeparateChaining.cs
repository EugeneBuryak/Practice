using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DS.Hash.HashTable
{
    public class HashTableSeparateChaining<T> : IEnumerable<T> where T : IEquatable<T>
    {
        private IList<T>[] _table;
        private int _capacity;
        private double _growthFactor;
        private int _treashold;
        private int _spaceTaken;

        public int Count { get; private set; }

        public HashTableSeparateChaining(int capacity = 5, double growthFactor = 0.5)
        {
            if (capacity < 5)
                throw new ArgumentException("Invalid capacity value.");
            if (growthFactor <= 0 || growthFactor > 1 || Double.IsNaN(growthFactor))
                throw new ArgumentException("Invalid growth factor value.");

            _capacity = capacity;
            _growthFactor = growthFactor;
            _treashold = (int)(_capacity * _growthFactor);
            _table = new List<T>[_capacity];
        }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentException("Value should not be null.");

            if (_spaceTaken + 1 == _treashold)
                Resize();

            var (hash, list) = Get(value);

            if (list == null)
            {
                list = new List<T>();
                _table[hash] = list;
                _spaceTaken++;
            }

            list.Add(value);
            Count++;
        }

        public bool Remove(T value)
        {
            if (value == null)
                throw new ArgumentException("Value should not be null.");

            var (_, list) = Get(value);

            if (list == null)
                return false;

            var removed = list.Remove(value);
            if (removed)
                Count--;
            return removed;
        }

        public int? GetKey(T value)
        {
            if (value == null)
                throw new ArgumentException("Value should not be null.");

            var (hash, list) = Get(value);

            if (list == null)
                return null;
            else
            {
                var item = list.FirstOrDefault(i => i.Equals(value));
                return item == null ? (int?)null : hash;
            }
        }

        public IList<T> GetItems(int index)
        {
            if (index < 0 || index >= _capacity)
                throw new IndexOutOfRangeException();

            return _table[index];
        }

        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentException("Value should not be null.");

            var (hash, list) = Get(value);

            return list == null ? false
                 : list.FirstOrDefault(i => i.Equals(value)) == null ? false
                    : true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var list in _table)
            {
                if (list != null)
                    foreach (var item in list)
                    {
                        yield return item;
                    }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void Resize()
        {
            _capacity *= 2;
            _treashold = (int)(_capacity * _growthFactor);
            _spaceTaken = 0;
            var _tmp = new List<T>[_capacity];

            foreach (var item in this)
            {
                var hash = item.GetHashCode();
                var normalizedHash = NormalizedHash(hash);
                var list = _tmp[normalizedHash];

                if (list == null)
                {
                    list = new List<T>();
                    _tmp[normalizedHash] = list;
                    _spaceTaken++;
                }

                list.Add(item);
            }

            _table = _tmp;
        }

        private (int hash, IList<T> list) Get(T value)
        {
            var hash = value.GetHashCode();
            var normalized = NormalizedHash(hash);
            return (normalized, _table[normalized]);
        }

        private int NormalizedHash(int hash)
        {
            return Math.Abs(hash) % _capacity;
        }


    }
}