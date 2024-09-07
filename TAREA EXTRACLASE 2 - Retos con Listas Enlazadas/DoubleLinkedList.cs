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

        public bool AddLast(int element)
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
            ValidHead();

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
            ValidHead();

            Node currentNode = this.head;

            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
            }

            int nodeValue = currentNode.value;

            if (currentNode.prev != null)
            {
                currentNode.prev.next = null;
            }
            else
            {
                currentNode = null;
            }

            this.size--;
            return nodeValue;
        }

        private void ValidHead()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("No such element.");
            }
        }

        public bool DeleteValue(int value)
        {
            ValidHead();

            if (this.head.value == value)
            {
                DeleteFirst();
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

        public void MergeSorted(DoubleLinkedList listB, SortDirection direction)
        {
            if (listB == null)
            {
                throw new InvalidOperationException("ListB can't be null.");
            }

            DoubleLinkedList listA = CopyList(this);
            Node nodeA = listA.head;
            Node nodeB = listB.head;

            if (direction == SortDirection.Asc)
            {
                SortAsc(nodeA, nodeB);
            }
            else if (direction == SortDirection.Desc)
            {
                SortDesc(nodeA, nodeB);
            }
            else
            {
                throw new ArgumentException("Invalid sorting direction provided.");
            }
        }

        private DoubleLinkedList CopyList(DoubleLinkedList listToCopy)
        {
            Node currentNode = listToCopy.head;
            DoubleLinkedList list = new DoubleLinkedList();

            for (int i = 0; i < this.size; i++)
            {
                list.AddLast(currentNode.value);
                currentNode = currentNode.next;
            }

            return list;
        }

        private void SortAsc(Node nodeA, Node nodeB)
        {
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.value <= nodeB.value)
                {
                    DeleteValue(nodeA.value);
                    this.AddLast(nodeA.value);
                    nodeA = nodeA.next;
                }
                else
                {
                    this.AddLast(nodeB.value);
                    nodeB = nodeB.next;
                }
            }

            // Añadir nodos restantes
            while (nodeA != null)
            {
                DeleteValue(nodeA.value);
                this.AddLast(nodeA.value);
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                this.AddLast(nodeB.value);
                nodeB = nodeB.next;
            }
        }

        private void SortDesc(Node nodeA, Node nodeB)
        {
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.value <= nodeB.value)
                {
                    DeleteValue(nodeA.value);
                    this.AddFirst(nodeA.value);
                    nodeA = nodeA.next;
                }
                else
                {
                    this.AddFirst(nodeB.value);
                    nodeB = nodeB.next;
                }
            }

            // Añadir nodos restantes
            while (nodeA != null)
            {
                DeleteValue(nodeA.value);
                this.AddFirst(nodeA.value);
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                this.AddFirst(nodeB.value);
                nodeB = nodeB.next;
            }
        }

    }

}
