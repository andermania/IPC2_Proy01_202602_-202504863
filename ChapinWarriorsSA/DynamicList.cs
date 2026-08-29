using System;
using System.Collections.Generic;

namespace ChapinWarriorsSA
{
    // Lista enlazada generica con indices basados en 1 (la primera posicion es 1).
    // El nodo no es generico: almacena el dato como object y se castea (T) al leer.
    public class DynamicList<T>
    {
        private Punto first = null!;
        private Punto last = null!;
        public int counter;

        public void Add(T dato)
        {
            Punto nuevo = new Punto(dato);

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

            Punto current = first;
            for (int i = 1; i < posicion; i++)
            {
                current = current.next!;
            }

            return (T)current.GetData()!;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Punto? current = first;
            while (current != null)
            {
                yield return (T)current.data!;
                current = current.next;
            }
        }
    }
}
