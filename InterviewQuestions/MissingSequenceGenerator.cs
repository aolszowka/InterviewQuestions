// -----------------------------------------------------------------------
// <copyright file="MissingSequenceGenerator.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MissingSequenceGenerator
    {
        /// <summary>
        /// Given an Enumerable of numbers, generate the missing sequences up to the greatest value.
        /// </summary>
        /// <param name="sortedInputSequnce">The positive sorted input.</param>
        /// <returns>An Enumerable containing the missing sequences.</returns>
        /// <remarks>
        /// This method is unsafe and makes the following assumptions:
        /// 1. The input is sorted
        /// 2. The input contains all positive numbers.
        /// </remarks>
        public static IEnumerable<Int64> GenerateMissingSequences(IEnumerable<Int64> sortedInputSequnce)
        {
            Int64 lastValue = 0;

            foreach (Int64 currentSequence in sortedInputSequnce)
            {
                lastValue++;
                while (lastValue < currentSequence)
                {
                    yield return lastValue;
                    lastValue++;
                }
            }
        }

        /// <summary>
        /// Given an Enumerable of numbers, generate the missing sequences up to the greatest value.
        /// </summary>
        /// <param name="unsafeInput">The input list, which does not need to be sorted.</param>
        /// <returns>An Enumerable containing the missing sequences.</returns>
        public static IEnumerable<Int64> SafeGenerateMissingSequences(IEnumerable<Int64> unsafeInput)
        {
            // Check to see if we got anything at all
            if (unsafeInput == null)
            {
                throw new ArgumentNullException("unsafeInput");
            }

            if (!unsafeInput.Any())
            {
                throw new ArgumentOutOfRangeException("No input was given.");
            }

            // Assume the input isn't sorted
            var sortedSafeInput = unsafeInput.OrderBy(x => x);

            // Make sure our first value is a positive one
            if (sortedSafeInput.First() < 1)
            {
                throw new ArgumentOutOfRangeException("Non-positive value detected");
            }

            // Make sure we weren't given a value too large
            if (sortedSafeInput.Any(x => x > 4294967295))
            {
                throw new ArgumentOutOfRangeException("Value greater than Uint32.Max (4294967295) detected");
            }

            // Finally call our unsafe function
            return GenerateMissingSequences(sortedSafeInput);
        }
    }
}
