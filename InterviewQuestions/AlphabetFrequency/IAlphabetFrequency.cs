// -----------------------------------------------------------------------
// <copyright file="IAlphabetFrequency.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.AlphabetFrequency
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface describing the methods that need to be implemented to solve the AlphabetFrequency Problem.
    /// </summary>
    public interface IAlphabetFrequency
    {
        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. The order is indeterminate.</returns>
        IEnumerable<KeyValuePair<char, int>> AlphabetFreqency(string inputString);

        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency. The returned enumerable should be ordered by frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. Must be ordered by frequency.</returns>
        IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByFrequency(string inputString);

        /// <summary>
        /// Given a string returns the letters of the English Alphabet (A-Z, case insensitive) along with their frequency. The returned enumerable should be ordered by frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>Returns an <see cref="T:System.Collections.Generic.IEnumerable{T}"/> of <see cref="System.Collections.Generic.KeyValuePair{T,U}"/> of <see cref="T:System.Char"/>, <see cref="T:System.Int32"/> in which the key is the letter of the English Alphabet (in UPPERCASE) and the value is the frequency. Must be ordered alphabetically.</returns>
        IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByAlpha(string inputString);
    }
}
