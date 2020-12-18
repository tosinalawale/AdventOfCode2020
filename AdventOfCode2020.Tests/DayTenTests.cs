namespace AdventOfCode2020.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;


    public class DayTenTests
    {
        [Test]
        public void Part1_GetJoltageDistributionForSimpleExample()
        {
            var input = new List<int>
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            DayTen.GetJoltageDistrubutionForAdapterChain(input).Should().Be((7, 0, 5));
        }

        [Test]
        public void Part1_GetJoltageDistributionForLargerExample()
        {
            var input = new List<int>
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };

            DayTen.GetJoltageDistrubutionForAdapterChain(input).Should().Be((22, 0, 10));
        }

        [Test]
        public void Part1_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input10.txt");
            System.Console.WriteLine(DayTen.CalculateResultForPartOne(input));
        }

        [Test]
        public void Part2_GetTotalArrangementsForSimpleExample()
        {
            var input = new List<int>
            {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            DayTen.GetTotalArrangementsForAdapterChain(input).Should().Be(8);
        }

        [Test]
        public void Part2_GetTotalArrangementsForLargerExample()
        {
            var input = new List<int>
            {
                28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };

            DayTen.GetTotalArrangementsForAdapterChain(input).Should().Be(19208);
        }

        [Test]
        public void Part2_CalculateResult()
        {
            var input = File.ReadAllLines(@"Input/input10.txt");
            System.Console.WriteLine(DayTen.CalculateResultForPartTwo(input));
        }
    }
}
