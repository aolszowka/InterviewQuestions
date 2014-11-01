// -----------------------------------------------------------------------
// <copyright file="IMissingLettersTests.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
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

        IMissingLetters missingLettersImplementation;

        [TestFixtureSetUp]
        public void Setup()
        {
            missingLettersImplementation = new MissingLettersHashSet();
        }

        [Test]
        public void FindMissingLetters_NoMissingLetters()
        {
            var result = missingLettersImplementation.FindMissingLetters(ALL_ALPHABET_STRING);
            CollectionAssert.IsEmpty(result, "No letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_EmptyString()
        {
            var result = missingLettersImplementation.FindMissingLetters(string.Empty);
            CollectionAssert.AreEquivalent(ALL_ALPHABET_ARRAY, result, "All letters should be missing.");
        }

        [Test]
        public void FindMissingLetters_SingleMissingLetter()
        {
            // M is missing
            string testString = "ABCDEFGHIJKLNOPQRSTUVWXYZ";
            var expectedResult = new char[] { 'M' };

            var result = missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letter M should be missing.");
        }

        [Test]
        public void FindMissingLetters_MultipleMissingLetters()
        {
            // A,C,E,O,L,S,Z,W,K is missing
            string testString = "BDFGHIJMNPQRTUVXY";
            var expectedResult = new char[] { 'A', 'C', 'E', 'O', 'L', 'S', 'Z', 'W', 'K' };

            var result = missingLettersImplementation.FindMissingLetters(testString);

            CollectionAssert.AreEquivalent(expectedResult, result, "The Letters A, C, E, O, L, S, Z, W, K Should be missing.");
        }

    }
}
