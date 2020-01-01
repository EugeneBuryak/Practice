namespace DS.Lists.DoublyLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> prev, Node<T> next)
        {
            Prev = prev;
            Next = next;
            Value = value;
        }
    }
}