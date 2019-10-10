using System;
using PriorityQueue;

namespace PriorityQueueLib
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int NumOfNodes { get; private set; }


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

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = CreateNewNode(value);
            }
            else
            {
                Node<T> parent = FindParentForNewNode(Root);

                if (parent.LeftChild == null)
                {
                    parent.LeftChild = CreateNewNode(value);
                    parent.LeftChild.Parent = parent;
                    BubbelUp();
                }
                else
                {
                    parent.RightChild = CreateNewNode(value);
                    parent.RightChild.Parent = parent;
                    BubbelUp();
                }
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

                Node<T> lastNode = GetLastNodeInTree();

                Root.Value = lastNode.Value;

                RemoveNode(lastNode);

                return output;
            }
        }


        //This method uses the binary representation of NumOfNodes to find the parent Node for a new Node.
        //0 = go left, 1 = go right. Note that the first number is skipped and that we use NumOfNodes + 1;
        private Node<T> FindParentForNewNode(Node<T> start)
        {
            Node<T> pointer = start;
            Node<T> parentForNewNode = null;

            string binaryCounter = Convert.ToString(NumOfNodes + 1, 2);

            for (int i = 1; i < binaryCounter.Length; i++)
            {
                bool shouldGoLeft = (binaryCounter[i] == '0' && pointer.LeftChild != null);
                bool shouldGoRight = (binaryCounter[i] == '1' && pointer.RightChild != null);

                if (shouldGoLeft)
                {
                    pointer = pointer.LeftChild;
                }
                else if (shouldGoRight)
                {
                    pointer = pointer.RightChild;
                }
                else
                {
                    parentForNewNode = pointer;
                }
            }

            return parentForNewNode;
        }

        private Node<T> CreateNewNode(T value)
        {
            NumOfNodes++;
            return new Node<T>(value);
        }

        //This method will look at the last added Node in the tree and "bubbel it up" to the right position
        private void BubbelUp()
        {
            Node<T> lastNode = GetLastNodeInTree();

            while (true)
            {
                if (lastNode.Parent == null)
                {
                    break;
                }
                else if (lastNode.Value.CompareTo(lastNode.Parent.Value) < 0)
                {
                    lastNode = Swap(lastNode, lastNode.Parent);
                }
                else
                {
                    break;
                }
            }
        }

        //This method uses the binary representation of NumOfNodes to navigate to the last Node in the tree
        //0 = go left, 1 = go right. Note that the first number is skipped
        private Node<T> GetLastNodeInTree()
        {
            Node<T> pointer = Root;
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

            return pointer;
        }

        //Basic swapping-method
        private static Node<T> Swap(Node<T> pointer, Node<T> comparerNode)
        {
            T tempHolder = pointer.Value;
            pointer.Value = comparerNode.Value;
            comparerNode.Value = tempHolder;
            pointer = comparerNode;
            return pointer;
        }

        private void RemoveNode(Node<T> nodeToRemove)
        {
            if (nodeToRemove.Parent == null)
            {
                Root = null;
            }
            else if (nodeToRemove.Parent.LeftChild == nodeToRemove)
            {
                nodeToRemove.Parent.LeftChild = null;
                Heapify();
            }
            else
            {
                nodeToRemove.Parent.RightChild = null;
                Heapify();
            }

            NumOfNodes--;
        }

        //A method for "pushing down" a value further down the tree, to appropriate position.
        private void Heapify()
        {
            Node<T> comparer;
            var pointer = Root;

            while (true)
            {
                //If there is no left child, we know there are no children, i.e only root, and we exit method.
                if (pointer.LeftChild == null)
                {
                    break;
                }

                //If there is no right child we know we will be comparing with left child
                if (pointer.RightChild == null)
                {
                    comparer = pointer.LeftChild;
                }
                //If there is both a left and right child, we compare which of the children has highest priority
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

                //Finally checking if we need to swap
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
