// -----------------------------------------------------------------------
// <copyright file="AlphabetFrequencyArray.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.AlphabetFrequency
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An implementation of the AlphabetFrequency problem that is based around a fixed size array and enumeration of the characters.
    /// </summary>
    public class AlphabetFrequencyArray : IAlphabetFrequency
    {
        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. The order is indeterminate.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFreqency(string inputString)
        {
            int[] characterArray = new int[26];

            foreach (char currentChar in inputString)
            {
                int currentCharInt = (int)currentChar;

                // Is between A-z (including the 32 characters between)
                if (currentCharInt < 123 && currentCharInt > 64)
                {
                    // Is lowercase?
                    if (currentCharInt > 96)
                    {
                        // Uppercase it
                        currentCharInt = currentCharInt - 32;
                    }

                    // Is a valid character? (Exclude the 32)
                    if (currentCharInt < 91)
                    {
                        // Zero base our index
                        currentCharInt = currentCharInt - 65;
                        characterArray[currentCharInt] = characterArray[currentCharInt] + 1;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            for (int i = 0; i < characterArray.Length; i++)
            {
                int count = characterArray[i];
                if (count > 0)
                {
                    char charRepresentation = (char)(i + 65);
                    yield return new KeyValuePair<char, int>(charRepresentation, count);
                }
            }
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency. The returned enumerable should be ordered by frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. Must be ordered by frequency.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByFrequency(string inputString)
        {
            var result = this.AlphabetFreqency(inputString);
            return result.OrderByDescending(kvp => kvp.Value);
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency. The returned enumerable should be ordered by frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. Must be ordered alphabetically.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByAlpha(string inputString)
        {
            var result = AlphabetFreqency(inputString);
            return result.OrderBy(kvp => kvp.Key);
        }
    }
}
