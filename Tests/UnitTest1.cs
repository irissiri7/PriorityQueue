using NUnit.Framework;
using PriorityQueueLib;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void PriorityQueue_CreatingEmptyPQ_IsEmpty()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            Assert.AreEqual(0, sutPQ.Count());
        }

        [Test]
        public void PriorityQueue_AddingOneNode_ThatNodeIsRootAnChilderenAreNull()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            sutPQ.Add(1);
            Assert.AreEqual(1, sutPQ.Root.Value);
            Assert.AreEqual(1, sutPQ.Count());
            Assert.AreEqual(null, sutPQ.Root.LeftChild);
            Assert.AreEqual(null, sutPQ.Root.RightChild);

        }

        [Test]
        public void PriorityQueue_AddingThreeNodes_IsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);

            Assert.AreEqual(1, sutPQ.Root.Value);

            Assert.AreEqual(2, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(3, sutPQ.Root.RightChild.Value);

            Assert.AreEqual(null, sutPQ.Root.LeftChild.LeftChild);
            Assert.AreEqual(null, sutPQ.Root.LeftChild.RightChild);

            Assert.AreEqual(null, sutPQ.Root.RightChild.LeftChild);
            Assert.AreEqual(null, sutPQ.Root.RightChild.RightChild);




        }

        [Test]
        public void PriorityQueue_AddingThreeNodesCheckingParents_IsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);

            Assert.AreEqual(1, sutPQ.Root.LeftChild.Parent.Value);
            Assert.AreEqual(1, sutPQ.Root.RightChild.Parent.Value);

        }

        [Test]
        public void PriorityQueue_AddingSevenNodes_LeftBranchIsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);
            sutPQ.Add(4);
            sutPQ.Add(5);
            sutPQ.Add(6);
            sutPQ.Add(7);

            Assert.AreEqual(7, sutPQ.Count());

            Assert.AreEqual(1, sutPQ.Root.Value);

            Assert.AreEqual(4, sutPQ.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(2, sutPQ.Root.LeftChild.LeftChild.Parent.Value);

            Assert.AreEqual(5, sutPQ.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(2, sutPQ.Root.LeftChild.RightChild.Parent.Value);

        }

        [Test]
        public void PriorityQueue_AddingSevenNodes_RightBranchIsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);
            sutPQ.Add(4);
            sutPQ.Add(5);
            sutPQ.Add(6);
            sutPQ.Add(7);

            Assert.AreEqual(7, sutPQ.Count());

            Assert.AreEqual(1, sutPQ.Root.Value);

            Assert.AreEqual(7, sutPQ.Root.RightChild.RightChild.Value);
            Assert.AreEqual(3, sutPQ.Root.RightChild.RightChild.Parent.Value);

            Assert.AreEqual(6, sutPQ.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(3, sutPQ.Root.RightChild.LeftChild.Parent.Value);
        }

        [Test]
        public void PriorityQueue_AddingALotOfRandomNodes_IsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(20);
            sutPQ.Add(12);
            sutPQ.Add(3);
            sutPQ.Add(6);
            sutPQ.Add(9);
            sutPQ.Add(10);
            sutPQ.Add(300);
            sutPQ.Add(34);
            sutPQ.Add(93);
            sutPQ.Add(1);
            sutPQ.Add(9);

            Assert.AreEqual(1, sutPQ.Root.Value);

            //Checking far most leftbranch
            Assert.AreEqual(3, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(20, sutPQ.Root.LeftChild.LeftChild.Value);
            Assert.AreEqual(34, sutPQ.Root.LeftChild.LeftChild.LeftChild.Value);

            //Checking far most right branch
            Assert.AreEqual(10, sutPQ.Root.RightChild.Value);
            Assert.AreEqual(300, sutPQ.Root.RightChild.RightChild.Value);

            //Checking everything inbetween
            Assert.AreEqual(6, sutPQ.Root.LeftChild.RightChild.Value);
            Assert.AreEqual(9, sutPQ.Root.LeftChild.RightChild.LeftChild.Value);
            Assert.AreEqual(9, sutPQ.Root.LeftChild.RightChild.RightChild.Value);
            Assert.AreEqual(12, sutPQ.Root.RightChild.LeftChild.Value);

        }

        [Test]
        public void PriorityQueue_AddingNodeToPerculateUp_IsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(2);
            sutPQ.Add(3);
            sutPQ.Add(1);

            Assert.AreEqual(3, sutPQ.Count());
            Assert.AreEqual(1, sutPQ.Root.Value);
            Assert.AreEqual(3, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(2, sutPQ.Root.RightChild.Value);
        }

        [Test]
        public void PriorityQueue_AddingNodeToPerculateUpAtGreaterDepth_IsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(2);
            sutPQ.Add(3);
            sutPQ.Add(4);
            sutPQ.Add(5);
            sutPQ.Add(6);
            sutPQ.Add(7);
            sutPQ.Add(8);
            sutPQ.Add(9);
            sutPQ.Add(1);

            Assert.AreEqual(9, sutPQ.Count());
            Assert.AreEqual(1, sutPQ.Root.Value);
            Assert.AreEqual(2, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(4, sutPQ.Root.RightChild.Value);


        }

        [Test]
        public void PriorityQueue_UsingPeek_IsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(2);
            sutPQ.Add(3);
            sutPQ.Add(4);
            sutPQ.Add(5);
            sutPQ.Add(6);
            sutPQ.Add(7);
            sutPQ.Add(8);
            sutPQ.Add(9);
            sutPQ.Add(1);

            Assert.AreEqual(9, sutPQ.Count());
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(1, sutPQ.Root.Value);

        }

        [Test]

        public void PriorityQueue_UsingPop_IsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);

            sutPQ.Pop();

            Assert.AreEqual(2, sutPQ.Count());
            Assert.AreEqual(2, sutPQ.Root.Value);
            Assert.AreEqual(3, sutPQ.Root.LeftChild.Value);


        }

        [Test]

        public void PriorityQueue_UsingPeekAtGreaterDepth_IsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(20);
            sutPQ.Add(12);
            sutPQ.Add(3);
            sutPQ.Add(6);
            sutPQ.Add(9);
            sutPQ.Add(10);
            sutPQ.Add(300);
            sutPQ.Add(34);
            sutPQ.Add(93);
            sutPQ.Add(1);
            sutPQ.Add(9);

            Assert.AreEqual(11, sutPQ.Count());
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(1, sutPQ.Root.Value);

        }

        [Test]
        public void PriorityQueue_UsingPopAtGreaterDepth_IsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(20);
            sutPQ.Add(12);
            sutPQ.Add(3);
            sutPQ.Add(6);
            sutPQ.Add(9);
            sutPQ.Add(10);
            sutPQ.Add(300);
            sutPQ.Add(34);
            sutPQ.Add(93);
            sutPQ.Add(1);
            sutPQ.Add(9);

            int output = sutPQ.Pop();

            Assert.AreEqual(1, output);
            Assert.AreEqual(3, sutPQ.Root.Value);
            Assert.AreEqual(6, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(10, sutPQ.Root.RightChild.Value);
        }

        [Test]
        public void PriorityQueue_SimulatingMattiasTestWithALotOFNumsUsingPop()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            Random r = new Random();
            for(int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(0, i));
            }
            var prev = 0;
            while(sutPQ.Counter > 0)
            {
                var min = sutPQ.Pop();
                if(!(min >= prev))
                {
                    Assert.Fail();
                }
                prev = min;
            }
            Assert.Pass();
        }

    }
}