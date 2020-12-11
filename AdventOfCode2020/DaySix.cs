namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.Linq;

    public class DaySix
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var groups = new List<string>();
            var currentInputIndex = 0;

            while (currentInputIndex < input.Length)
            {
                groups.Add("");

                do
                {
                    groups[groups.Count - 1] += input[currentInputIndex];
                    currentInputIndex++;
                } while (currentInputIndex < input.Length && input[currentInputIndex] != string.Empty);

                currentInputIndex++;
            }

            return groups.Sum(grp => new HashSet<char>(grp).Count);
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            var groups = new List<List<string>>();
            var currentInputIndex = 0;

            while (currentInputIndex < input.Length)
            {
                groups.Add(new List<string>());

                do
                {
                    groups[groups.Count - 1].Add(input[currentInputIndex]);
                    currentInputIndex++;
                } while (currentInputIndex < input.Length && input[currentInputIndex] != string.Empty);

                currentInputIndex++;
            }

            return groups.Sum(grp => 
                grp.Aggregate((p, q) => string.Concat(p.Intersect(q))).Length);
        }
    }
}
