using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tim Keranen

namespace cis237assignment4
{
    class GenericQueue<T>
    {
        public GenericNode<T> Head
        {
            get;
            set;
        }

        public GenericNode<T> Tail
        {
            get;
            set;
        }

        public GenericQueue()
        {
            Head = null;
            Tail = null;
        }

        public bool isEmpty
        {
            get { return Head == null; }
        }

        // Method for adding moving each droid to the queue
        public void Enqueue(T content)
        {
            GenericNode<T> oldLast = Tail;
            Tail = new GenericNode<T>();
            Tail.Data = content;
            Tail.Next = null;
            if (Head == null)
            {
                Head = Tail;
            }
            else oldLast.Next = Tail;
        }

        // Method for removing each droid from the queue
        public T Dequeue()
        {
            if (!isEmpty)
            {
                if (Head == null)
                {
                    Console.WriteLine("ERROR!");
                }
                GenericNode<T> returnNode = Head;
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
                return returnNode.Data;
            }
            return default(T);
        }
    }
}
