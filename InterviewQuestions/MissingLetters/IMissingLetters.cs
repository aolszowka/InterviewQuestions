// -----------------------------------------------------------------------
// <copyright file="IMissingLetters.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface describing the methods that need to be implemented to solve the MissingLetters Problem.
    /// </summary>
    public interface IMissingLetters
    {
        /// <summary>
        /// Given a string return the letters of the English Alphabet (A-Z case-insensitive) that are missing.
        /// </summary>
        /// <param name="inputString">The <see cref="T:System.String"/> to parse.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="T:System.Char"/> containing the missing characters in UPPERCASE.</returns>
        IEnumerable<char> FindMissingLetters(string inputString);
    }
}
