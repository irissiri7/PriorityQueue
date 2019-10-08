using System;
using PriorityQueue;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public Node<T> Pointer { get; private set; }
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
                //representation of numOfNodes + 1 (skipping first number)
                string binaryCounter = Convert.ToString(NumOfNodes + 1, 2);
                
                for (int i = 1; i < binaryCounter.Length; i++)
                {
                    if (binaryCounter[i] == '0')
                    {
                        if (Pointer.LeftChild == null)
                        {
                            Pointer.LeftChild = new Node<T>(value);
                            Pointer.LeftChild.Parent = Pointer;
                            NumOfNodes++;

                        }
                        Pointer = Pointer.LeftChild;
                    }
                    else
                    {
                        if (Pointer.RightChild == null)
                        {
                            Pointer.RightChild = new Node<T>(value);
                            Pointer.RightChild.Parent = Pointer;
                            NumOfNodes++;

                        }
                        Pointer = Pointer.RightChild;
                    }

                }
                while (true)
                {
                    if(Pointer.Parent == null)
                    {
                        break;
                    }
                    if (Pointer.Value.CompareTo(Pointer.Parent.Value) == 0)
                    {
                        break;
                    }
                    if (Pointer.Value.CompareTo(Pointer.Parent.Value) < 0)
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

            }
        }

        public int Count()
        {
            return NumOfNodes;
        }

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
                Pointer = Root;
                
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
                Root.Value = Pointer.Value;
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
                catch
                {
                    Root = null;
                    NumOfNodes = 0;
                }
                return output;
            }


        }

        private void Heapify()
        {
            Node<T> compare;
            Pointer = Root;

            while (true)
            {

                if (Pointer.LeftChild == null)
                {
                    break;
                }

                if (Pointer.RightChild == null)
                {
                    compare = Pointer.LeftChild;
                }
                else
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

                if (Pointer.Value.CompareTo(compare.Value) > 0)
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
