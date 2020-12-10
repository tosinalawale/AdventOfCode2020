namespace AdventOfCode2020
{
    using System;

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
                highestSeatId = Math.Max(FindRow(boardingPass) * 8 + FindColumn(boardingPass), highestSeatId);
            }

            return highestSeatId;
        }
    }
}