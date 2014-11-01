// -----------------------------------------------------------------------
// <copyright file="IMissingSequenceGeneratorTests.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingSequenceGenerator
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Unit Tests for MissingSequenceGenerator implementations.
    /// </summary>
    [TestFixture]
    public class IMissingSequenceGeneratorTests
    {
        /// <summary>
        /// The MissingSequenceGenerator Implementation used in these tests.
        /// </summary>
        private IMissingSequenceGenerator missingSequenceGenerator;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.missingSequenceGenerator = new MissingSequenceGeneratorCounter();
        }

        [Test]
        public void GenerateMissingSequences_Test1()
        {
            var inputList = new long[] { 2, 5, 6, 10 };
            var expectedResult = new long[] { 1, 3, 4, 7, 8, 9 };

            var result = this.missingSequenceGenerator.GenerateMissingSequences(inputList);

            CollectionAssert.AreEqual(expectedResult, result, "Given 2,5,6,10 we should have seen 1,3,4,7,8,9.");
        }

        [Test]
        public void GenerateMissingSequences_SmallestListPossible()
        {
            var inputList = new long[] { 1 };

            var result = this.missingSequenceGenerator.GenerateMissingSequences(inputList);

            CollectionAssert.IsEmpty(result, "When given an input list of 1 we shouldn't return any sequences.");
        }

        [Test, Explicit("This test takes ~1 minute to execute; additionally poor implementations may result in OutOfMemoryExceptions.")]
        public void GenerateMissingSequences_MaxUInt32()
        {
            // UInt32.MaxValue should be 4294967295
            var inputList = new long[] { 4294967295 };

            var result = this.missingSequenceGenerator.GenerateMissingSequences(inputList);

            Assert.That(result.LongCount(), Is.EqualTo(4294967294), "When attempting to generate a list at Max Unsigned Int32 Boundary (4294967295) we should get 4294967294 elements.");
        }

        #region Invalid Input On Safe Function Tests

        [Test]
        public void SafeGenerateMissingSequences_NullInput_NullArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => this.missingSequenceGenerator.SafeGenerateMissingSequences(null));
        }

        [Test]
        public void SafeGenerateMissingSequences_EmptyInput_ArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.missingSequenceGenerator.SafeGenerateMissingSequences(new long[0]));
        }

        [Test]
        public void SafeGenerateMissingSequences_NonPositive_ArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.missingSequenceGenerator.SafeGenerateMissingSequences(new long[] { 100, 0 }));
        }

        [Test]
        public void SafeGenerateMissingSequences_LargerThanMaxUint32_ArgumentException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.missingSequenceGenerator.SafeGenerateMissingSequences(new long[] { 1337, 4294967296 }));
        }

        #endregion
    }
}
