namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DayEight
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var accumulator = 0;
            var visited = new int[input.Length];
            var pointer = 0;
            var orderOfVisit = 0;

            while (pointer <= input.Length)
            {
                if (visited[pointer] == 0)
                {
                    visited[pointer] = ++orderOfVisit;
                }
                else
                {
                    return accumulator;
                }

                var instructionParts = input[pointer].Split(" ");
                var operation = instructionParts[0];
                var argument = short.Parse(instructionParts[1]);

                if (operation.Equals("acc"))
                {
                    accumulator += argument;
                }
                else if (operation.Equals("jmp"))
                {
                    pointer += argument;
                    continue;
                }

                pointer++;
            }

            return 0;
        }
    }
}
