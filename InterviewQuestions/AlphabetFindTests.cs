// -----------------------------------------------------------------------
// <copyright file="AlphabetFind.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for the AlphabetFind Solutions
    /// </summary>
    [TestFixture]
    public class AlphabetFindTests
    {
        /// <summary>
        /// The English Alphabet, String Form.
        /// </summary>
        const string ALL_ALPHABET_STRING = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// The English Alphabet, Array Form.
        /// </summary>
        static char[] ALL_ALPHABET_ARRAY =
            new char[]
            {
                'A', 'B', 'C', 'D', 'E', 'F',
                'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z'
            };

        [Test]
        public void FindMissingLetters_NoMissingLetters()
        {
            var result = AlphabetFind.FindMissingLetters(ALL_ALPHABET_STRING);
            CollectionAssert.IsEmpty(result, "No letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_EmptyString()
        {
            var result = AlphabetFind.FindMissingLetters(string.Empty);
            CollectionAssert.AreEquivalent(ALL_ALPHABET_ARRAY, result, "All letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_SingleMissingLetter()
        {
            // M is missing
            string testString = "ABCDEFGHIJKLNOPQRSTUVWXYZ";
            var expectedResult = new char[] { 'M' };

            var result = AlphabetFind.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter M should be missing.");
        }

        [Test]
        public void FindMissingLetters_MultipleMissingLetters()
        {
            // A,C,E,O,L,S,Z,W,K is missing
            string testString = "BDFGHIJMNPQRTUVXY";
            var expectedResult = new char[] { 'A', 'C', 'E', 'O', 'L', 'S', 'Z', 'W', 'K' };

            var result = AlphabetFind.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letters A, C, E, O, L, S, Z, W, K Should be missing.");
        }

        [Test]
        public void AlphabetFrequency_SingleLetter2TimesDifferentCase()
        {
            string testString = "aA";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 } };

            var result = AlphabetFind.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A occurs 2 times in the test string and used difference cases");
        }

        [Test]
        public void AlphabetFrequency_SingleLetter3Times()
        {
            string testString = "AAA";
            var expectedResult = new Dictionary<char, int> { { 'A', 3 } };

            var result = AlphabetFind.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A occurs 3 times in the test string");
        }

        [Test]
        public void AlphabetFrequency_3Letters3Times()
        {
            string testString = "ABC abc AbC";
            var expectedResult = new Dictionary<char, int> { { 'A', 3 }, { 'B', 3 }, { 'C', 3 } };

            var result = AlphabetFind.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A, B, and C occurs 3 times in the test string in various cases.");
        }

        [Test]
        public void AlphabetFrequency_MultipleLettersMultipleTimes()
        {
            string testString = "Aa BbB CcCc DddDd";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 }, { 'B', 3 }, { 'C', 4 }, { 'D', 5 } };

            var result = AlphabetFind.AlphabetFreqency(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter A (2), B (3), C (4), D (5) occurs in the test string in various cases.");
        }

        [Test]
        public void AlphabetFrequencyOrderByFrequency_MultipleLettersMultipleTimes()
        {
            string testString = "Aa BbB CcCc DddDd";
            var expectedResult = new Dictionary<char, int> { { 'D', 5 }, { 'C', 4 }, { 'B', 3 }, { 'A', 2 } };

            var result = AlphabetFind.AlphabetFrequencyOrderedByFrequency(testString);

            CollectionAssert.AreEqual(expectedResult, result.ToArray(), "The Letter D (5), C (4), B (3), A (2), occurs in the test string in various cases, Order should be by frequency (descending).");
        }

        [Test]
        public void AlphabetFrequencyOrderByAlpha_MultipleLettersMultipleTimes()
        {
            string testString = "DdDdD aA cCcC bBb";
            var expectedResult = new Dictionary<char, int> { { 'A', 2 }, { 'B', 3 }, { 'C', 4 }, { 'D', 5 } };

            var result = AlphabetFind.AlphabetFrequencyOrderedByAlpha(testString);

            CollectionAssert.AreEqual(expectedResult, result.ToArray(), "The Letter A (2), B (3), C (4), D (5), occurs in the test string in various cases, Order should be alphabetical.");
        }
    }
}
