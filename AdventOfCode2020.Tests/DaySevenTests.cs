namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DaySevenTests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            DaySeven.CalculateResultForPartOne(input).Should().Be(4);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input7.txt");
            System.Console.WriteLine(DaySeven.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            };

            DaySeven.CalculateResultForPartTwo(input).Should().Be(32);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input7.txt");
            System.Console.WriteLine(DaySeven.CalculateResultForPartTwo(input));
        }
    }
}
