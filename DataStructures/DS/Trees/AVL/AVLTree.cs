using System;
using System.Collections.Generic;

namespace DS.Trees.AVL
{
    public class AVLTree<T> where T : IComparable<T>, IEquatable<T>
    {
        private class Node : IComparable<Node>, IEquatable<Node>
        {
            public T Value { get; set; }
            public short Height { get; set; }
            public short BalanceFactor { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parrent { get; set; }

            public int CompareTo(Node other)
            {
                return Value.CompareTo(other.Value);
            }

            public bool Equals(Node other)
            {
                return Value.Equals(other.Value);
            }
        }

        private Node Root { get; set; }
        public int Count { get; set; }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            var node = new Node { Value = value };
            Count++;

            if (Root == null)
            {
                Root = node;
                return;
            }

            var pointer = Root;

            while (true)
            {
                var cmp = node.CompareTo(pointer);
                if (cmp < 0)
                {
                    if (pointer.Left == null)
                    {
                        node.Parrent = pointer;
                        pointer.Left = node;
                        break;
                    }

                    pointer = pointer.Left;
                }
                else if (cmp > 0)
                {
                    if (pointer.Right == null)
                    {
                        node.Parrent = pointer;
                        pointer.Right = node;
                        break;
                    }

                    pointer = pointer.Right;
                }
                else
                {
                    return;
                }
            }

            var imbalancePointer = UpdateHeight(pointer);

            if (imbalancePointer != null)
            {
                Balance(imbalancePointer);
            }
        }

        public void Remove(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            if (Root == null)
                return;

            var pointer = Root;

            while (pointer != null)
            {
                var cmp = value.CompareTo(pointer.Value);

                if (cmp < 0)
                {
                    pointer = pointer.Left;
                }
                else if (cmp > 0)
                {
                    pointer = pointer.Right;
                }
                else
                {
                    pointer = Remove(pointer);
                    if (pointer != null)
                    {
                        pointer = UpdateHeight(pointer);
                        if (pointer != null)
                        {
                            Balance(pointer);
                        }
                    }

                    Count--;
                    return;
                }
            }
        }

        public T[] ToArray()
        {
            var arr = new T[Count];
            if (Root == null)
            {
                return arr;
            }

            var i = 0;
            var queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                arr[i] = node.Value;
                i++;

                if (node.Left != null)
                    queue.Enqueue(node.Left);
                if (node.Right != null)
                    queue.Enqueue(node.Right);
            }

            return arr;
        }

        private Node Remove(Node node)
        {
            var parrent = node.Parrent;
            if (parrent == null && node.Left == null && node.Right == null)
            {
                Root = null;
            }
            else if (node.Left == null && node.Right == null)
            {
                if (parrent.Left != null && parrent.Left.Equals(node))
                    parrent.Left = null;
                else
                    parrent.Right = null;
            }
            else if (node.Left != null && node.Right != null)
            {
                var pointer = node.Left;
                while (pointer.Right != null)
                {
                    pointer = pointer.Right;
                }

                var tmp = node.Value;
                node.Value = pointer.Value;
                pointer.Value = tmp;

                Remove(pointer);
            }
            else if (node.Left != null)
            {
                node.Left.Parrent = parrent;
                parrent.Left = node.Left;
            }
            else
            {
                node.Right.Parrent = parrent;
                parrent.Right = node.Right;
            }

            return parrent;
        }

        private Node UpdateHeight(Node node)
        {
            Node imbalancePointer = null;

            while (node != null)
            {
                var leftSubTreeHeight = node.Left?.Height ?? -1;
                var rightSubTreeHeight = node.Right?.Height ?? -1;

                node.Height = (short)(1 + Math.Max(leftSubTreeHeight, rightSubTreeHeight));
                node.BalanceFactor = (short)Math.Abs(rightSubTreeHeight - leftSubTreeHeight);

                if (node.BalanceFactor >= 2)
                    imbalancePointer = imbalancePointer ?? node;

                node = node.Parrent;
            }

            return imbalancePointer;
        }

        private void Balance(Node node)
        {
            if (node.Left != null && node.Left.Left != null)
                RightRightRotation(node);
            else if (node.Right != null && node.Right.Right != null)
                LeftLeftRotation(node);
            else if (node.Left != null && node.Left.Right != null)
                LeftRightRotation(node);
            else
                RightLeftRotaion(node);
        }

        private void LeftLeftRotation(Node node)
        {
            var pivot = node.Right;
            var parrent = node.Parrent;
            var pivotOldLeft = pivot.Left;

            pivot.Left = node;
            pivot.Parrent = parrent;

            node.Parrent = pivot;
            if (pivotOldLeft != null)
            {
                pivotOldLeft.Parrent = node;
                node.Right = pivotOldLeft;
            }
            else
                node.Right = null;

            if (parrent != null)
                parrent.Right = pivot;
            else
                Root = pivot;

            UpdateHeight(node);
        }

        private void RightRightRotation(Node node)
        {
            var pivot = node.Left;
            var parrent = node.Parrent;
            var pivotOldRight = pivot.Right;

            pivot.Right = node;
            pivot.Parrent = parrent;

            node.Parrent = pivot;
            if (pivotOldRight != null)
            {
                pivotOldRight.Parrent = node;
                node.Left = pivotOldRight;
            }
            else
                node.Left = null;

            if (parrent != null)
                parrent.Left = pivot;
            else
                Root = pivot;

            UpdateHeight(node);
        }

        private void RightLeftRotaion(Node node)
        {
            var pivot = node.Right;
            node.Right = pivot.Left;
            node.Right.Parrent = node;
            node.Right.Right = pivot;
            pivot.Parrent = node.Right;
            pivot.Left = null;

            UpdateHeight(pivot);
            LeftLeftRotation(node);
        }

        private void LeftRightRotation(Node node)
        {
            var pivot = node.Left;
            node.Left = pivot.Right;
            node.Left.Parrent = node;
            node.Left.Left = pivot;
            pivot.Parrent = node.Left;
            pivot.Right = null;

            UpdateHeight(pivot);
            RightRightRotation(node);
        }
    }
}