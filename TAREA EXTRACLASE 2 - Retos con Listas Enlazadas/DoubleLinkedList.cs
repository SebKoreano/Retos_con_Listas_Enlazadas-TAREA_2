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
        public Node? head;
        public int size;
        private Node? middle;

        public DoubleLinkedList()
        {
            this.head = null;
            this.middle = null;
            this.size = 0;
        }

        private void AddHead(Node newNode)
        {
            middle = newNode;
            this.head = newNode;
        }

        private void ModMiddle()
        {
            if (size % 2 == 0)
            {
                middle = middle.next;
            }
        }

        public bool AddLast(int element)
        {
            Node newNode = new Node(element);
            if (this.head == null)
            {
                AddHead(newNode);
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
            ModMiddle();
            return true;
        }

        public bool AddFirst(int element)
        {
            Node newNode = new Node(element);

            if (this.head == null)
            {
                AddHead(newNode);
            }
            else
            {
                // Ajustar los punteros para insertar el nuevo nodo al principio
                newNode.next = this.head;  
                this.head.prev = newNode;   
                this.head = newNode;       
            }

            this.size++;
            ModMiddle();
            return true;
        }


        public void InsertInOrder(int element)
        {
            Node newNode = new Node(element);
            if (this.head == null)
            {
                AddHead(newNode);
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
            ModMiddle();
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
            if (middle  == null)
            {
                throw new InvalidOperationException("No such element.");
            }
            return middle.value;
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

        public void MergeSorted(DoubleLinkedList listB, SortDirection direction)
        {
            if (listB == null)
            {
                throw new InvalidOperationException("ListB can't be null.");
            }

            DoubleLinkedList listA = CopyList(this);
            Node nodeA = listA.head;
            Node nodeB = listB.head;

            if (direction != SortDirection.Asc && direction != SortDirection.Desc)
            {
                throw new ArgumentException("Invalid sorting direction provided.");
            }

            Sort(nodeA, nodeB, direction);
        }

        private void Sort(Node nodeA, Node nodeB, SortDirection direction)
        {
            while (nodeA != null && nodeB != null)
            {
                if (nodeA.value <= nodeB.value)
                {
                    DeleteValue(nodeA.value);
                    AscOrDesc(direction, nodeA);
                    nodeA = nodeA.next;
                }
                else
                {
                    AscOrDesc(direction, nodeB);
                    nodeB = nodeB.next;
                }
            }

            // Añadir nodos restantes
            while (nodeA != null)
            {
                DeleteValue(nodeA.value);
                AscOrDesc(direction, nodeA);
                nodeA = nodeA.next;
            }

            while (nodeB != null)
            {
                AscOrDesc(direction, nodeB);
                nodeB = nodeB.next;
            }
        }

        private void AscOrDesc(SortDirection direction, Node node)
        {
            if (direction == SortDirection.Asc)
            {
                this.AddLast(node.value);
            }
            else
            {
                this.AddFirst(node.value);
            }
        }

        //Invierte los punteros para invertir el orden la lista
        public void InvertList()
        {
            Node currentNode = this.head;
            Node temp = null;

            while (currentNode != null)
            {
                temp = currentNode.prev;
                currentNode.prev = currentNode.next;
                currentNode.next = temp;
                currentNode = currentNode.prev;
            }

            if (temp != null)
            {
                this.head = temp.prev;
            }

        }

    }

}
