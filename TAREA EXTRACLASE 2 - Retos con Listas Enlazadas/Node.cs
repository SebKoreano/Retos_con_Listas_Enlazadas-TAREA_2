﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    public class Node
    {
        public int value;
        public Node next;
        public Node prev;

        public Node(int value)
        {
            this.value = value;
            this.next = null;
            this.prev = null;
        }
    }
}
