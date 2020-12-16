namespace AdventOfCode2020
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayNine
    {
        public static long CalculateResultForPartOne(string[] input)
        {
            var inputNumbers = input.Select(long.Parse).ToList();

            return FindNonXmasNumber(inputNumbers, 27);
        }

        public static long FindNonXmasNumber(List<long> inputNumbers, int preambleLength)
        {
            for (var i = preambleLength; i < inputNumbers.Count; i++)
            {
                if (!IsMatch(inputNumbers, i, preambleLength))
                {
                    return inputNumbers[i];
                }
            }

            return int.MinValue;
        }

        public static (int, int) FindContiguousRangeSummingUpToTotal(long targetTotal, List<long> input)
        {
            for (var startIndex = 0; startIndex < input.Count - 1; startIndex++)
            {
                var endIndex = TestRangesFrom(startIndex, input, targetTotal);
                if (endIndex != -1)
                {
                    return (startIndex, endIndex);
                }
            }

            return (0, -1);
        }

        public static long CalculateResultForPartTwo(string[] input)
        {
            var inputNumbers = input.Select(long.Parse).ToList();

            var nonXmasNumber = FindNonXmasNumber(inputNumbers, 27);

            var (startIndex, endIndex) = FindContiguousRangeSummingUpToTotal(nonXmasNumber, inputNumbers);

            var min = long.MaxValue;
            var max = long.MinValue;

            for (var i = startIndex; i <= endIndex; i++)
            {
                var number = inputNumbers[i];
                min = Math.Min(min, number);
                max = Math.Max(max, number);
            }

            return min + max;
        }

        private static int TestRangesFrom(int startIndex, List<long> input, long targetSum)
        {
            long sum = 0;
            for (var endIndex = startIndex; endIndex < input.Count; endIndex++)
            {
                sum += input[endIndex];
                if (sum == targetSum && endIndex != startIndex)
                {
                    return endIndex;
                }
            }

            return -1;
        }

        private static bool IsMatch(List<long> input, int index, int preambleLength)
        {
            for (var x = index - preambleLength; x < index; x++)
            {
                for (var y = x + 1; y < index; y++)
                {
                    if (input[x] + input[y] == input[index])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
