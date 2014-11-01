// -----------------------------------------------------------------------
// <copyright file="MissingLettersHashSet.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A MissingLetter implementation that utilizes HashSet.Except(HashSet).
    /// </summary>
    public class MissingLettersHashSet : IMissingLetters
    {
        /// <summary>
        /// Given a string return the letters of the English Alphabet (A-Z case-insensitive) that are missing.
        /// </summary>
        /// <param name="inputString">The <see cref="T:System.String"/> to parse.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="T:System.Char"/> containing the missing characters in UPPERCASE.</returns>
        public IEnumerable<char> FindMissingLetters(string inputString)
        {
            // All Alphabet
            string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            HashSet<char> alphabet = new HashSet<char>(alphabetString.ToCharArray());

            HashSet<char> inputSet = new HashSet<char>(inputString.ToUpper().ToCharArray());

            return alphabet.Except(inputSet);
        }
    }
}
