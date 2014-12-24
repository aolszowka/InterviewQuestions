// -----------------------------------------------------------------------
// <copyright file="IEnumerableRefactorTests.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using LinqStatistics;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for the IEnumerableRefactor question.
    /// </summary>
    [TestFixture]
    public class IEnumerableRefactorTests
    {
        [Test]
        public void AllPostiveEvenNumbersInclusive_InvalidArgsNegativeValue_Exception()
        {
            string message = "A negative number should throw an exception.";
            Assert.Throws<ArgumentException>(() => IEnumerableRefactor.AllPostiveEvenNumbersInclusive(-1).ToArray(),  message);
        }

        [Test]
        public void AllPostiveEvenNumbersInclusive_InvalidArgsPositiveLessThan2_Exception()
        {
            string message = "A positive number less than 2 should throw an exception.";
            Assert.Throws<ArgumentException>(() => IEnumerableRefactor.AllPostiveEvenNumbersInclusive(1).ToArray(), message);
        }

        [Test]
        public void AllPostiveEvenNumbersInclusive_ValidBoundaryAt2_NoException()
        {
            string message = "The number 2 is the smallest value you can give to this function and should not error.";
            Assert.DoesNotThrow(() => IEnumerableRefactor.AllPostiveEvenNumbersInclusive(2).ToArray());
        }

        [Test]
        public void AllPostiveEvenNumbersInclusive_ValidBoundaryAt2_SingleResult()
        {
            string message = "The number 2 is the smallest value you can give to this function, and should return 1 result (2).";
            var expectedResult = new int[] { 2 };

            var actualResult = IEnumerableRefactor.AllPostiveEvenNumbersInclusive(2);
            CollectionAssert.AreEquivalent(expectedResult, actualResult, message);
        }

        [Test]
        public void AllPostiveEvenNumbersInclusive_ValidInput10_FiveResults()
        {
            string message = "If the target is 10 we would expect to see 5 results (2,4,6,8,10).";
            var expectedResult = new int[] { 2, 4, 6, 8, 10 };

            var actualResult = IEnumerableRefactor.AllPostiveEvenNumbersInclusive(10);
            CollectionAssert.AreEquivalent(expectedResult, actualResult, message);
        }

        [Test, Explicit("This is not really a unit test, but a convenient way to look at performance (ticks).")]
        public void AllPostiveEvenNumbersInclusive_PerformanceDerby()
        {
            int numberOfSamples = 10;
            int targetValue = 10000;

            IList<long> runtimeResults = new List<long>();

            // Execute the Tests
            for (int i = 0; i < numberOfSamples; i++)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var result = IEnumerableRefactor.AllPostiveEvenNumbersInclusive(targetValue);
                result.ToArray();
                timer.Stop();
                runtimeResults.Add(timer.ElapsedTicks);
                Trace.WriteLine(string.Format("First Run {0} Took {1} ticks", i, timer.ElapsedTicks));
            }

            // Give some stats on the data
            Trace.WriteLine("*******************************");
            Trace.WriteLine("************ Stats ************");
            Trace.WriteLine("*******************************");
            Trace.WriteLine(string.Format("Median: {0}ticks", runtimeResults.Median()));
            Trace.WriteLine(string.Format("Variance: {0}ticks", runtimeResults.Variance()));
            Trace.WriteLine(string.Format("Standard Deviation: {0}ticks", runtimeResults.StandardDeviation()));
        }
    }
}
