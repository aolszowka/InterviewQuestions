// -----------------------------------------------------------------------
// <copyright file="MissingLettersStringContainsToUpper.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A MissingLetter implementation that utilizes a string.Contains(char) and a call to string.ToUpper().
    /// </summary>
    public class MissingLettersStringContainsToUpper : IMissingLetters
    {
        /// <summary>
        /// Given a string return the letters of the English Alphabet (A-Z case-insensitive) that are missing.
        /// </summary>
        /// <param name="inputString">The <see cref="T:System.String"/> to parse.</param>
        /// <returns>An <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="T:System.Char"/> containing the missing characters in UPPERCASE.</returns>
        public IEnumerable<char> FindMissingLetters(string inputString)
        {
            if (inputString == null)
            {
                throw new ArgumentNullException("inputString");
            }

            char[] ALL_ALPHABET_ARRAY =
                new char[]
                        {
                            'A', 'B', 'C', 'D', 'E', 'F',
                            'G', 'H', 'I', 'J', 'K', 'L',
                            'M', 'N', 'O', 'P', 'Q', 'R',
                            'S', 'T', 'U', 'V', 'W', 'X',
                            'Y', 'Z'
                        };
            IList<char> missingCharacters = new List<char>();

            string uppercaseInputString = inputString.ToUpper();

            foreach (char currentChar in ALL_ALPHABET_ARRAY)
            {
                if (!uppercaseInputString.Contains(currentChar))
                {
                    missingCharacters.Add(currentChar);
                }
            }

            return missingCharacters;
        }
    }
}
