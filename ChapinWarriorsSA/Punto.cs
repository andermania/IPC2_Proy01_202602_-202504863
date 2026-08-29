namespace ChapinWarriorsSA
{
    internal class Punto
    {
        public object? data;
        public Punto? next;

        public Punto(object? data)
        {
            this.data = data;
        }

        public object? GetData()
        {
            return data;
        }
    }
}