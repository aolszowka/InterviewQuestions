// -----------------------------------------------------------------------
// <copyright file="AlphabetFrequencyRegexDictionary.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.AlphabetFrequency
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// An implementation of the AlphabetFrequency problem that is based around a Regular Expression to sanitize input and then a Dictionary.
    /// </summary>
    public class AlphabetFrequencyRegexDictionary : IAlphabetFrequency
    {
        /// <summary>
        /// Given a string returns the letters of the English Alphabet in a case insensitive manner along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>An Enumerable of KeyValuePairs in which the key is the letter of the English Alphabet and the value is the frequency in an undefined order.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFreqency(string inputString)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            // Strip anything that is not A-Z
            string sanitizedInput = Regex.Replace(inputString.ToUpper(), "[^A-Z]", string.Empty);

            foreach (var character in sanitizedInput.AsEnumerable())
            {
                if (result.ContainsKey(character))
                {
                    result[character] = result[character] + 1;
                }
                else
                {
                    result.Add(character, 1);
                }
            }

            return result;
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet in a case insensitive manner along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>An Enumerable of KeyValuePairs in which the key is the letter of the English Alphabet and the value is the frequency ordered by Frequency.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByFrequency(string inputString)
        {
            var result = this.AlphabetFreqency(inputString);
            return result.OrderByDescending(kvp => kvp.Value);
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet in a case insensitive manner along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>An Enumerable of KeyValuePairs in which the key is the letter of the English Alphabet and the value is the frequency ordered Alphabetically.</returns>
        public IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByAlpha(string inputString)
        {
            var result = this.AlphabetFreqency(inputString);
            return result.OrderBy(kvp => kvp.Key);
        }
    }
}
