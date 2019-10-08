﻿using System;
using PriorityQueue;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public Node<T> Pointer { get; private set; } //A dynamic Node used to navigate through binary tree.
        
        public int NumOfNodes { get; private set; }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                NumOfNodes++;
            }
            else
            {
                Pointer = Root;

                //Finding where to insert next Node with the binary 
                //representation of numOfNodes + 1 (skipping first number).
                //0 = go to left child, 1 = go to right child
                string binaryCounter = Convert.ToString(NumOfNodes + 1, 2);
                
                for (int i = 1; i < binaryCounter.Length; i++)
                {
                    if (binaryCounter[i] == '0')
                    {
                        //If empty Node, creating new Node here...
                        if (Pointer.LeftChild == null)
                        {
                            Pointer.LeftChild = new Node<T>(value);
                            Pointer.LeftChild.Parent = Pointer;
                            NumOfNodes++;

                        }
                        //...else moving the pointer to this position and continue loop
                        Pointer = Pointer.LeftChild;
                    }
                    else
                    {
                        //If empty Node, creating new Node here...
                        if (Pointer.RightChild == null)
                        {
                            Pointer.RightChild = new Node<T>(value);
                            Pointer.RightChild.Parent = Pointer;
                            NumOfNodes++;

                        }
                        //...else moving the pointer to this position and continue loop
                        Pointer = Pointer.RightChild;
                    }

                }
                //After inserting new Node, check weather we should swap values with parent node, continuing until
                //reaching a break point.
                while (true)
                {
                    try 
                    { 
                        if (Pointer.Value.CompareTo(Pointer.Parent.Value) < 0) //Here we swap if need be
                        {
                            T temp = Pointer.Value;
                            Pointer.Value = Pointer.Parent.Value;
                            Pointer.Parent.Value = temp;
                            Pointer = Pointer.Parent;
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch(NullReferenceException) //If there is no parent, i.e Pointer is actually Root
                    {
                        break;
                    }
                }

            }
        }

        public int Count() => NumOfNodes;

        public T Peek()
        {
            if (Root == null)
            {
                throw new InvalidOperationException("Invalid operation. PriorityQue is empty.");
            }
            else
            {
                return Root.Value;
            }
        }

        public T Pop()
        {
            
            if (Root == null)
            {
                throw new InvalidOperationException("Invalid operation. PriorityQue is empty.");
            }
            else
            {
                T output = Root.Value; //Saving the Root value to give back at end of method
                
                Pointer = Root;
                //Again, using binary representation of numOfNodes to find the way to which node to Pop, i.e Node furthest down in the "tree"
                string binaryCount = Convert.ToString(NumOfNodes, 2);
                for (int i = 1; i < binaryCount.Length; i++)
                {
                    if (binaryCount[i] == '0')
                    {
                        Pointer = Pointer.LeftChild;
                    }
                    else
                    {
                        Pointer = Pointer.RightChild;
                    }
                }
                
                Root.Value = Pointer.Value; //Root value becomes the value of that Node
                
                //Then removing the Node from tree
                try
                {
                    if (Pointer.Parent.LeftChild == Pointer)
                    {
                        Pointer.Parent.LeftChild = null;
                    }
                    else
                    {
                        Pointer.Parent.RightChild = null;

                    }
                    NumOfNodes--;
                    Heapify();
                }
                catch (NullReferenceException) //This exception means there is only one Node in the tree, i.e the Root, then we remove it.
                {
                    Root = null;
                    NumOfNodes = 0;
                }
                return output;
            }


        }

        //A method for "pushing down" a value from Root further down the tree, to appropriate position.
        private void Heapify()
        {
            Node<T> compare;
            Pointer = Root;

            while (true)
            {

                if (Pointer.LeftChild == null) //If the Pointer doesent have a LeftChild, this means tree only has Root, no need to heapify, breaking out of method;
                {
                    break;
                }

                if (Pointer.RightChild == null) //If the Pointer doesent have a RightChild, we will compare with LeftChild
                {
                    compare = Pointer.LeftChild;
                }
                else //If Pointer has two children, here we find the child with highest priority
                {
                    if (Pointer.LeftChild.Value.CompareTo(Pointer.RightChild.Value) < 0)
                    {
                        compare = Pointer.LeftChild;
                    }
                    else
                    {
                        compare = Pointer.RightChild;
                    }
                }

                if (Pointer.Value.CompareTo(compare.Value) > 0) //Checking if we need to swap
                {
                    T temp = Pointer.Value;
                    Pointer.Value = compare.Value;
                    compare.Value = temp;
                    Pointer = compare;
                }
                else
                {
                    break;
                }

            }
        }

    }
}
