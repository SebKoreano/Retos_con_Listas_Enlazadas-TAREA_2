using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas
{
    public class DoubleLinkedList : ILista
    { 
        public Node head;
        public int size;

        public DoubleLinkedList()
        {
            this.head = null;
            this.size = 0;
        }

        public bool add(int element)
        {
            Node newNode = new Node(element);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                Node current = this.head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                newNode.prev = current;
            }
            this.size++;
            return true;
        }

        public bool AddFirst(int element)
        {
            Node newNode = new Node(element);

            if (this.head == null)
            {
                // Si la lista está vacía, el nuevo nodo es la cabeza
                this.head = newNode;
            }
            else
            {
                // Ajustar los punteros para insertar el nuevo nodo al principio
                newNode.next = this.head;  // El siguiente del nuevo nodo es la actual cabeza
                this.head.prev = newNode;   // La cabeza anterior ahora apunta al nuevo nodo como su previo
                this.head = newNode;        // El nuevo nodo se convierte en la cabeza
            }

            this.size++;  // Aumenta el tamaño de la lista
            return true;
        }


        public void InsertInOrder(int value)
        {
            throw new NotImplementedException();
        }

        public int DeleteFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("No such element.");
            }

            int headvalue = this.head.value;
            this.head = this.head.next;
            if (this.head != null)
            {
                this.head.prev = null;
            }
            this.size--;
            return headvalue;
        }

        public int DeleteLast()
        {
            throw new NotImplementedException();
        }

        public bool DeleteValue(int value)
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("No such element.");
            }
            if (this.head.value == value)
            {
                this.head = this.head.next;
                if (this.head != null)
                {
                    this.head.prev = null;
                }
                this.size--;
                return true;
            }
            Node current = this.head;
            while (current.next != null)
            {
                if (current.next.value == value)
                {
                    current.next = current.next.next;
                    if (current.next != null)
                    {
                        current.next.prev = current;
                    }
                    this.size--;
                    return true;
                }
                current = current.next;
            }
            throw new InvalidOperationException("No such element.");
        }

        public int GetMiddle()
        {
            throw new NotImplementedException();
        }

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            throw new NotImplementedException();
        }

        public DoubleLinkedList MergeSorted(DoubleLinkedList listB, SortDirection direction)
        {
            DoubleLinkedList mergedList = new DoubleLinkedList();

            Node nodeA = this.head;
            Node nodeB = listB.head;

            if (direction == SortDirection.Asc)
            {
                return SortAsc(nodeA, nodeB, mergedList);
            }
            else if (direction == SortDirection.Desc)
            {
                return SortDesc(nodeA, nodeB, mergedList);
            }
            else
            {
                throw new ArgumentException("Invalid sorting direction provided.");
            }
        }

        private DoubleLinkedList SortAsc(Node nodeA, Node nodeB, DoubleLinkedList mergedList)
        {
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.value <= nodeB.value)
                {
                    mergedList.add(nodeA.value);
                    nodeA = nodeA.next;
                }
                else
                {
                    mergedList.add(nodeB.value);
                    nodeB = nodeB.next;
                }
            }

            // Añadir nodos restantes
            while (nodeA != null)
            {
                mergedList.add(nodeA.value);
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                mergedList.add(nodeB.value);
                nodeB = nodeB.next;
            }

            return mergedList;
        }

        private DoubleLinkedList SortDesc(Node nodeA, Node nodeB, DoubleLinkedList mergedList)
        {
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.value <= nodeB.value)
                {
                    mergedList.AddFirst(nodeA.value);
                    nodeA = nodeA.next;
                }
                else
                {
                    mergedList.AddFirst(nodeB.value);
                    nodeB = nodeB.next;
                }
            }

            // Añadir nodos restantes
            while (nodeA != null)
            {
                mergedList.AddFirst(nodeA.value);
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                mergedList.AddFirst(nodeB.value);
                nodeB = nodeB.next;
            }

            return mergedList;
        }
    }

}
