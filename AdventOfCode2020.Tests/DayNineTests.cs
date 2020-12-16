namespace AdventOfCode2020.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DayNineTests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new List<long>()
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576
            };

            DayNine.FindNonXmasNumber(input, 5).Should().Be(127);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input9.txt");
            System.Console.WriteLine(DayNine.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_FindContiguousRangeSummingUpToTotal()
        {
            var input = new List<long>()
            {
                35,
                20,
                15,
                25,
                47,
                40,
                62,
                55,
                65,
                95,
                102,
                117,
                150,
                182,
                127,
                219,
                299,
                277,
                309,
                576
            };

            DayNine.FindContiguousRangeSummingUpToTotal(127, input).Should().Be((2, 5));
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input9.txt");
            System.Console.WriteLine(DayNine.CalculateResultForPartTwo(input));
        }
    }
}
