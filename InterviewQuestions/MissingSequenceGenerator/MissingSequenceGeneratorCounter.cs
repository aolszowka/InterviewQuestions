// -----------------------------------------------------------------------
// <copyright file="MissingSequenceGeneratorCounter.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingSequenceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An implementation of the MissingSequenceGenerator problem that utilizes a counter and loop.
    /// </summary>
    public class MissingSequenceGeneratorCounter : IMissingSequenceGenerator
    {
        /// <summary>
        /// Given an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of values that represent 32bit unsigned integers, generate the missing sequences up to the greatest value.
        /// </summary>
        /// <param name="inputSequence">The input sequence.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> containing the missing sequences.</returns>
        /// <remarks>
        /// This method is assumed to be unsafe and allows the following assumptions:
        /// 1. The input is not null.
        /// 2. The input is sorted.
        /// 3. The input contains all positive numbers.
        /// 4. The input is less than UInt32.MaxValue (4294967295)
        /// </remarks>
        public IEnumerable<long> GenerateMissingSequences(IEnumerable<long> inputSequence)
        {
            long lastValue = 0;

            foreach (long currentSequence in inputSequence)
            {
                lastValue++;
                while (lastValue < currentSequence)
                {
                    yield return lastValue;
                    lastValue++;
                }
            }
        }


        public IEnumerable<long> SafeGenerateMissingSequences(IEnumerable<long> unsafeInput)
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
