using System;
using System.Collections;
using System.Collections.Generic;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    public enum SortDirection { Asc, Desc }

    public class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList lista = new DoubleLinkedList();

            lista.AddLast(1);
            //lista.AddLast(2);
            lista.AddLast(3);
            lista.AddLast(4);


            DoubleLinkedList lista2 = new DoubleLinkedList();

            lista2.AddLast(1);
            //lista2.AddLast(4);
            lista2.AddLast(2);
            //lista2.AddLast(6);

            

            lista2.MergeSorted(lista, SortDirection.Asc);

            lista2.InsertInOrder(10);

            //Invert(lista2);

            PrintList(lista2);
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Middle: {lista2.GetMiddle()}");
            Console.WriteLine($"Size: {lista2.size}");
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

        public static DoubleLinkedList Invert(DoubleLinkedList lista)
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