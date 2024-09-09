using System;
using TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas;

namespace Tests
{
    [TestClass]
    public class MixInOrder
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullListA()
        {
            DoubleLinkedList listA = null;
            DoubleLinkedList listB = new DoubleLinkedList();
            listB.AddLast(5);

            listA.MergeSorted(listB, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NullListB()
        {
            DoubleLinkedList listA = new DoubleLinkedList();
            listA.AddLast(5);
            DoubleLinkedList listB = null;

            listA.MergeSorted(listB, SortDirection.Asc);
        }

        [TestMethod]
        public void AscendingOrder()
        {
            DoubleLinkedList listA = new DoubleLinkedList();
            listA.AddLast(0);
            listA.AddLast(2);
            listA.AddLast(6);
            listA.AddLast(10);
            listA.AddLast(25);

            DoubleLinkedList listB = new DoubleLinkedList();
            listB.AddLast(3);
            listB.AddLast(7);
            listB.AddLast(11);
            listB.AddLast(40);
            listB.AddLast(50);

            listA.MergeSorted(listB, SortDirection.Asc);

            // Verificar si los elementos están en el orden correcto
            int[] expected = { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 };
            Node currentNode = listA.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }

        [TestMethod]
        public void DescendingOrder()
        {
            DoubleLinkedList listA = new DoubleLinkedList();
            listA.AddLast(10);
            listA.AddLast(15);

            DoubleLinkedList listB = new DoubleLinkedList();
            listB.AddLast(9);
            listB.AddLast(40);
            listB.AddLast(50);

            listA.MergeSorted(listB, SortDirection.Desc);

            int[] expected = { 50, 40, 15, 10, 9 };
            Node currentNode = listA.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }

        [TestMethod]
        public void DescendingOrder_EmptyListA()
        {
            DoubleLinkedList listA = new DoubleLinkedList();

            DoubleLinkedList listB = new DoubleLinkedList();
            listB.AddLast(9);
            listB.AddLast(40);
            listB.AddLast(50);

            listA.MergeSorted(listB, SortDirection.Desc);

            int[] expected = { 50, 40, 9 };
            Node currentNode = listA.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }

        [TestMethod]
        public void AscendingOrder_EmptyListB()
        {
            DoubleLinkedList listA = new DoubleLinkedList();
            listA.AddLast(10);
            listA.AddLast(15);

            DoubleLinkedList listB = new DoubleLinkedList();

            listA.MergeSorted(listB, SortDirection.Asc);

            int[] expected = { 10, 15 };
            Node currentNode = listA.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }
    }

    [TestClass]
    public class InvertList
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NullList()
        {
            DoubleLinkedList list = null;
            TAREA_EXTRACLASE_2___Retos_con_Listas_Enlazadas.Program.Invert(list);
        }

        [TestMethod]
        public void EmptyList()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.InvertList();

            Assert.AreEqual(0, list.size);
        }

        [TestMethod]
        public void NonEmptyList()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(1);
            list.AddLast(0);
            list.AddLast(30);
            list.AddLast(50);
            list.AddLast(2);

            list.InvertList();

            int[] expected = { 2, 50, 30, 0, 1 };
            Node currentNode = list.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }

        [TestMethod]
        public void OneElement()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(2);

            list.InvertList();

            int[] expected = { 2 };
            Node currentNode = list.head;
            foreach (int val in expected)
            {
                Assert.AreEqual(val, currentNode.value);
                currentNode = currentNode.next;
            }
        }
    }

    [TestClass]
    public class MiddleElement
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NullList()
        {
            DoubleLinkedList list = null;
            list.GetMiddle();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyList()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.GetMiddle();
        }

        [TestMethod]
        public void SingleElement()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(1);

            Assert.AreEqual(1, list.GetMiddle());
        }

        [TestMethod]
        public void TwoElements()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(1);
            list.InsertInOrder(2);

            Assert.AreEqual(2, list.GetMiddle());
        }

        [TestMethod]
        public void ThreeElements()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(1);
            list.AddLast(2);
            list.InsertInOrder(0);

            Assert.AreEqual(1, list.GetMiddle());
        }

        [TestMethod]
        public void FourElements()
        {
            DoubleLinkedList list = new DoubleLinkedList();
            list.AddLast(0);
            list.AddLast(1);
            list.AddLast(2);
            list.InsertInOrder(3);

            Assert.AreEqual(2, list.GetMiddle());
        }

    }
}