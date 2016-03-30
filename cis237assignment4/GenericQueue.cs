using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericQueue<T>
    {
        public GenericNode<T> Current
        {
            get;
            set;
        }

        //Node that will 'point' to the beginning of the linked list
        public GenericNode<T> Head
        {
            get;
            set;
        }

        //Node that will 'point' to the last node in the linked list
        public GenericNode<T> Tail
        {
            get;
            set;
        }

        public GenericQueue()
        {
            Head = null;
            Tail = null;
            Current = null;
        }

        //public void Add(T content)
        //{
        //    GenericNode<T> node = new GenericNode<T>();

        //    node.Data = content;

        //    //If Head is null, that means that there are no nodes in the linked list.
        //    //We are about to add the first node.
        //    if (Head == null)
        //    {
        //        Head = node;
        //        //This next line got moved below the if/else, so it is no longer needed
        //        //Tail = node;
        //    }
        //    //This is the case where there is already at least 1 node in the linked list. Maybe many.
        //    else
        //    {
        //        //Take the Tail Node, which is the last one in the list, and set it's Next property
        //        //which was null, to the new node we just created.
        //        Tail.Next = node;

        //        //This is a valid replacement for Tail = node;, but might be harder to understand.
        //        //Tail = Tail.Next;
        //        //This next line got moved below the if/else
        //        //Tail = node;
        //    }
        //    //This was duplicated in both the if and the else, so we moved it down here since it must be
        //    //done for both of them.
        //    Tail = node;
        //}


        //public T Retrive(int position)
        //{
        //    //Used as a temporary pointer to a spot within the linked list
        //    GenericNode<T> tempNode = Head;
        //    //Used to hold the node at the index indicated by the passed in position
        //    GenericNode<T> returnNode = null;
        //    //Counter to see where we are in the list
        //    int count = 0;

        //    //While our tempNode is not at the end the list
        //    while (tempNode != null)
        //    {
        //        //If the count and the position match. This means that it will be
        //        //zero based. If we wanted it to be 1 based, we would need to subtract
        //        //1 from the position.
        //        if (count == position)
        //        {
        //            //Set the returnNode var to the tempNode, which is the one we were looking for
        //            returnNode = tempNode;
        //        }
        //        //Increment the count so that we actually move through the list
        //        count++;
        //        //Set the tempNode to tempNode's next property, which will move us to the next
        //        //node in the linked list
        //        tempNode = tempNode.Next;
        //    }
        //    //We are going to use a ternary operator to do a smaller version of an if.
        //    //This could easily be written as a if / else. Essentially the part in the ()
        //    //is the test, and the part between the ? and the : is what will happen if true.
        //    //The part after the : is what will happen when false.
        //    //The default(T) part is going to determine what the default value for
        //    //type T is, and then return that. MOst of the time it will probably
        //    //be null, but in case it isn't this will handle it. Putting just null
        //    //make the IDE complain, so we have to use this.
        //    return (returnNode != null) ? returnNode.Data : default(T);
        //}

        //public bool Delete(int position)
        //{
        //    //return value for the method
        //    bool returnBool = false;

        //    //Set current to Head.
        //    Current = Head;

        //    //If the position that we want to remove is the very first node, we need to do things
        //    //different than if it is 1 thru the end.
        //    //This part is equivilent to always removing from the front. (hint hint)
        //    if (position == 0)
        //    {
        //        //Set the Head to the current.Next which will make Head point to the node
        //        //at index 1, instead of index 0.
        //        Head = Current.Next;
        //        //Set the Next Property of Current to null so that the current
        //        //(which was the old Head) does not point to any other node.
        //        //This line is probably not 'required', but it does illustrate how
        //        //to clean up a node so it no longer points to anything.
        //        Current.Next = null;
        //        //Set the current (which was the old Head) to null. Now that node no longer
        //        //exists, and can be garbage collected.
        //        Current = null;
        //        //Check to see if the Head is null, if so, the Tail must become null as well
        //        //because it means we just deleted the last node in the list.
        //        if (Head == null)
        //        {
        //            Tail = null;
        //        }
        //        //Set the return bool to true since the remove was successfull
        //        returnBool = true;
        //    }
        //    else
        //    {
        //        //Set a tempnode to the first position in the linkedlist.
        //        GenericNode<T> tempNode = Head;
        //        //Declare a preivous temp that will get a value after the tempNode moves
        //        GenericNode<T> previousTempNode = null;
        //        //Start a counter to use to move through the linked list.
        //        int count = 0;

        //        //Loop until the tempNode is null, which means we are at the end.
        //        while (tempNode != null)
        //        {
        //            //If we match the position and the count we are on, we found the
        //            //one that we need to delete
        //            if (count == position)
        //            {
        //                //Set the previous nodes next to the temp node's next
        //                //jumping over the tempnode. The previous node's next will now
        //                //point to the node AFTER the tempnode
        //                previousTempNode.Next = tempNode.Next;

        //                //Check to see if we are deleting the very last node in the list
        //                //if so we need to move the Tail pointer
        //                if (tempNode.Next == null)
        //                {
        //                    //Set Tail to the previousTempNode, which is the new end of the list
        //                    Tail = previousTempNode;
        //                }

        //                //We found the one to delete, so set the return bool to true.
        //                returnBool = true;

        //            }

        //            //Increment the count so we move through the linked list.
        //            count++;
        //            //Set the previous tempnode to the current tempnode. This way when we
        //            //move the tempNode forward, we will still have a pointer to where
        //            //the tempnode was before it moved.
        //            previousTempNode = tempNode;
        //            //Set the tempNode to tempNode's next property, which will move it down
        //            //the linked list one position.
        //            tempNode = tempNode.Next;
        //        }
        //    }
        //    return returnBool;
        //}

        public void Enqueue(T content)
        {
            //Just make another pointer that points to the first node in the linked list
            GenericNode<T> oldFirst = Head;
            //Overwrite head with a new Generic Node
            Head = new GenericNode<T>();
            //Set the data on the node.
            Head.Data = content;
            //Make Head's Next point to the old First
            Head.Next = oldFirst;
        }

        public T Dequeue()
        {
            //Make a return node and set it to the Head, which is the first node in the
            //linked list
            GenericNode<T> returnNode = Head;
            //Move the Head to the next node in the linked list
            Head = Head.Next;
            //Check to see if Head is null, if so, set Tail to null as well. List is empty
            if (Head == null)
            {
                Tail = null;
            }
            //return the Data
            return returnNode.Data;
        }
    }
}
