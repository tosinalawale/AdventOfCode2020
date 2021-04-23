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