using System;
using PriorityQueue;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
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
                Node<T> pointer = Root;

                //Finding where to insert next Node with binary representation of 
                //NumOfNodes, 0 = go left, 1 = go right
                string binaryCounter = Convert.ToString(NumOfNodes + 1, 2); 
                for (int i = 1; i < binaryCounter.Length; i++)
                {
                    if (binaryCounter[i] == '0')
                    {
                        if (pointer.LeftChild == null)
                        {
                            pointer.LeftChild = new Node<T>(value);
                            pointer.LeftChild.Parent = pointer;
                            NumOfNodes++;

                        }
                        pointer = pointer.LeftChild;
                    }
                    else
                    {
                        if (pointer.RightChild == null)
                        {
                            pointer.RightChild = new Node<T>(value);
                            pointer.RightChild.Parent = pointer;
                            NumOfNodes++;

                        }
                        pointer = pointer.RightChild;
                    }
                }
                
                //Check weather to swap values with parent node
                while (true)
                {
                    if(pointer.Parent == null)
                    {
                        break;
                    }
                    else if(pointer.Value.CompareTo(pointer.Parent.Value) < 0)
                    {
                        pointer = Swap(pointer, pointer.Parent);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static Node<T> Swap(Node<T> pointer, Node<T> comparerNode)
        {
            T tempHolder = pointer.Value;
            pointer.Value = comparerNode.Value;
            comparerNode.Value = tempHolder;
            pointer = comparerNode;
            return pointer;
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
                T output = Root.Value;
                
                var pointer = Root;
                //Again, using binary representation of numOfNodes to navigate the tree
                string binaryCount = Convert.ToString(NumOfNodes, 2);
                for (int i = 1; i < binaryCount.Length; i++)
                {
                    if (binaryCount[i] == '0')
                    {
                        pointer = pointer.LeftChild;
                    }
                    else
                    {
                        pointer = pointer.RightChild;
                    }
                }
                
                Root.Value = pointer.Value;

                //Removing the Node from tree
                if(pointer.Parent == null)
                {
                    Root = null;
                }
                else if (pointer.Parent.LeftChild == pointer)
                {
                    pointer.Parent.LeftChild = null;
                    Heapify();
                }
                else
                {
                    pointer.Parent.RightChild = null;
                    Heapify();
                }
                NumOfNodes--;
                return output;
            }
        }

        //A method for "pushing down" a value further down the tree, to appropriate position.
        private void Heapify()
        {
            Node<T> comparer;
            var pointer = Root;

            while (true)
            {

                if (pointer.LeftChild == null)
                {
                    break;
                }

                if (pointer.RightChild == null)
                {
                    comparer = pointer.LeftChild;
                }
                else
                {
                    if (pointer.LeftChild.Value.CompareTo(pointer.RightChild.Value) < 0)
                    {
                        comparer = pointer.LeftChild;
                    }
                    else
                    {
                        comparer = pointer.RightChild;
                    }
                }

                if (pointer.Value.CompareTo(comparer.Value) > 0)
                {
                    pointer = Swap(pointer, comparer);
                }
                else
                {
                    break;
                }

            }
        }

    }
}
