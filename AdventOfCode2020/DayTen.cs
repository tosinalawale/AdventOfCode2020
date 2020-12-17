namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.Linq;

    public class DayTen
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var adapterRatings = input.Select(int.Parse).ToList();

            var (ones, twos, threes) = GetJoltageDistrubutionForAdapterChain(adapterRatings);

            return ones * threes;
        }

        public static (int ones, int twos, int threes) GetJoltageDistrubutionForAdapterChain(List<int> adapterRatings)
        {
            adapterRatings.Sort();

            var adapterChainJoltageDifferences = new int[adapterRatings.Count + 1];

            adapterChainJoltageDifferences[0] = adapterRatings[0];
            adapterChainJoltageDifferences[^1] = 3;

            for (var i = 1; i < adapterRatings.Count; i++)
            {
                adapterChainJoltageDifferences[i] = adapterRatings[i] - adapterRatings[i-1];
            }

            var ones = adapterChainJoltageDifferences.Count(x => x == 1);
            var twos = adapterChainJoltageDifferences.Count(x => x == 2);
            var threes = adapterChainJoltageDifferences.Count(x => x == 3);

            return (ones, twos, threes);
        }
    }
}
