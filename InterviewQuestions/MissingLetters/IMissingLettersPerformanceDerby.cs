// -----------------------------------------------------------------------
// <copyright file="IMissingLettersPerformanceDerby.cs" company="NetOlszowka">
// Copyright (c) 2014 NetOlszowka.
// </copyright>
// -----------------------------------------------------------------------

namespace InterviewQuestions.MissingLetters
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using LinqStatistics;
    using NUnit.Framework;

    /// <summary>
    /// A "Unit Test" to allow us to quickly evaluate performance.
    /// </summary>
    [TestFixture]
    public class IMissingLettersPerformanceDerby
    {

        private string largeTestString;
        private int numberOfTestRuns;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.largeTestString = System.IO.File.ReadAllText(@"Resources\HuckleberryFinn.txt");
            this.numberOfTestRuns = 100;
        }

        [Test, Explicit("This really isn't a unit test per say, make sure Text Output is looking at Trace for statistics.")]
        public void FindMissingLetters_PerformanceTest()
        {
            IEnumerable<IMissingLetters> implementations =
                new IMissingLetters[]
                {
                    new MissingLettersHashSet(),
                    new MissingLettersHashSetKnockout(),
                    new MissingLettersStringContainsEqualityComparer(),
                    new MissingLettersStringContainsToUpper()
                };

            foreach (IMissingLetters implementation in implementations)
            {
                TestImplmenetation(implementation, this.largeTestString, this.numberOfTestRuns);
            }
        }

        public static void TestImplmenetation(IMissingLetters implementationToTest, string testString, int numberOfSamples)
        {
            IList<long> runtimeResults = new List<long>();

            Trace.WriteLine("*******************************");
            Trace.WriteLine(string.Format("Implementation: {0}", implementationToTest.GetType().Name));
            Trace.WriteLine("*******************************");

            // Execute the Tests
            for (int i = 0; i < numberOfSamples; i++)
            {
                Stopwatch timer = Stopwatch.StartNew();
                var result = implementationToTest.FindMissingLetters(testString);
                result.ToArray();
                timer.Stop();
                runtimeResults.Add(timer.ElapsedTicks);
                Trace.WriteLine(string.Format("First Run {0} Took {1} ticks", i, timer.ElapsedTicks));
            }

            // Give some stats on the data
            Trace.WriteLine("*******************************");
            Trace.WriteLine("************ Stats ************");
            Trace.WriteLine("*******************************");
            Trace.WriteLine(string.Format("Median: {0}ticks", runtimeResults.Median()));
            Trace.WriteLine(string.Format("Variance: {0}ticks", runtimeResults.Variance()));
            Trace.WriteLine(string.Format("Standard Deviation: {0}ticks", runtimeResults.StandardDeviation()));
        }
    }
}
