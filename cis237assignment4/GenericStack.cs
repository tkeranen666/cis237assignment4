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

        public GenericNode<T> Head
        {
            get;
            set;
        }

        public bool isEmpty
        {
            get { return Head == null; }
        }

        public GenericStack()
        {
            Head = null;
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
            if (!isEmpty)
            {
                GenericNode<T> returnNode = Head;

                Head = Head.Next;
                return returnNode.Data;
            }

            return default(T);
        }
    }
}
