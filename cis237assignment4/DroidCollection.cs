using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        MergeSort sortArray = new MergeSort();

        //--------------------------------------------------------
       // public void AddInitialDroids() // Add items to array for testing
       // {
          //  this.Add("Carbonite", "C3PO", "Gold", 500);
            //droidCollection[0] = new AstromechDroid("Thermasteel", "R2 Unit", "Blue", true, true, true, true, 250);
            //droidCollection[1] = new ProtocolDroid("Plasteel", "Custom-built Unit", "Gold", 6000000);
            //droidCollection[2] = new AstromechDroid("Thermasteel", "R2 Unit", "Green", true, true, true, false, 50);
            //droidCollection[3] = new ProtocolDroid("Plastoid Alloy", "HK Unit", "Rusty Orange", 400000);
            //droidCollection[4] = new AstromechDroid("Plasteel", "T3 Unit", "Silver", false, true, true, false, 50);
            //droidCollection[5] = new JanitorDroid("Plastoid Alloy", "V33 Unit", "Yellow", true, false, false, true, true);
      //  }
        //------------------------------------------------------------

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.

        public DroidCollection() // Default constructor to allow the DroidCollection class to be called for sorting.
        {
        }

        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }

        public void BucketSort()
        {
            GenericStack<AstromechDroid> myGenericAstromechStack = new GenericStack<AstromechDroid>();
            GenericStack<JanitorDroid> myGenericJanitorStack = new GenericStack<JanitorDroid>();
            GenericStack<UtilityDroid> myGenericUtilityStack = new GenericStack<UtilityDroid>();
            GenericStack<ProtocolDroid> myGenericProtocolStack = new GenericStack<ProtocolDroid>();

            GenericQueue<Droid> myGenericQueue = new GenericQueue<Droid>();

            foreach (IDroid droid in droidCollection)
            {
                if (droid != null)
                {
                    if (droid is AstromechDroid)
                    {
                        myGenericAstromechStack.Push((AstromechDroid)droid);
                    }
                    else if (droid is JanitorDroid)
                    {
                        myGenericJanitorStack.Push((JanitorDroid)droid);
                    }
                    else if (droid is UtilityDroid)
                    {
                        myGenericUtilityStack.Push((UtilityDroid)droid);
                    }
                    else if (droid is ProtocolDroid)
                    {
                        myGenericProtocolStack.Push((ProtocolDroid)droid);
                    }
                }
                else
                {
                    break;
                }
            }

            AstromechDroid currentAstromechDroid = myGenericAstromechStack.Pop();
            while (currentAstromechDroid != null)
            {
                myGenericQueue.Enqueue(currentAstromechDroid);
                currentAstromechDroid = myGenericAstromechStack.Pop();
            }

            //for (GenericNode<AstromechDroid> x = myGenericAstromechStack.Head; x != null; x = x.Next)
            //{
            //    myGenericAstromechStack.Pop();
            //}

            JanitorDroid currentJanitorDroid = myGenericJanitorStack.Pop();
            while (currentJanitorDroid != null)
            {
                myGenericQueue.Enqueue(currentJanitorDroid);
                currentJanitorDroid = myGenericJanitorStack.Pop();
            }

            UtilityDroid currentUtilityDroid = myGenericUtilityStack.Pop();
            while (currentUtilityDroid != null)
            {
                myGenericQueue.Enqueue(currentUtilityDroid);
                currentUtilityDroid = myGenericUtilityStack.Pop();
            }

            ProtocolDroid currentProtocolDroid = myGenericProtocolStack.Pop();
            while (currentProtocolDroid != null)
            {
                myGenericQueue.Enqueue(currentProtocolDroid);
                currentProtocolDroid = myGenericProtocolStack.Pop();
            }

            int index = 0;
            IDroid currentDroid = myGenericQueue.Dequeue();
            while (currentDroid != null)
            {
                droidCollection[index] = myGenericQueue.Dequeue();
            }
            
            //int index = 0;
            //while (myGenericAstromechStack[index] != null)
            //{

            //}

            //for (GenericNode<IDroid> x = myGenericAstromechStack.Head; x != null; x = x.Next)
            //{
            //    myGenericAstromechStack.Pop();
            //    myGenericQueue.Enqueue(x);
            //    Console.WriteLine(x.Data);
            //}
            //for (GenericNode<IDroid> x = myGenericJanitorStack.Head; x != null; x = x.Next)
            //{
            //    myGenericJanitorStack.Pop();
            //    myGenericQueue.Enqueue(x);
            //    Console.WriteLine(x.Data);
            //}
            //for (GenericNode<IDroid> x = myGenericUtilityStack.Head; x != null; x = x.Next)
            //{
            //    myGenericUtilityStack.Pop();
            //    myGenericQueue.Enqueue(x);
            //    Console.WriteLine(x.Data);
            //}
            //for (GenericNode<IDroid> x = myGenericProtocolStack.Head; x != null; x = x.Next)
            //{
            //    myGenericProtocolStack.Pop();
            //    myGenericQueue.Enqueue(x);
            //    Console.WriteLine(x.Data);
            //}
            //Console.WriteLine();
            //Console.WriteLine("***************************************");
            //Console.WriteLine();
            ////AstromechDroid currentAstromechDroid = myGenericAstromechStack.Pop();
            ////droidCollection = null;


            //int index = 0;

            //for (GenericNode<IDroid> x = myGenericQueue.Head.Data; x != null; x = x.Next)
            //{
            //    Console.WriteLine(x.Data);
            //    //x.Data = myGenericQueue.Dequeue();
            //    droidCollection[index] = x.Data;
            //    index++;
            //}
        }

        public void MergeSort()
        {
            foreach (IDroid droid in droidCollection)
            {
                if (droid != null)
                {
                    droid.CalculateTotalCost();
                }
                else
                {
                    break;
                }
            }
            sortArray.sort(droidCollection, lengthOfCollection - 1);
        }
    }
}
