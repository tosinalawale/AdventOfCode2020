namespace AdventOfCode2020
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayFive
    {
        public static double FindRow(string boardingPass)
        {
            double startingRow = 0;
            double endingRow = 127;
            for (var i = 0; i < 7; i++)
            {
                double middleRow = (endingRow - startingRow) / 2 + startingRow;
                if (boardingPass[i].Equals('F'))
                {
                    endingRow = (int)Math.Floor(middleRow);
                }
                else
                {
                    startingRow = (int) Math.Ceiling(middleRow);
                }
            }

            return startingRow;
        }

        public static double FindColumn(string boardingPass)
        {
            double startingRow = 0;
            double endingRow = 8;
            for (var i = 7; i < boardingPass.Length; i++)
            {
                double middleRow = (endingRow - startingRow) / 2 + startingRow;
                if (boardingPass[i].Equals('L'))
                {
                    endingRow = (int)Math.Floor(middleRow);
                }
                else
                {
                    startingRow = (int)Math.Ceiling(middleRow);
                }
            }

            return startingRow;
        }

        public static double CalculateResultForPartOne(string[] input)
        {
            double highestSeatId = 0;
            foreach (var boardingPass in input)
            {
                highestSeatId = Math.Max(
                    CalculateSeatId(FindRow(boardingPass), FindColumn(boardingPass)),
                    highestSeatId);
            }

            return highestSeatId;
        }

        private static double CalculateSeatId(double rowNumber, double columnNumber)
        {
            return rowNumber * 8 + columnNumber;
        }

        public static double CalculateResultForPartTwo(string[] input)
        {
            var seatsFound = input.Select(boardingPass => (FindRow(boardingPass), FindColumn(boardingPass))).ToList();

            var missingSeatIds = new List<double>();
            for (var i = 0; i < 128; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (!seatsFound.Contains((i, j)))
                    {
                        missingSeatIds.Add(CalculateSeatId(i,j));
                    }
                }
            }

            return missingSeatIds.FirstOrDefault(
                sid => !missingSeatIds.Contains(sid + 1) && !missingSeatIds.Contains(sid - 1));
        }
    }
}