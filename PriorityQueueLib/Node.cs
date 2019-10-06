using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueueLib
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public Node(T value)
        {
            Value = value;
        }


    }
}
