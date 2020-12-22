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

        public static long CalculateResultForPartTwo(string[] input)
        {
            var adapterRatings = input.Select(int.Parse).ToList();

            return GetTotalArrangementsForAdapterChain(adapterRatings);
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

        public static long GetTotalArrangementsForAdapterChain(List<int> adapterRatings)
        {
            var adapterArrangementsGraph = BuildGraphOfPossibleAdapterArrangements(adapterRatings);

            return CalculatePossibleArrangements(adapterArrangementsGraph);
        }

        private static long CalculatePossibleArrangements(List<Node> arrangementsGraph)
        {
            for (var index = arrangementsGraph.Count-1; index >= 0; index--)
            {
                CalculatePossibleArrangementsForNode(index, arrangementsGraph);
            }

            return arrangementsGraph[0].NumberOfArrangements;
        }

        private static void CalculatePossibleArrangementsForNode(int index, List<Node> arrangements)
        {
            if (index == arrangements.Count - 1)
            {
                arrangements[index].NumberOfArrangements = 1;
            } 
            else if (index < arrangements.Count - 1 && index >= 0)
            {
                var node = arrangements[index];
                node.NumberOfArrangements = node.Children.Sum(n => n.NumberOfArrangements);
            }
        }

        private static List<Node> BuildGraphOfPossibleAdapterArrangements(List<int> adapterRatings)
        {
            adapterRatings.Sort();

            var endToEndAdapterChain = new List<int> { 0 };
            endToEndAdapterChain.AddRange(adapterRatings);
            endToEndAdapterChain.Add(adapterRatings[^1] + 3);

            var adapterChainNodes = endToEndAdapterChain.Select(
                a => new Node
                {
                    Value = a,
                    Children = new List<Node>()
                })
                .ToList();

            AddLinksForPossibleAdapterChains(endToEndAdapterChain, adapterChainNodes);

            return adapterChainNodes;
        }

        private static void AddLinksForPossibleAdapterChains(List<int> adapterRatings, List<Node> nodes)
        {
            for (var i = 0; i < adapterRatings.Count; i++)
            {
                var j = i + 1;
                while (j < adapterRatings.Count && adapterRatings[j] - adapterRatings[i] <= 3)
                {
                    nodes[i].Children.Add(nodes[j]);
                    j++;
                }
            }
        }
    }

    internal class Node
    {
        public int Value { get; set; }
        public long NumberOfArrangements { get; set; }
        public List<Node> Children { get; set; }
    }
}

