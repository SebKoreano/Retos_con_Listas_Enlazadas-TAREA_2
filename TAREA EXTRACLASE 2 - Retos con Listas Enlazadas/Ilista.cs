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
        void InsertInOrder(int value);

        int DeleteFirst(); //Listo

        int DeleteLast(); 

        bool DeleteValue(int value);  //Listo

        int GetMiddle();

        void MergeSorted(IList listA, IList listB, SortDirection direction); //Listo
    }
}
