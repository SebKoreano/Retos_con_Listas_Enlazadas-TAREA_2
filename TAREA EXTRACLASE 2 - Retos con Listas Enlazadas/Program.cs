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