using System;
using IPriorityQueue;
using PriorityQueueLib;

namespace TemporaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueTester.TestPriorityQueue(() => new PriorityQueue<int>(), () => new PriorityQueue<string>());

           

        }
    }
}
