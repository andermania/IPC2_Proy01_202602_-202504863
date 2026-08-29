namespace ChapinWarriorsSA
{
    internal class Nodo
    {
        public object? data;
        public Nodo? next;

        public Nodo(object? data)
        {
            this.data = data;
        }

        public object? GetData()
        {
            return data;
        }
    }
}