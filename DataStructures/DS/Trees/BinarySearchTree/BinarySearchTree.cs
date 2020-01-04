using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace DS.Trees.BinarySearchTree
{
    public enum Traversal
    {
        BreadthFirst,
        InOrder,
        PostOrder,
        PreOrder
    }

    public class BinarySearchTree<T> where T : IComparable<T>, IEquatable<T>
    {
        private class Node : IComparable<T>, IEquatable<T>
        {
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public int CompareTo([AllowNull] T other)
            {
                return Value.CompareTo(other);
            }

            public bool Equals([AllowNull] T other)
            {
                return Value.Equals(other);
            }
        }

        private Node Root { get; set; }
        public int Count { get; private set; }

        public void Insert(T value)
        {
            if (value == null)
                throw new NullReferenceException("Value cannot be null.");

            if (Root == null)
                Root = new Node { Value = value };
            else
            {
                Insert(Root);
            }

            Count++;

            Node Insert(Node node)
            {
                if (node == null)
                    node = new Node { Value = value };
                else
                {
                    if (value.CompareTo(node.Value) <= 0)
                        node.Left = Insert(node.Left);
                    if (value.CompareTo(node.Value) > 0)
                        node.Right = Insert(node.Right);
                }

                return node;
            }
        }

        public void Remove(T value)
        {
            if (value == null)
                throw new NullReferenceException("Value cannot be null.");

            Remove(Root);
            Count--;

            Node Remove(Node node)
            {
                if (node == null) return null;

                var comp = value.CompareTo(node.Value);

                if (comp == 0)
                {
                    if (node.Left != null && node.Right != null)
                    {
                        var tmp = node.Left;
                        while (tmp.Right != null)
                        {
                            tmp = tmp.Right;
                        }

                        node.Value = value = tmp.Value;
                        node.Left = Remove(node.Left);
                    }
                    else if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    else if (node.Right != null)
                    {
                        node = node.Right;
                    }
                    else
                    {
                        node = null;
                    }
                }
                else if (comp < 0)
                {
                    node.Left = Remove(node.Left);
                }
                else
                {
                    node.Right = Remove(node.Right);
                }

                return node;
            }
        }

        public bool Contains(T value)
        {
            if (value == null)
                throw new NullReferenceException("Value cannot be null.");

            var pointer = Root;
            while (pointer != null)
            {
                if (value.CompareTo(pointer.Value) == 0)
                    return true;
                else if (value.CompareTo(pointer.Value) < 0)
                    pointer = pointer.Left;
                else
                    pointer = pointer.Right;
            }

            return false;
        }

        public IEnumerable<T> AsEnumerable(Traversal order = Traversal.InOrder)
        {
            switch (order)
            {
                case Traversal.BreadthFirst:
                    return TraversBreadthFirst();
                case Traversal.PreOrder:
                    return TraversPreOrder();
                case Traversal.PostOrder:
                    return TraversPostOrder();
                case Traversal.InOrder:
                default:
                    return TraversInOrder();
            }
        }

        private IEnumerable<T> TraversInOrder()
        {
            var arr = new T[Count];
            int i = 0;
            Travers(Root);
            return arr;

            void Travers(Node node)
            {
                if (node == null) return;

                Travers(node.Left);
                arr[i++] = node.Value;
                Travers(node.Right);

            }
        }

        private IEnumerable<T> TraversPostOrder()
        {
            var arr = new T[Count];
            int i = 0;
            Travers(Root);
            return arr;

            void Travers(Node node)
            {
                if (node == null) return;

                Travers(node.Left);
                Travers(node.Right);
                arr[i++] = node.Value;
            }
        }

        private IEnumerable<T> TraversPreOrder()
        {
            var arr = new T[Count];
            int i = 0;
            Travers(Root);
            return arr;

            void Travers(Node node)
            {
                if (node == null) return;

                arr[i++] = node.Value;
                Travers(node.Left);
                Travers(node.Right);
            }
        }

        private IEnumerable<T> TraversBreadthFirst()
        {
            var queue = new Queue<Node>();
            var arr = new T[Count];
            int i = 0;

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                arr[i++] = node.Value;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return arr;
        }
    }
}