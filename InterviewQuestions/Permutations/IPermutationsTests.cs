// -----------------------------------------------------------------------
// <copyright file="IPermutationsTests.cs" company="NetOlszowka">
// Copyright (c) 2015 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// A "Unit Test" to allow us to quickly evaluate performance.
    /// </summary>
    [TestFixture]
    public class IPermutationsTests
    {
        /// <summary>
        /// Sanity check to ensure that our implementations will produce the same output.
        /// </summary>
        [Test]
        public void ImplementationsProduceSameOutput()
        {
            int slots = 2;
            var possibleValues = "0123456789ABCDEF".ToCharArray();

            IPermutations implementation1 = new PermutationsPow();
            IPermutations implementation2 = new Permutations();

            var resultImplementation1 =
                implementation1.GeneratePermutations(slots, possibleValues);

            var resultImplementation2 =
                implementation2.GeneratePermutations(slots, possibleValues);

            CollectionAssert.AreEqual(resultImplementation1, resultImplementation2);
        }

        /// <summary>
        /// A "Unit Test" that will allow us to quickly compare the speed of various implementations.
        /// </summary>
        [Test]
        public void PerformanceDebry()
        {
            int speedRunCount = 10;
            int slots = 2;
            var possibleValues = "0123456789ABCDEF".ToCharArray();

            IPermutations implementation1 = new PermutationsPow();
            IPermutations implementation2 = new Permutations();

            IEnumerable<TimeSpan> implementation1Runtimes = SpeedTest(implementation1, possibleValues, slots, speedRunCount);
            IEnumerable<TimeSpan> implementation2Runtimes = SpeedTest(implementation2, possibleValues, slots, speedRunCount);

            _TraceLogResults(implementation1.GetType().Name, implementation1Runtimes);
            _TraceLogResults(implementation2.GetType().Name, implementation2Runtimes);

            Assert.True(true);
        }

        /// <summary>
        /// Internal helper class to properly log results to the Trace log.
        /// </summary>
        /// <param name="implementationName">The name of the implementation that was tested.</param>
        /// <param name="times">The test run times.</param>
        private static void _TraceLogResults(string implementationName, IEnumerable<TimeSpan> times)
        {
            Trace.WriteLine("**********************");
            Trace.WriteLine("*Implementation: " + implementationName + "*");
            Trace.WriteLine("**********************");

            int runNumber = 1;

            foreach (TimeSpan currentTimeSpan in times)
            {
                Trace.Write("Run " + runNumber + ": ");
                Trace.WriteLine(currentTimeSpan.Ticks);
                runNumber++;
            }
        }

        /// <summary>
        ///     Internal helper class to execute the given implementation with
        /// the given inputs over a set number of times, returning the times
        /// of each run.
        /// </summary>
        /// <param name="implementation">The <see cref="IPermutations"/> implementation to test.</param>
        /// <param name="possibleValues">The possible values to generate permutations for.</param>
        /// <param name="slots">The number of "slots" in the permutation.</param>
        /// <param name="runCount">The number of times to execute the speed run.</param>
        /// <returns>An Enumerable of <see cref="TimeSpan"/> that represent the execution times per test.</returns>
        /// <remarks>
        ///   This is not a Lazy Enumerable, this is to ensure the integrity of
        /// the test runs, in general you'll want to toss the first run result
        /// due to associated start up costs.
        /// </remarks>
        private static IEnumerable<TimeSpan> SpeedTest(IPermutations implementation, IEnumerable<char> possibleValues, int slots, int runCount)
        {
            IList<TimeSpan> speedRunResults = new List<TimeSpan>(runCount);

            for (int i = 0; i < runCount; i++)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var currentRunOutput =
                    implementation.GeneratePermutations(slots, possibleValues).ToArray();
                timer.Stop();
                speedRunResults.Add(timer.Elapsed);
            }

            return speedRunResults;
        }
    }
}
