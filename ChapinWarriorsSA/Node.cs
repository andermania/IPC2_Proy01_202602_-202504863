namespace ChapinWarriorsSA
{
    internal class Node<T>
    {
        public T data;
        public Node<T>? next;

        public Node(T data)
        {
            this.data = data;
        }

        public T GetData()
        {
            return data;
        }
    }
}
