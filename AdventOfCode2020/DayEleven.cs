namespace AdventOfCode2020
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DayEleven
    {
        public static string[] ApplySeatingRules(string[] input)
        {
            var result = new string[input.Length];
            input.CopyTo(result, 0);

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    var position = input[i][j];
                    var adjacentPositions = AdjacentPositions(i, j, input);

                    switch (position)
                    {
                        case 'L' when adjacentPositions.All(p => !p.Equals('#')):
                            ReplaceCharAt(result, i, j, '#');
                            break;
                        case '#' when adjacentPositions.Count(p => p.Equals('#')) >= 4:
                            ReplaceCharAt(result, i, j, 'L');
                            break;
                    }
                }
            }

            return result;
        }

        public static int CalculateResultForPartOne(string[] input)
        {
            var result = DayEleven.ApplySeatingRules(input);
            var nextResult = DayEleven.ApplySeatingRules(result);
            while (!nextResult.SequenceEqual(result))
            {
                result = nextResult;
                nextResult = DayEleven.ApplySeatingRules(result);
            }

            return CountOccupiedSeats(nextResult);
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            var result = DayEleven.ApplySeatingRulesV2(input);
            var nextResult = DayEleven.ApplySeatingRulesV2(result);
            while (!nextResult.SequenceEqual(result))
            {
                result = nextResult;
                nextResult = DayEleven.ApplySeatingRulesV2(result);
            }

            return CountOccupiedSeats(nextResult);
        }

        public static string[] ApplySeatingRulesV2(string[] input)
        {
            var result = new string[input.Length];
            input.CopyTo(result, 0);

            for (var i = 0; i < input.Length; i++)
            {
                for (var j = 0; j < input[i].Length; j++)
                {
                    var position = input[i][j];
                    var nearestSeats = GetFirstSeatInEachDirection(i, j, input);

                    switch (position)
                    {
                        case 'L' when nearestSeats.All(p => !p.Equals('#')):
                            ReplaceCharAt(result, i, j, '#');
                            break;
                        case '#' when nearestSeats.Count(p => p.Equals('#')) >= 5:
                            ReplaceCharAt(result, i, j, 'L');
                            break;
                    }
                }
            }

            return result;
        }

        private static IList<char> GetFirstSeatInEachDirection(int i, int j, string[] input)
        {
            var seats = new List<char>();

            AddFirstSeatInDirection(i, j, input, -1, 0, seats);
            AddFirstSeatInDirection(i, j, input, -1, -1, seats);
            AddFirstSeatInDirection(i, j, input, -1, 1, seats);
            AddFirstSeatInDirection(i, j, input, 1, 0, seats);
            AddFirstSeatInDirection(i, j, input, 1, -1, seats);
            AddFirstSeatInDirection(i, j, input, 1, 1, seats);
            AddFirstSeatInDirection(i, j, input, 0, 1, seats);
            AddFirstSeatInDirection(i, j, input, 0, -1, seats);
            
            return seats;
        }

        private static void AddFirstSeatInDirection(int i, int j, string[] input, int dX, int dY, IList<char> seats)
        {
            var currentPosX = i + dX;
            var currentPosY = j + dY;

            while (currentPosX >= 0
                   && currentPosX < input.Length
                   && currentPosY >= 0
                   && currentPosY < input[0].Length)
            {
                if (IsASeat(input, currentPosX, currentPosY))
                {
                    seats.Add(input[currentPosX][currentPosY]);
                    return;
                }
                currentPosX += dX;
                currentPosY += dY;
            }
        }

        private static bool IsASeat(string[] input, int currentPosX, int currentPosY)
        {
            return input[currentPosX][currentPosY].Equals('L') || input[currentPosX][currentPosY].Equals('#');
        }

        private static int CountOccupiedSeats(string[] nextResult)
        {
            return nextResult.Sum(l => l.Count(c => c.Equals('#')));
        }

        private static IList<char> AdjacentPositions(int i, int j, string[] input)
        {
            var positions = new List<char>();
            if (i > 0)
            {
                positions.Add(input[i-1][j]);
                if (j > 0)
                {
                    positions.Add(input[i - 1][j - 1]);
                }
                if (j < input[i].Length - 1)
                {
                    positions.Add(input[i - 1][j + 1]);
                }
            }
            if (i < input.Length - 1)
            {
                positions.Add(input[i + 1][j]);
                if (j > 0)
                {
                    positions.Add(input[i + 1][j - 1]);
                }
                if (j < input[i].Length - 1)
                {
                    positions.Add(input[i + 1][j + 1]);
                }
            }

            if (j < input[i].Length - 1)
            {
                positions.Add(input[i][j + 1]); 
            }

            if (j > 0)
            {
                positions.Add(input[i][j - 1]);
            }

            return positions;
        }

        private static void ReplaceCharAt(string[] result, int i, int j, char newChar)
        {
            var chars = result[i].ToCharArray();
            chars[j] = newChar;
            result[i] = new string(chars);
        }
    }
}