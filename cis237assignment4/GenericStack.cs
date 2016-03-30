using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tim Keranen

namespace cis237assignment4
{
    class GenericStack<T>
    {
        public GenericNode<T> Current
        {
            get;
            set;
        }

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

        public GenericStack()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        // Method to push each droid into its stack
        public void Push(T content)
        {
            GenericNode<T> oldFirst = Head;
            Head = new GenericNode<T>();
            Head.Data = content;
            Head.Next = oldFirst;
        }

        // Method for popping each droid off its stack into a variable
        public T Pop()
        {
            GenericNode<T> returnNode = Head;
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            return returnNode.Data;
        }
    }
}
