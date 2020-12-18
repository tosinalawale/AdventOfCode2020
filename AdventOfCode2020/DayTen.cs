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

        public static int CalculateResultForPartTwo(string[] input)
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

        public static int GetTotalArrangementsForAdapterChain(List<int> adapterRatings)
        {
            var arrangementsTree = BuildTreeOfPossibleArrangements(adapterRatings);

            return CountArrangements(arrangementsTree);
        }

        private static int CountArrangements(TreeNode arrangementsTree)
        {
            var numberOfChildren = arrangementsTree.Children.Count;

            if (numberOfChildren == 0)
            {
                return 1;
            }

            return arrangementsTree.Children.Sum(CountArrangements);
        }

        private static TreeNode BuildTreeOfPossibleArrangements(List<int> adapterRatings)
        {
            adapterRatings.Sort();

            var treeRoot = new TreeNode
            {
                Value = 0,
                Children = new List<TreeNode>()
            };

            FindNextAdaptersInChain(adapterRatings, 0, treeRoot);

            return treeRoot;
        }

        private static void FindNextAdaptersInChain(List<int> adapterRatings, int index, TreeNode currentNode)
        {
            while (index < adapterRatings.Count && adapterRatings[index] - currentNode.Value <= 3)
            {
                var newChild = new TreeNode
                {
                    Value = adapterRatings[index],
                    Children = new List<TreeNode>(),
                    //Parent = currentNode
                };
                currentNode.Children.Add(newChild);
                FindNextAdaptersInChain(adapterRatings, ++index, newChild);
            }
        }
    }

    internal class TreeNode
    {
        public int Value { get; set; }
        public List<TreeNode> Children { get; set; }
        //public TreeNode Parent { get; set; }
    }
}

