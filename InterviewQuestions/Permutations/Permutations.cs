// -----------------------------------------------------------------------
// <copyright file="PermutationsPow.cs" company="Ace Olszowka">
// Copyright (c) 2015 Ace Olszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System.Collections.Generic;

    /// <summary>
    /// An implementation of the <see cref="IPermutations"/> problem that utilizes Recursion and Continuations (Lazy Enumerable).
    /// </summary>
    public class Permutations: IPermutations
    {
        public IEnumerable<string> GeneratePermutations(int slots, IEnumerable<char> possibleValues)
        {
            foreach (char value in possibleValues)
            {
                if (slots > 1)
                {
                    foreach (string otherSlotValue in GeneratePermutations(slots - 1, possibleValues))
                    {
                        yield return value + otherSlotValue;
                    }
                }
                else
                {
                    yield return value.ToString();
                }
            }
        }
    }
}
