using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

        public T Find(Predicate<T> match)
        {
            Node<T>? current = first;
            while (current != null)
            {
                if (match(current.data))
                {
                    return current.data;
                }
                current = current.next;
            }
            return default!;
        }

        public bool Remove(T dato)
        {
            Node<T>? current = first;
            Node<T>? previous = null;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.data, dato))
                {
                    if (previous == null)
                    {
                        first = current.next!;
                    }
                    else
                    {
                        previous.next = current.next;
                    }

                    if (current == last)
                    {
                        last = previous!;
                    }

                    counter--;
                    return true;
                }

                previous = current;
                current = current.next;
            }

            return false;
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

        /*IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }*/
    }
}
