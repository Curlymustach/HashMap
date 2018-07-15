using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    public class MyList<T> : IEnumerable<T>
    {
        public Node head;


        public T this[int index]
        {
            get
            {
                Node temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }
                return temp.Value;
            }
        }


        public class Node
        {
            public T Value;
            public Node Next;

            //constructor
            public Node(T value) : this(value, null) { }
            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }
        }

        //Add
        public void AddLast(T value)
        {
            Node temp = head;
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                Node node = new Node(value);
                temp.Next = node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
