namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DaySeven
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var rules = new Dictionary<string, List<string>>();

            foreach (var rule in input)
            {
                var inputParts = rule.Split(" bags contain ");
                var ruleKey = inputParts[0];
                var ruleValue = ExtractContents(inputParts[1]);
                rules.Add(ruleKey, ruleValue);
            }

            return rules.Keys.Count(c => EventuallyContainsBagColour(c, "shiny gold", rules));
        }

        private static List<string> ExtractContents(string bagContents)
        {
            bagContents = Regex.Replace(bagContents, @"\s*bag(s*),\s*", "|");
            bagContents = Regex.Replace(bagContents, @"\s*bag(s*)\.\s*", string.Empty);
            bagContents = Regex.Replace(bagContents, @"\s*\d+\s*", string.Empty);
            return bagContents.Split('|').ToList();
        }

        private static bool EventuallyContainsBagColour(string containerBag, string bagColour, Dictionary<string, List<string>> rules)
        {
            var bagContents = rules[containerBag];

            if (bagContents[0].Equals("no other"))
            {
                return false;
            }

            return bagContents.Contains(bagColour) 
                   || bagContents.Any(b => EventuallyContainsBagColour(b, bagColour, rules));
        }
    }
}
