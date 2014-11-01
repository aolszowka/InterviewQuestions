// -----------------------------------------------------------------------
// <copyright file="MissingLettersHashSetKnockout.cs"  company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A MissingLetter implementation that utilizes a "Knockout" HashSet.
    /// </summary>
    public class MissingLettersHashSetKnockout : IMissingLetters
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

            // All Alphabet
            string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            HashSet<char> alphabetMissing = new HashSet<char>(alphabetString.ToCharArray());

            var inputStringChars = inputString.AsEnumerable();

            using (var charsEnumerator = inputStringChars.GetEnumerator())
            {
                while (charsEnumerator.MoveNext() && alphabetMissing.Any())
                {
                    alphabetMissing.Remove(char.ToUpper(charsEnumerator.Current));
                }
            }

            return alphabetMissing;
        }
    }
}
