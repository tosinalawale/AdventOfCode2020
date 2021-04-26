namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DayElevenTests
    {
        [Test]
        public void Part1_CanApplySeatingRules()
        {
            var input = new[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };

            var expectedResult = new[]
            {
                "#.#L.L#.##",
                "#LLL#LL.L#",
                "L.#.L..#..",
                "#L##.##.L#",
                "#.#L.LL.LL",
                "#.#L#L#.##",
                "..L.L.....",
                "#L#L##L#L#",
                "#.LLLLLL.L",
                "#.#L#L#.##"
            };

            var result = DayEleven.ApplySeatingRules(input);
            result = DayEleven.ApplySeatingRules(result);
            result = DayEleven.ApplySeatingRules(result);
            result = DayEleven.ApplySeatingRules(result);
            result = DayEleven.ApplySeatingRules(result);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Part1_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
            DayEleven.CalculateResultForPartOne(input).Should().Be(37);
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input11.txt");
            System.Console.WriteLine(DayEleven.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_CanApplySeatingRules()
        {
            var input = new[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };

            var expectedResult = new[]
            {
                "#.LL.LL.L#",
                "#LLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLL#",
                "#.LLLLLL.L",
                "#.LLLLL.L#"
            };

            var result = DayEleven.ApplySeatingRulesV2(input);
            result = DayEleven.ApplySeatingRulesV2(result);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void Part2_CalculateResultForSimpleExample()
        {
            var input = new[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };
            DayEleven.CalculateResultForPartTwo(input).Should().Be(26);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input11.txt");
            System.Console.WriteLine(DayEleven.CalculateResultForPartTwo(input));
        }
    }
}
