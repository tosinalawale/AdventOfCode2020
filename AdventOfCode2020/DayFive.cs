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
            var seatsFound = new List<(double, double)>(input.Length);
            foreach (var boardingPass in input)
            {
                seatsFound.Add((FindRow(boardingPass), FindColumn(boardingPass)));
            }

            var missingSeats = new List<(double, double)>(input.Length);
            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!seatsFound.Contains((i, j)))
                    {
                        missingSeats.Add((i,j));
                    }
                }
            }

            foreach (var seat in missingSeats)
            {
                var seatId = CalculateSeatId(seat.Item1, seat.Item2);
                var seatIdPlusOneMissing = missingSeats.Any(s => CalculateSeatId(s.Item1, s.Item2) == seatId + 1);
                var seatIdMinusOneMissing = missingSeats.Any(s => CalculateSeatId(s.Item1, s.Item2) == seatId - 1);
                if (!seatIdPlusOneMissing && !seatIdMinusOneMissing) return seatId;
            }

            return 0;
        }
    }
}