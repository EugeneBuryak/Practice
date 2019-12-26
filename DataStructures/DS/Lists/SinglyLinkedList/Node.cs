namespace DS.Lists.SinglyLinkedList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value, Node<T> next)
        {
            Next = next;
            Value = value;
        }
    }
}