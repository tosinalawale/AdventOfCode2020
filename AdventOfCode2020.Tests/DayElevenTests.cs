namespace AdventOfCode2020.Tests
{
    using System.Collections.Generic;
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
    }
}
