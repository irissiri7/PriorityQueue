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
        public void PriorityQueue_PeekingEmptyPQ_ThrowsRightException()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            
            Assert.Throws<InvalidOperationException>(() => sutPQ.Peek());
        }
        
        [Test]
        public void PriorityQueue_PopingEmptyPQ_ThrowsRightException()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            Assert.Throws<InvalidOperationException>(() => sutPQ.Pop());
        }

        [Test]
        public void PriorityQueue_Adding10000Values_CountIsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(0, i));
            }

            Assert.AreEqual(10000, sutPQ.Count());
        }

        
        [Test]
        public void PriorityQueue_Adding10000ValuesAndThenPopingThem_CountIsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(0, i));
            }

            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Pop();
            }

            Assert.AreEqual(0, sutPQ.Count());
        }

        [Test]
        public void PriorityQueue_Adding10000ValuesAndPopingThem_AllNumbersComingOutAreEqualOrAscendingFromPrevious()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            
            Random r = new Random();
            
            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(0, i));
            }
            
            var prev = sutPQ.Pop();
            
            while (sutPQ.NumOfNodes > 0)
            {
                var min = sutPQ.Pop();
                if (!(min >= prev))
                {
                    Assert.Fail();
                }
                prev = min;
            }
            Assert.Pass();
        }

        [Test]
        public void PriorityQueue_Adding10000NegativeValues_AllNumbersComingOutAreEqualOrAscendingFromPrevious()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Random r = new Random();

            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(-1000, i));
            }

            var prev = sutPQ.Pop();

            while (sutPQ.NumOfNodes > 0)
            {
                var min = sutPQ.Pop();
                if (!(min >= prev))
                {
                    Assert.Fail();
                }
                prev = min;
            }
            Assert.Pass();
        }


        [Test]
        public void PriorityQueue_AddingThreeValues_RootIsCorrectAndParentChildRelationsAreCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();
            sutPQ.Add(1);
            sutPQ.Add(2);
            sutPQ.Add(3);

            Assert.AreEqual(1, sutPQ.Root.Value);

            Assert.AreEqual(2, sutPQ.Root.LeftChild.Value);
            Assert.AreEqual(3, sutPQ.Root.RightChild.Value);

            Assert.AreEqual(1, sutPQ.Root.LeftChild.Parent.Value);
            Assert.AreEqual(1, sutPQ.Root.RightChild.Parent.Value);

            Assert.AreEqual(null, sutPQ.Root.LeftChild.LeftChild);
            Assert.AreEqual(null, sutPQ.Root.LeftChild.RightChild);

            Assert.AreEqual(null, sutPQ.Root.RightChild.LeftChild);
            Assert.AreEqual(null, sutPQ.Root.RightChild.RightChild);

        }


        [Test]
        public void PriorityQueue_UsingPeekMultipleTimes_IsCorrectAndDoesNotAffectCount()
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

            Assert.AreEqual(1, sutPQ.Root.Value);
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(1, sutPQ.Peek());
            Assert.AreEqual(9, sutPQ.Count());
            
        }

        [Test]
        public void PriorityQueue_CombiningUseOfAddPeekPop_CountIsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Random r = new Random();

            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(r.Next(0, i));
            }
            
            Assert.AreEqual(10000, sutPQ.Count());

            sutPQ.Pop();
            sutPQ.Pop();
            sutPQ.Pop();
            sutPQ.Add(r.Next(0, 1000));

            Assert.AreEqual(9998, sutPQ.Count());

            sutPQ.Peek();

            Assert.AreEqual(9998, sutPQ.Count());

            sutPQ.Add(r.Next(0, 1000));
            sutPQ.Add(r.Next(0, 1000));

            Assert.AreEqual(10000, sutPQ.Count());


        }

        [Test]
        public void PriorityQueue_AddingALotOfTheSameNumbers()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add(5);
            }

            Assert.AreEqual(10000, sutPQ.Count());
        }

        [Test]
        public void PriorityQueue_AddingALotOfTheSameStrings()
        {
            PriorityQueue<string> sutPQ = new PriorityQueue<string>();

            for (int i = 0; i < 10000; i++)
            {
                sutPQ.Add("Lydia");
            }

            Assert.AreEqual(10000, sutPQ.Count());
        }

    }
}