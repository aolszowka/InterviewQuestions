// -----------------------------------------------------------------------
// <copyright file="PermutationsPow.cs" company="Taylor Harris">
// Copyright (c) 2015 Taylor Harris.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An implementation of the <see cref="IPermutations"/> problem that heavily utilizes <see cref="Math.Pow"/>.
    /// </summary>
    public class PermutationsPow : IPermutations
    {
        public IEnumerable<string> GeneratePermutations(int slots, IEnumerable<char> possibleValues)
        {
            char[] input = possibleValues.ToArray();
            int size = input.Length;
            int a;
            int b;
            int z;
            char[,] final = new char[slots, (int)Math.Pow(size, slots)];

            for (int x = 0; x < slots; x++)
            {
                z = 0;
                // a is the number of times the first element appears in the specific
                // x coordinate before changing, this will change based on the x coordinate
                // that we are in
                a = (int)Math.Pow(size, slots - (x + 1));
                // b is used to keep track of how many times we've added the element
                b = 0;

                for (int y = 0; y < Math.Pow(size, slots); y++)
                {
                    if (b == a)
                    {
                        z++;
                        b = 0;
                    }
                    if (z >= size)
                    {
                        z = 0;
                    }

                    final[x, y] = input[z];
                    b++;
                }
            }

            for (int y = 0; y < Math.Pow(size, slots); y++)
            {
                StringBuilder sb = new StringBuilder();

                for (int x = 0; x < slots; x++)
                {
                    sb.Append(final[x, y]);
                }

                yield return sb.ToString();
            }
        }
    }
}
