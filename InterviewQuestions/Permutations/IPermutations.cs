// -----------------------------------------------------------------------
// <copyright file="IPermutations.cs" company="NetOlszowka">
// Copyright (c) 2015 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface describing the methods that need to be implemented to solve the Permutations Problem.
    /// </summary>
    public interface IPermutations
    {
        /// <summary>
        /// Implement this function such that:
        /// GeneratePermutations(2, "0123456789ABCDEF".ToCharArray()); returns the values 00-FF
        /// </summary>
        /// <param name="slots">The number of "slots" to generate permutations for.</param>
        /// <param name="possibleValues">The values that compose this permutation.</param>
        /// <returns>
        /// An Enumerable that represents all permutations for the given inputs.
        /// The input is expected to be ordered.
        /// </returns>
        IEnumerable<string> GeneratePermutations(int slots, IEnumerable<char> possibleValues);
    }
}
