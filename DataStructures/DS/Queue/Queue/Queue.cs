using System;
using System.Collections.Generic;

namespace DS.Queue.Queue
{
    public class Queue<T>
    {
        private IList<T> _list = new List<T>();

        public int Count => _list.Count;

        public void Enqueue(T value)
        {
            _list.Add(value);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new NullReferenceException("Queue is empty.");

            var value = _list[0];
            _list.RemoveAt(0);
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new NullReferenceException("Queue is empty.");

            return _list[0];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}