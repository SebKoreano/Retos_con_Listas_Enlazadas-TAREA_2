using System;
using System.Collections.Generic;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList lista = new DoubleLinkedList();

            lista.add(1);
            lista.add(2);
            lista.add(3);
            lista.add(4);

            DoubleLinkedList lista2 = new DoubleLinkedList();

            //lista2.add(3);
            //lista2.add(4);
            lista2.add(5);
            lista2.add(6);

            DoubleLinkedList mergeList = lista.MergeSorted(lista2, lista, SortDirection.Asc);

            Node currentNode = mergeList.head;

            for (int i = 0; i < mergeList.size; i++) 
            {
                Console.WriteLine(currentNode.value.ToString());
                currentNode = currentNode.next;
            }
        }
    }
}