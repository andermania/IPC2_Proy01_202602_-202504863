using System;
using System.Collections.Generic;

namespace ChapinWarriorsSA
{
    public class DynamicList<T>
    {
        private Node<T> first = null!;
        private Node<T> last = null!;
        public int counter;

        public void Add(T dato)
        {
            Node<T> nuevo = new Node<T>(dato);

            if (first == null)
            {
                first = nuevo;
                last = nuevo;
            }
            else
            {
                last.next = nuevo;
                last = nuevo;
            }

            counter++;
        }

        public T GetElement(int posicion)
        {
            if (posicion < 1 || posicion > counter)
            {
                throw new IndexOutOfRangeException("Posicion fuera de rango: " + posicion + " (la lista tiene " + counter + " elementos).");
            }

            Node<T> current = first;
            for (int i = 1; i < posicion; i++)
            {
                current = current.next!;
            }

            return current.GetData();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = first;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
    }
}
