using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    public interface ILista
    {
        bool AddLast(int element);
        bool AddFirst(int element);
        void InsertInOrder(int element);
        int DeleteFirst();
        int DeleteLast();
        bool DeleteValue(int value);
        int GetMiddle();
        void MergeSorted(DoubleLinkedList listB, SortDirection direction);
        void InvertList();
    }
}
