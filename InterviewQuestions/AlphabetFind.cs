// -----------------------------------------------------------------------
// <copyright file="AlphabetFind.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Possible Solution to AlphabetFind Interview Question Series.
    /// </summary>
    public class AlphabetFind
    {
        /// <summary>
        /// Given a string return the letters of the English Alphabet that are missing in a case insensitive manner.
        /// </summary>
        /// <param name="searchstring">The string to parse.</param>
        /// <returns>An Enumerable containing the missing characters.</returns>
        public static IEnumerable<char> FindMissingLetters(string searchstring)
        {
            // All Alphabet
            string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            HashSet<char> alphabet = new HashSet<char>(alphabetString.ToCharArray());

            HashSet<char> inputSet = new HashSet<char>(searchstring.ToUpper().ToCharArray());

            return alphabet.Except(inputSet);
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet in a case insensitive manner along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>An Enumerable of KeyValuePairs in which the key is the letter of the English Alphabet and the value is the frequency in an undefined order.</returns>
        public static IEnumerable<KeyValuePair<char, int>> AlphabetFreqency(string inputString)
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
        public static IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByFrequency(string inputString)
        {
            var result = AlphabetFreqency(inputString);
            return result.OrderByDescending(kvp => kvp.Value);
        }

        /// <summary>
        /// Given a string returns the letters of the English Alphabet in a case insensitive manner along with their frequency.
        /// </summary>
        /// <param name="inputString">The string to parse.</param>
        /// <returns>An Enumerable of KeyValuePairs in which the key is the letter of the English Alphabet and the value is the frequency ordered Alphabetically.</returns>
        public static IEnumerable<KeyValuePair<char, int>> AlphabetFrequencyOrderedByAlpha(string inputString)
        {
            var result = AlphabetFreqency(inputString);
            return result.OrderBy(kvp => kvp.Key);
        }
    }
}
