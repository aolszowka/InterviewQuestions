// -----------------------------------------------------------------------
// <copyright file="MissingLettersStringContainsEqualityComparer.cs" company="NetOlszowka">
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
    /// A MissingLetter implementation that utilizes a string.Contains(char) and a custom equality comparer.
    /// </summary>
    public class MissingLettersStringContainsEqualityComparer : IMissingLetters
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
            CharCaseInsenstiveEqualityComparer caseInsenstiveCharComparer = new CharCaseInsenstiveEqualityComparer();

            foreach (char currentChar in ALL_ALPHABET_ARRAY)
            {
                if (!inputString.Contains(currentChar, caseInsenstiveCharComparer))
                {
                    missingCharacters.Add(currentChar);
                }
            }

            return missingCharacters;
        }
    }

    /// <summary>
    /// A Case-insensitive <see cref="T:System.char"/> equality comparer.
    /// </summary>
    public class CharCaseInsenstiveEqualityComparer : IEqualityComparer<char>
    {
        /// <summary>
        /// Two characters are considered equal if they are the same regardless of case (IE A == a).
        /// </summary>
        /// <param name="x">The first character to compare.</param>
        /// <param name="y">The second character to compare.</param>
        /// <returns><c>true</c> if the characters are the same, regardless of case; otherwise, <c>false</c>.</returns>
        public bool Equals(char x, char y)
        {
            if (x.Equals(y))
            {
                return true;
            }
            else if(char.ToUpper(x).Equals(char.ToUpper(y)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the HashCode of the character based on case-insensitivity.
        /// </summary>
        /// <param name="obj">The character for which to generate a HashCode</param>
        /// <returns>Returns the hash for this instance.</returns>
        public int GetHashCode(char obj)
        {
            return char.ToUpper(obj).GetHashCode();
        }
    }
}
