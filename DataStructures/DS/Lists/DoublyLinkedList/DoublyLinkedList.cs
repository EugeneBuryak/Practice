using System;
namespace DS.Lists.DoublyLinkedList
{
    public class DoublyLinkedList<T> where T : IEquatable<T>
    {
        private Node<T> _tail;
        private Node<T> _head;
        public int Count { get; private set; }
        public T this[int index] => GetNodeAt(index).Value;

        public void Add(T value)
        {
            if (IsEmpty())
            {
                _head = _tail = new Node<T>(value, null, null);
            }
            else
            {
                var node = new Node<T>(value, _tail, null);
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void AddFirst(T value)
        {
            if (IsEmpty())
            {
                _head = _tail = new Node<T>(value, null, null);
            }
            else
            {
                var node = new Node<T>(value, null, _head);
                _head.Prev = node;
                _head = node;
            }

            Count++;
        }

        public void Add(T value, int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                var nodeAtIndex = GetNodeAt(index);
                var nodeBeforeIndex = nodeAtIndex.Prev;
                var node = new Node<T>(value, nodeAtIndex.Prev, nodeAtIndex);

                nodeBeforeIndex.Next = node;
                nodeAtIndex.Prev = node;

                Count++;
            }
        }

        public void Remove()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            if (Count - 1 == 0)
            {
                _tail = _head = null;
            }
            else
            {
                var prev = _tail.Prev;
                prev.Next = null;
                _tail = prev;
            }

            Count--;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            if (Count - 1 == 0)
            {
                _tail = _head = null;
            }
            else
            {
                var next = _head.Next;
                next.Prev = null;
                _head = next;
            }

            Count--;
        }

        public void Remove(T value)
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            var pointer = _head;
            while (pointer != null)
            {
                if (pointer.Value.Equals(value))
                {
                    if (pointer.Next == null)
                    {
                        Remove();
                    }
                    else if (pointer.Prev == null)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        var prev = pointer.Prev;
                        var next = pointer.Next;
                        prev.Next = next;
                        next.Prev = prev;
                        Count--;
                    }

                    break;
                }

                pointer = pointer.Next;
            }
        }

        public void RemoveAt(int index)
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Count - 1)
            {
                Remove();
            }
            else
            {
                var pointer = _head;
                for (var i = 0; i < index; i++)
                {
                    pointer = pointer.Next;
                }

                var next = pointer.Next;
                var prev = pointer.Prev;

                next.Prev = prev;
                prev.Next = next;

                Count--;
            }
        }

        public int? IndexOf(T value)
        {
            var pointer = _head;
            for (var i = 0; i < Count; i++)
            {
                if (pointer.Value.Equals(value))
                    return i;

                pointer = pointer.Next;
            }

            return null;
        }

        public bool Contains(T value)
        {
            return IndexOf(value).HasValue;
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            var pointer = _head;
            for (var i = 0; i < Count; i++)
            {
                arr[i] = pointer.Value;
                pointer = pointer.Next;
            }

            return arr;
        }

        public T PeekLast()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            return _tail.Value;
        }

        public T PeekFirst()
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            return _head.Value;
        }

        public void Clear()
        {
            _tail = null;
            _head = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        private Node<T> GetNodeAt(int index)
        {
            if (IsEmpty())
                throw new NullReferenceException("List is empty.");

            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            var pointer = _head;
            for (var i = 0; i < index; i++)
            {
                pointer = pointer.Next;
            }

            return pointer;
        }
    }
}