using System;
using System.Collections.Generic;

namespace DS.Stack
{
    public class Stack<T>
    {
        private List<T> _list = new List<T>();
        public int Count => _list.Count;

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Push(T value)
        {
            _list.Add(value);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new NullReferenceException("Stack is empty");

            var item = _list[Count - 1];
            _list.RemoveAt(Count - 1);

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new NullReferenceException("Stack is empty");

            return _list[Count - 1];
        }
    }
}