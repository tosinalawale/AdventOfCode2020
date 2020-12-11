namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DaySixTests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };

            DaySix.CalculateResultForPartOne(input).Should().Be(11);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input6.txt");
            System.Console.WriteLine(DaySix.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            };

            DaySix.CalculateResultForPartTwo(input).Should().Be(6);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input6.txt");
            System.Console.WriteLine(DaySix.CalculateResultForPartTwo(input));
        }
    }
}
