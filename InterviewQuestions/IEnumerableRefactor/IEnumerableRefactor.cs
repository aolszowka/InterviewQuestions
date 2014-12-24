// -----------------------------------------------------------------------
// <copyright file="IEnumerableRefactor.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class to store the sample code for the IEnumerable Refactor Question
    /// </summary>
    public static class IEnumerableRefactor
    {
        /// <summary>
        /// The following function will return all positive and even integers up to and including the target.
        /// </summary>
        /// <param name="target">The target to generate up to, inclusive.</param>
        /// <returns>All positive and even integers up to and including the target.</returns>
        public static IEnumerable<int> AllPostiveEvenNumbersInclusive(int target)
        {
            if (target < 2)
            {
                throw new ArgumentException("Must provide a valid range (target >= 2)");
            }

            IList<int> evenNumbers = new List<int>();
            for (int i = 2; i <= target; i++)
            {
                if (i % 2 == 0)
                {
                    evenNumbers.Add(i);
                }
            }

            return evenNumbers;
        }

        /*********************************************************************\
        |*    CODE BELOW THIS LINE IS A SOLUTION DO NOT PRINT THIS FILE      *|
        \*********************************************************************/

        /// <summary>
        /// The following function will return all positive and even integers up to and including the target.
        /// </summary>
        /// <param name="target">The target to generate up to, inclusive.</param>
        /// <returns>All positive and even integers up to and including the target.</returns>
        public static IEnumerable<int> AllPostiveEvenNumbersInclusiveRefactor(int target)
        {
            if (target < 2)
            {
                throw new ArgumentException("Must provide a valid range (target >= 2)");
            }

            for (int i = 2; i <= target; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }
}
