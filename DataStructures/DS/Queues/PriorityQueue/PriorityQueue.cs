using System.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using DS.Trees.Heap;

namespace DS.Queue.PriorityQueues
{
    public class PriorityQueue<T> where T : IComparable<T>, IEquatable<T>
    {
        private class Node : IComparable<Node>, IEquatable<Node>
        {
            public T Value { get; set; }
            public int Priority { get; set; }

            public int CompareTo([AllowNull] Node other)
            {
                return Priority.CompareTo(other.Priority);
            }

            public bool Equals([AllowNull] Node other)
            {
                return Value.Equals(other.Value);
            }
        }

        private BinaryHeap<Node> _heap;
        private int priorityCounter = 0;
        public int Count => _heap.Count;

        public PriorityQueue()
        {
            _heap = new BinaryHeap<Node>();
        }

        public (T value, int priority) Peek()
        {
            var node = _heap.Peek();
            return (node.Value, node.Priority);
        }

        public (T value, int priority) Dequeue()
        {
            var node = _heap.Poll();
            return (node.Value, node.Priority);
        }

        public void Enqueue(T value, int? priority = null)
        {
            if (!priority.HasValue)
                priority = priorityCounter++;
            else
                priorityCounter = priority.Value;

            _heap.Add(new Node() { Value = value, Priority = priorityCounter });
        }

        public bool Contains(T value)
        {
            return _heap.Contains(new Node() { Value = value });
        }

        public (T value, int priority)[] ToArray()
        {
            return _heap.ToArray().Select(node => (node.Value, node.Priority)).ToArray();
        }
    }
}