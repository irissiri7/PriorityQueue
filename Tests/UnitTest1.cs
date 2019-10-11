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

            Add10000RandomPositiveValues(sutPQ);

            Assert.AreEqual(10000, sutPQ.Count());
        }

        [Test]
        public void PriorityQueue_Adding10000ValuesAndThenPopingThem_CountIsCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Add10000RandomPositiveValues(sutPQ);

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

            Add10000RandomPositiveValues(sutPQ);

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

            Add10000RandomNegativeValues(sutPQ);

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
        public void PriorityQueue_UsingPeekMultipleTimes_IsCorrectAndDoesNotAffectCount()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Add10000RandomPositiveValues(sutPQ);
            sutPQ.Add(-1);

            Assert.AreEqual(-1, sutPQ.Peek());
            Assert.AreEqual(-1, sutPQ.Peek());
            Assert.AreEqual(-1, sutPQ.Peek());
            Assert.AreEqual(-1, sutPQ.Peek());
            
            Assert.AreEqual(10001, sutPQ.Count());
            
        }

        [Test]
        public void PriorityQueue_CombiningUseOfAddPeekPop_CountIsStillCorrect()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Add10000RandomPositiveValues(sutPQ);
            
            Assert.AreEqual(10000, sutPQ.Count());

            sutPQ.Pop();
            sutPQ.Pop();
            sutPQ.Pop();
            sutPQ.Peek();
            sutPQ.Peek();
            sutPQ.Add(10);
            sutPQ.Add(10);
            sutPQ.Peek();

            Assert.AreEqual(9999, sutPQ.Count());

        }

        [Test]
        public void PriorityQueue_AddingALotOfTheSameNumbers()
        {
            PriorityQueue<int> sutPQ = new PriorityQueue<int>();

            Add10000EqualValues(sutPQ);

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

        public static void Add10000RandomPositiveValues(PriorityQueue<int> somePQ)
        {
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                somePQ.Add(r.Next(0, i));
            }
        }

        public static void Add10000RandomNegativeValues(PriorityQueue<int> somePQ)
        {
            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                somePQ.Add(r.Next(-1000, 0));
            }
        }

        public static void Add10000EqualValues(PriorityQueue<int> somePQ)
        {
            for (int i = 0; i < 10000; i++)
            {
                somePQ.Add(5);
            }
        }

    }
}