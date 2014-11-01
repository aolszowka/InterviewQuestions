// -----------------------------------------------------------------------
// <copyright file="IAlphabetFrequencyTests.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.AlphabetFrequency
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using LinqStatistics;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for IAlphabetFrequency implementations.
    /// </summary>
    [TestFixture]
    public class IAlphabetFrequencyTests
    {
        /// <summary>
        /// The AlphabetFrequency Implementation used in these tests.
        /// </summary>
        private IAlphabetFrequency alphabetFrequencyImplmentation;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.alphabetFrequencyImplmentation = new AlphabetFrequencyArray();
        }

        [Test]
        public void AlphabetFrequency_SingleLetter2TimesDifferentCase()
        {
            string testString = "aA";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A occurs 2 times in the test string and used difference cases");
        }

        [Test]
        public void AlphabetFrequency_SingleLetter3Times()
        {
            string testString = "AAA";
            var expectedResult = new Dictionary<char, int> { { 'A', 3 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A occurs 3 times in the test string");
        }

        [Test]
        public void AlphabetFrequency_3Letters3Times()
        {
            string testString = "ABC abc AbC";
            var expectedResult = new Dictionary<char, int> { { 'A', 3 }, { 'B', 3 }, { 'C', 3 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A, B, and C occurs 3 times in the test string in various cases.");
        }

        [Test]
        public void AlphabetFrequency_MultipleLettersMultipleTimes()
        {
            string testString = "Aa BbB CcCc DddDd";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 }, { 'B', 3 }, { 'C', 4 }, { 'D', 5 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A (2), B (3), C (4), D (5) occurs in the test string in various cases.");
        }

        [Test]
        public void AlphabetFrequencyOrderByFrequency_MultipleLettersMultipleTimes()
        {
            string testString = "Aa BbB CcCc DddDd";
            var expectedResult = new Dictionary<char, int> { { 'D', 5 }, { 'C', 4 }, { 'B', 3 }, { 'A', 2 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFrequencyOrderedByFrequency(testString);

            CollectionAssert.AreEqual(expectedResult, result.ToArray(), "The Letter D (5), C (4), B (3), A (2), occurs in the test string in various cases, Order should be by frequency (descending).");
        }

        [Test]
        public void AlphabetFrequencyOrderByAlpha_MultipleLettersMultipleTimes()
        {
            string testString = "DdDdD aA cCcC bBb";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 }, { 'B', 3 }, { 'C', 4 }, { 'D', 5 } };

            var result = this.alphabetFrequencyImplmentation.AlphabetFrequencyOrderedByAlpha(testString);

            CollectionAssert.AreEqual(expectedResult, result.ToArray(), "The Letter A (2), B (3), C (4), D (5), occurs in the test string in various cases, Order should be alphabetical.");
        }

        #region Performance Testing
        
        [Test, Explicit("You must load in a large file")]
        public void AlphabetFrequency_PerformanceTest()
        {
            string testString = System.IO.File.ReadAllText(@"Resources\HuckleberryFinn.txt");
            int numberOfTestRuns = 100;
            IList<long> runtimeResults = new List<long>();

            System.Diagnostics.Trace.WriteLine("AlphabetFrequency_PerformanceTest");

            // Execute the Tests
            for (int i = 0; i < numberOfTestRuns; i++)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var result = this.alphabetFrequencyImplmentation.AlphabetFreqency(testString);
                result.ToArray();
                timer.Stop();
                runtimeResults.Add(timer.ElapsedMilliseconds);
                System.Diagnostics.Trace.WriteLine(string.Format("First Run {0} Took {1}ms", i, timer.ElapsedMilliseconds));
            }

            // Give some stats on the data
            Trace.WriteLine("*******************************");
            Trace.WriteLine("************ Stats ************");
            Trace.WriteLine("*******************************");
            Trace.WriteLine(string.Format("Median: {0}ms", runtimeResults.Median()));
            Trace.WriteLine(string.Format("Variance: {0}ms", runtimeResults.Variance()));
            Trace.WriteLine(string.Format("Standard Deviation: {0}ms", runtimeResults.StandardDeviation()));
        }

        #endregion
    }
}
