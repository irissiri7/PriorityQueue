﻿using System;
using IPriorityQueue;
using PriorityQueueLib;

namespace TemporaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueTester.TestPriorityQueue(() => new PriorityQueue<int>(), () => new PriorityQueue<string>());
            //PriorityQueue<int> myPQ = new PriorityQueue<int>();
            //myPQ.Pop();
        }
    }
}
