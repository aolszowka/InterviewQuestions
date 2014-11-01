// -----------------------------------------------------------------------
// <copyright file="IMissingSequenceGenerator.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingSequenceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface describing the methods that need to be implemented to solve the MissingSequenceGenerator Problem.
    /// </summary>
    public interface IMissingSequenceGenerator
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
        /// 4. The input is less than UInt32.MaxValue (4294967295).
        /// </remarks>
        IEnumerable<long> GenerateMissingSequences(IEnumerable<long> inputSequence);

        /// <summary>
        /// Given an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of values that represent 32bit unsigned integers, generate the missing sequences up to the greatest value.
        /// </summary>
        /// <param name="unsafeInput">The input list, which does not guarantee the conditions listed in the remarks.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> containing the missing sequences.</returns>
        /// <remarks>
        /// This method is assumed to be safe and should account for the following (by throwing the appropriate exceptions):
        /// 1. The input is not null. (ArgumentNullException)
        /// 2. The input is sorted. (ArgumentOutOfRangeException)
        /// 3. The input contains all positive numbers. (ArgumentOutOfRangeException)
        /// 4. The input is less than UInt32.MaxValue (4294967295). (ArgumentOutOfRangeException)
        /// 5. Any other possible bad inputs not listed here, throwing an appropriate exception.
        /// </remarks>
        IEnumerable<long> SafeGenerateMissingSequences(IEnumerable<long> unsafeInput);
    }
}
