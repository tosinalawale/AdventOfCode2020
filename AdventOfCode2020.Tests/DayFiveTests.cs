namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DayFiveTests
    {
        [Test]
        public void Part1_CanFindSeatRowForBoardingPass()
        {
            DayFive.FindRow("FBFBBFFRLR").Should().Be(44);
        }

        [Test]
        public void Part1_CanFindSeatColumnForBoardingPass()
        {
            DayFive.FindColumn("FBFBBFFRLR").Should().Be(5);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input5.txt");
            System.Console.WriteLine(DayFive.CalculateResultForPartOne(input));
        }
    }
}
