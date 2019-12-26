using System.Drawing;
using System;
namespace DS.Lists.SinglyLinkedList
{
    public class SinglyLinkedList<T> where T : IEquatable<T>
    {
        private Node<T> _tail;
        private Node<T> _head;
        public int Count { get; private set; }


        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                var pointer = _head;
                for(var i = 0; i < index; i++)
                {
                    pointer = pointer.Next;
                }

                return pointer.Value;
            }
        }

        public SinglyLinkedList()
        {
            Clear();
        }

        public void Clear()
        {
            Count = 0;
            _tail = _head = null;
        }

        public void Add(T value)
        {
            if (IsEmpty())
            {
                _tail = _head = new Node<T>(value, null);
            }
            else
            {
                var node = new Node<T>(value, null);
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            if (IsEmpty())
            {
                _tail = _head = new Node<T>(value, null);
            }
            else
            {
                var node = new Node<T>(value, _head);
                _head = node;
            }

            Count++;
        }

        public void Remove()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            var pointer = _head;
            var prev = pointer;

            while (pointer.Next != null)
            {
                prev = pointer;
                pointer = pointer.Next;
            }

            prev.Next = null;
            _tail = prev;

            Count--;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            _head = _head.Next;
            Count--;
        }

        public void Remove(T value)
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            if (_head.Value.Equals(value))
            {
                RemoveFirst();
            }
            else
            {
                var pointer = _head;
                var prev = pointer;

                while (pointer.Next != null)
                {
                    if (pointer.Value.Equals(value))
                    {
                        prev = pointer.Next;
                        Count--;
                        return;
                    }

                    prev = pointer;
                    pointer = pointer.Next;
                }

                if(pointer.Value.Equals(value))
                {
                    prev.Next = null;
                    _tail = prev;
                    Count--;
                }
            }
        }

        public int? IndexOf(T value)
        {
            var pointer = _head;

            for (var i = 0; i < Count; i++)
            {
                if (pointer.Value.Equals(value))
                {
                    return i;
                }

                pointer = pointer.Next;
            }

            return null;
        }

        public bool Contains(T value)
        {
            var pointer = _head;

            for (var i = 0; i < Count; i++)
            {
                if (pointer.Value.Equals(value))
                {
                    return true;
                }

                pointer = pointer.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            var pointer = _head;
            var array = new T[Count];

            for (var i = 0; i < Count; i++)
            {
                array[i] = pointer.Value;
                pointer = pointer.Next;
            }

            return array;
        }

        public T PeekFirst()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            return _head.Value;
        }

        public T PeekLast()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            return _tail.Value;
        }

        private bool IsEmpty()
        {
            return Count == 0;
        }

    }
}