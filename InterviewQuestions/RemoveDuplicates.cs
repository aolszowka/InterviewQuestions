// -----------------------------------------------------------------------
// <copyright file="RemoveDuplicates.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RemoveDuplicates
    {
        public static IEnumerable<string> RemoveDuplicatesFromSortedInput(IEnumerable<string> sortedInput)
        {
            string lastLine = string.Empty;

            foreach (string currentInput in sortedInput)
            {
                if (!currentInput.Equals(lastLine))
                {
                    lastLine = currentInput;
                    yield return currentInput;
                }
            }
        }

        public static IEnumerable<string> RemoveDuplicatesFromUnsortedInput(IEnumerable<string> unsortedInput)
        {
            HashSet<string> knownLines = new HashSet<string>();

            foreach (string currentInput in unsortedInput)
            {
                if (knownLines.Add(currentInput))
                {
                    yield return currentInput;
                }
            }
        }
    }
}
