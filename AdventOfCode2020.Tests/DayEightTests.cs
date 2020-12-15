namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DayEightTests
    {
        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            DayEight.CalculateResultForPartOne(input).Should().Be(5);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input8.txt");
            System.Console.WriteLine(DayEight.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            };

            DayEight.CalculateResultForPartTwo(input).Should().Be(8);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input8.txt");
            System.Console.WriteLine(DayEight.CalculateResultForPartTwo(input));
        }
    }
}
