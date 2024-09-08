using System;
using System.Collections;
using System.Collections.Generic;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList lista = new DoubleLinkedList();

            lista.AddLast(1);
            lista.AddLast(2);
            lista.AddLast(3);
            lista.AddLast(4);


            DoubleLinkedList lista2 = new DoubleLinkedList();

            lista2.AddLast(3);
            lista2.AddLast(4);
            lista2.AddLast(5);
            lista2.AddLast(6);

            //lista.MergeSorted(lista2, SortDirection.Asc);
            //Invert(lista);

            PrintList(lista2);
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Middle: {lista2.GetMiddle()}");
        }

        static void PrintList(DoubleLinkedList lista)
        {
            Node currentNode = lista.head;

            for (int i = 0; i < lista.size; i++)
            {
                Console.WriteLine(currentNode.value.ToString());
                currentNode = currentNode.next;
            }
        }

        static DoubleLinkedList Invert(DoubleLinkedList lista)
        {
            if (lista == null)
            {
                throw new InvalidOperationException("List can't be null.");
            }

            lista.InvertList();
            return lista;
        }

    }
}