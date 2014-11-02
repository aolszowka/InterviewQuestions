// -----------------------------------------------------------------------
// <copyright file="IMissingLettersTests.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using LinqStatistics;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for MissingLetter implementations.
    /// </summary>
    [TestFixture]
    public class IMissingLettersTests
    {
        /// <summary>
        /// The English Alphabet, String Form.
        /// </summary>
        private const string ALL_ALPHABET_STRING_UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// The English Alphabet, Array Form.
        /// </summary>
        private static char[] ALL_ALPHABET_ARRAY =
            new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F',
                'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z'
            };

        /// <summary>
        /// The MissingLetters Implementation used in these tests.
        /// </summary>
        private IMissingLetters missingLettersImplementation;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.missingLettersImplementation = new MissingLettersHashSet();
        }

        [Test]
        public void FindMissingLetters_NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => this.missingLettersImplementation.FindMissingLetters(null));
        }

        [Test]
        public void FindMissingLetters_EmptyString()
        {
            var result = this.missingLettersImplementation.FindMissingLetters(string.Empty);
            CollectionAssert.AreEquivalent(ALL_ALPHABET_ARRAY, result, "All letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_NoMissingLetters_AllUppercase()
        {
            var result = this.missingLettersImplementation.FindMissingLetters(ALL_ALPHABET_STRING_UPPERCASE);
            CollectionAssert.IsEmpty(result, "No letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_NoMissingLetters_MixedCase()
        {
            // All alphabet mixed case
            string testString = "aBcdEfGHIjkLmNoPqRsTUVWxyz";

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.IsEmpty(result, "No letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_SingleMissingLetter_AllLowercase()
        {
            // M is missing
            string testString = "abcdefghijklnopqrstuvwxyz";
            var expectedResult = new char[] { 'M' };

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter M should be missing.");
        }

        [Test]
        public void FindMissingLetters_SingleMissingLetter_AllUppercase()
        {
            // M is missing
            string testString = "ABCDEFGHIJKLNOPQRSTUVWXYZ";
            var expectedResult = new char[] { 'M' };

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter M should be missing.");
        }

        [Test]
        public void FindMissingLetters_SingleMissingLetter_MixedCase()
        {
            // M is missing
            string testString = "ABCdefGHIJKlnOPqrSTUVwxyZ";
            var expectedResult = new char[] { 'M' };

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter M should be missing.");
        }

        [Test]
        public void FindMissingLetters_MultipleMissingLetters()
        {
            // A,C,E,O,L,S,Z,W,K is missing
            string testString = "BDFGHIJMNPQRTUVXY";
            var expectedResult = new char[] { 'A', 'C', 'E', 'O', 'L', 'S', 'Z', 'W', 'K' };

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letters A, C, E, O, L, S, Z, W, K Should be missing.");
        }

        [Test]
        public void FindMissingLetters_NonAlphaInput()
        {
            // A,C,E,O,L,S,Z,W,K is missing
            string testString = "!BDF_GH123-IJ+=MNP*QR \r TU $ VX Y♪▲♀♂\n";
            var expectedResult = new char[] { 'A', 'C', 'E', 'O', 'L', 'S', 'Z', 'W', 'K' };

            var result = this.missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letters A, C, E, O, L, S, Z, W, K Should be missing.");
        }

        #region Performance Testing

        [Test, Explicit("You must load in a large file")]
        public void FindMissingLetters_PerformanceTest()
        {
            string testString = System.IO.File.ReadAllText(@"Resources\HuckleberryFinn.txt");
            int numberOfTestRuns = 100;
            IList<long> runtimeResults = new List<long>();

            System.Diagnostics.Trace.WriteLine("FindMissingLetters_PerformanceTest");

            // Execute the Tests
            for (int i = 0; i < numberOfTestRuns; i++)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var result = this.missingLettersImplementation.FindMissingLetters(testString);
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
