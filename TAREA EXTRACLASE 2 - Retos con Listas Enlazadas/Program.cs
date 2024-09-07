using System;
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

            lista.MergeSorted(lista2, SortDirection.Desc);

            Node currentNode = lista.head;

            for (int i = 0; i < lista.size; i++) 
            {
                Console.WriteLine(currentNode.value.ToString());
                currentNode = currentNode.next;
            }
        }
    }
}